using ApiCoderFranco.Models;
using System.Data.SqlClient;

namespace ApiCoderFranco.Repository
{
    public class UsuarioRepository
    {
        private object parameters;

        public List<Usuario> GetUsuarios()
        {
            var list = new List<Usuario>();
            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "DESKTOP-MALR5B3\\SQLEXPRESS";
            conecctionbuilder.InitialCatalog = "master";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM Usuario where Id = @IdUsuario";
                var parametro = new SqlParameter();
                parametro.ParameterName = "IdUsuario";
                parametro.SqlDbType = System.Data.SqlDbType.BigInt;
                parametro.Value = parameters;
                cmd.Parameters.Add(parametro);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var user = new Usuario();

                    user.Id = Convert.ToInt32(reader.GetValue(0));
                    user.Nombre = reader.GetValue(1).ToString();
                    user.Apellido = reader.GetValue(2).ToString();
                    user.NombreUsuario = reader.GetValue(3).ToString();
                    user.Contrasenia = reader.GetValue(4).ToString();
                    user.Mail = reader.GetValue(5).ToString();

                    list.Add(user);

                }
                
                return list;
            }

           
        }
    }
}
