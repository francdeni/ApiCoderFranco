using ApiCoderFranco.Models;
using Microsoft.OpenApi.Writers;
using System.Data.SqlClient;

namespace ApiCoderFranco.Repository
{
    public class VentaRepository
    {
        public List<Venta> GetVentas(int idUser)
        {
            var list = new List<Venta>();
            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "LAPTOP-MN1MMSQO\\SQLEXPRESS";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM Venta where IdUsuario = @IdUsuario";
                var parametro = new SqlParameter();
                parametro.ParameterName = "IdUsuario";
                parametro.SqlDbType = System.Data.SqlDbType.BigInt;
                parametro.Value = idUser;
                cmd.Parameters.Add(parametro);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var venta = new Venta();

                    venta.Id = Convert.ToInt32(reader.GetValue(0));
                    venta.Comentarios = reader.GetValue(1).ToString();
                    venta.IdUsuario = Convert.ToInt32(reader.GetValue(2));
                    list.Add(venta);

                }

                return list;
            }

        }
        public static void NewVenta(List<ProductoVenta> productList,int idUser,string comentario)
        {
            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "DESKTOP-MALR5B3\\SQLEXPRESS";
            conecctionbuilder.InitialCatalog = "master";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                SqlCommand cmd2 = connection.CreateCommand();
                SqlCommand cmd3 = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO Venta VALUES((SELECT @@IDENTITY FROM Venta)+1,@comentario,@idUser)";

                var paramComment = new SqlParameter();
                paramComment.ParameterName = "comentario";
                paramComment.SqlDbType = System.Data.SqlDbType.VarChar;
                paramComment.Value = comentario;
                cmd.Parameters.Add(paramComment);
                
                var paramUser = new SqlParameter();
                paramUser.ParameterName = "idUser";
                paramUser.SqlDbType = System.Data.SqlDbType.Int;
                paramUser.Value = idUser;
                cmd.Parameters.Add(paramUser);

                cmd.ExecuteNonQuery();

                
                cmd2.CommandText = "INSERT INTO ProductoVendido VALUES";
                
                foreach (var item in productList)
                {
                    cmd2.CommandText += "((SELECT @@IDENTITY FROM ProductoVendido)+1," + Convert.ToString(item.Stock) + "," + Convert.ToString(item.IdProducto) + "," + Convert.ToString(item.IdVenta) + "),";
                    cmd3.CommandText = "UPDATE Producto SET STOCK = STOCK - " + Convert.ToString(item.Stock) + "WHERE IDPRODUCTO = " + Convert.ToString(item.IdProducto);
                    cmd3.ExecuteNonQuery();
        //private int _id;
        //private int _stock;
        //private int _idproducto;
        //private int _idventa;

                }
                cmd2.CommandText.Remove(0, cmd2.CommandText.Length - 1);
                cmd2.ExecuteNonQuery();
                connection.Close();
            }

        }
    }
}
