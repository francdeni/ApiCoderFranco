using ApiCoderFranco.Models;
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
    }
}
