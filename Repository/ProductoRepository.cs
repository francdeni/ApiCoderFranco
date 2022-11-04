using ApiCoderFranco.Models;
using Microsoft.Extensions.Hosting;
using System.Data.SqlClient;

namespace ApiCoderFranco.Repository
{
    public class ProductoRepository
    {
        public List<Producto> GetProductos(int idUser)
        {
            var list = new List<Producto>();
            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "LAPTOP-MN1MMSQO\\SQLEXPRESS";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM Producto where IdUsuario = @IdUsuario";
                var parametro = new SqlParameter();
                parametro.ParameterName = "IdUsuario";
                parametro.SqlDbType = System.Data.SqlDbType.BigInt;
                parametro.Value = idUser;
                cmd.Parameters.Add(parametro);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var prod = new Producto();

                    prod.Id = Convert.ToInt32(reader.GetValue(0));
                    prod.Descripciones = reader.GetValue(1).ToString();
                    prod.Costo = Convert.ToInt32(reader.GetValue(2));
                    prod.PrecioVenta = Convert.ToInt32(reader.GetValue(3));
                    prod.Stock = Convert.ToInt32(reader.GetValue(4));
                    prod.IdUsuario = Convert.ToInt32(reader.GetValue(5));

                    //prod.ProductoVenta = new ProductoVentaRepository().GetProdVentas(prod.Id);
                    list.Add(prod);

                }

                return list;
            }

        }

        public static void NewProducto(Producto newprod)
        {
            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "LAPTOP-MN1MMSQO\\SQLEXPRESS";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Insert into Producto ((SELECT @@IDENTITY FROM Producto)+1,@Descripciones,@Costo,@PrecioVenta,@Stock,@IdUsu)";
                //var paramId = new SqlParameter();
                //paramId.ParameterName = "Id";
                //paramId.SqlDbType = System.Data.SqlDbType.BigInt;
                //paramId.Value = newprod.Id;

                var paramDesc = new SqlParameter();
                paramDesc.ParameterName = "Descripciones";
                paramDesc.SqlDbType = System.Data.SqlDbType.VarChar;
                paramDesc.Value = newprod.Descripciones;

                var paramCosto = new SqlParameter();
                paramCosto.ParameterName = "Costo";
                paramCosto.SqlDbType = System.Data.SqlDbType.BigInt;
                paramCosto.Value = newprod.Costo;

                var paramPreVen = new SqlParameter();
                paramPreVen.ParameterName = "PrecioVenta";
                paramPreVen.SqlDbType = System.Data.SqlDbType.BigInt;
                paramPreVen.Value = newprod.PrecioVenta;

                var paramStock = new SqlParameter();
                paramStock.ParameterName = "Stock";
                paramStock.SqlDbType = System.Data.SqlDbType.BigInt;
                paramStock.Value = newprod.Stock;

                var paramIdUsu = new SqlParameter();
                paramIdUsu.ParameterName = "IdUsu";
                paramIdUsu.SqlDbType = System.Data.SqlDbType.VarChar;
                paramIdUsu.Value = newprod.IdUsuario;

                cmd.Parameters.Add(paramId);
                cmd.Parameters.Add(paramDesc);
                cmd.Parameters.Add(paramCosto);
                cmd.Parameters.Add(paramPreVen);
                cmd.Parameters.Add(paramStock);
                cmd.Parameters.Add(paramIdUsu);
                cmd.ExecuteNonQuery();
                connection.Close();
            }



        }
        public static void UpdateProd(Producto newprod)
        {
            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "LAPTOP-MN1MMSQO\\SQLEXPRESS";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Update Producto set Descripciones = @Descripciones, Costo = @Costo, PrecioVenta = @PrecioVenta,Stock = @Stock,IdUsuario = @IdUsu where Id = @Id";
                var paramId = new SqlParameter();
                paramId.ParameterName = "Id";
                paramId.SqlDbType = System.Data.SqlDbType.BigInt;
                paramId.Value = newprod.Id;

                var paramDesc = new SqlParameter();
                paramDesc.ParameterName = "Descripciones";
                paramDesc.SqlDbType = System.Data.SqlDbType.VarChar;
                paramDesc.Value = newprod.Descripciones;

                var paramCosto = new SqlParameter();
                paramCosto.ParameterName = "Costo";
                paramCosto.SqlDbType = System.Data.SqlDbType.BigInt;
                paramCosto.Value = newprod.Costo;

                var paramPreVen = new SqlParameter();
                paramPreVen.ParameterName = "PrecioVenta";
                paramPreVen.SqlDbType = System.Data.SqlDbType.BigInt;
                paramPreVen.Value = newprod.PrecioVenta;

                var paramStock = new SqlParameter();
                paramStock.ParameterName = "Stock";
                paramStock.SqlDbType = System.Data.SqlDbType.BigInt;
                paramStock.Value = newprod.Stock;

                var paramIdUsu = new SqlParameter();
                paramIdUsu.ParameterName = "IdUsu";
                paramIdUsu.SqlDbType = System.Data.SqlDbType.VarChar;
                paramIdUsu.Value = newprod.IdUsuario;

                cmd.Parameters.Add(paramId);
                cmd.Parameters.Add(paramDesc);
                cmd.Parameters.Add(paramCosto);
                cmd.Parameters.Add(paramPreVen);
                cmd.Parameters.Add(paramStock);
                cmd.Parameters.Add(paramIdUsu);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static void DeleteProd(int id)
        {
            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "LAPTOP-MN1MMSQO\\SQLEXPRESS";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Delete from ProductoVendido where IdProducto = @IdProd";
                var paramId = new SqlParameter();
                paramId.ParameterName = "IdProd";
                paramId.SqlDbType = System.Data.SqlDbType.BigInt;
                paramId.Value = id;
                               
                cmd.Parameters.Add(paramId);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "Delete from Producto where Id = @IdProd";
                var paramId2 = new SqlParameter();
                paramId2.ParameterName = "IdProd";
                paramId2.SqlDbType = System.Data.SqlDbType.BigInt;
                paramId2.Value = id;
                cmd2.Parameters.Add(paramId2);
                cmd2.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
