using ApiCoderFranco.Models;
using System.Data;
using System.Data.SqlClient;

namespace ApiCoderFranco.Repository
{
    public class UsuarioRepository
    {

        
            public static List<Usuario> GetUsuarios(int id)
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
                    parametro.Value = id;
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

    

        public static Usuario Getlogin(string nombre, string contraseña)
        {

            Usuario usuario = new Usuario();

            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "DESKTOP-MALR5B3\\SQLEXPRESS";
            conecctionbuilder.InitialCatalog = "master";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {

                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM Usuario where NombreUsuario = @nombre AND   Contraseña = @contraseña";
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@contraseña", contraseña);

                var reader = cmd.ExecuteReader();
                
                if(reader.Read())
                {
                    var userId = Convert.ToInt32(reader.GetValue(0));
                    List<Usuario> usuarios = GetUsuarios(userId);
                    usuario = usuarios[0];

                }


                cmd.Connection.Close();
                
            }
            return usuario;
        }

        public static Usuario GetUsuarioByNombre(string nombre)
        {
            Usuario usuario = new Usuario();

            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "DESKTOP-MALR5B3\\SQLEXPRESS";
            conecctionbuilder.InitialCatalog = "master";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {

                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM Usuario where NombreUsuario = @nombre";
                cmd.Parameters.AddWithValue("@nombre", nombre);
                
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    var userId = Convert.ToInt32(reader.GetValue(0));
                    List<Usuario> usuarios = GetUsuarios(userId);
                    usuario = usuarios[0];

                }


                cmd.Connection.Close();

            }
            return usuario;
        }
        public static void UpdateUsuario(Usuario user)
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
                    cmd.CommandText = "UPDATE USUARIO SET Nombre = @nombre, Apellido = @apellido, NombreUsuario = @nombreusuario , Contraseña = @contrasenia , Mail = @mail where ID = @IdUsuario ";
                    
                    var paramId = new SqlParameter();
                    paramId.ParameterName = "IdUsuario";
                    paramId.SqlDbType = System.Data.SqlDbType.BigInt;
                    paramId.Value = user.Id;

                    var paramNom = new SqlParameter();
                    paramNom.ParameterName = "nombre";
                    paramNom.SqlDbType = System.Data.SqlDbType.VarChar;
                    paramNom.Value = user.Nombre;

                    var paramApe = new SqlParameter();
                    paramApe.ParameterName = "apellido";
                    paramApe.SqlDbType = System.Data.SqlDbType.VarChar;
                    paramApe.Value = user.Apellido;

                    var paramNomUsu = new SqlParameter();
                    paramNomUsu.ParameterName = "nombreusuario";
                    paramNomUsu.SqlDbType = System.Data.SqlDbType.VarChar;
                    paramNomUsu.Value = user.NombreUsuario;

                    var paramPw = new SqlParameter();
                    paramPw.ParameterName = "contrasenia";
                    paramPw.SqlDbType = System.Data.SqlDbType.VarChar;
                    paramPw.Value = user.Contrasenia;

                    var paramMail = new SqlParameter();
                    paramMail.ParameterName = "mail";
                    paramMail.SqlDbType = System.Data.SqlDbType.VarChar;
                    paramMail.Value = user.Mail;



                    cmd.Parameters.Add(paramId);
                    cmd.Parameters.Add(paramNom);
                    cmd.Parameters.Add(paramApe);
                    cmd.Parameters.Add(paramNomUsu);
                    cmd.Parameters.Add(paramPw);
                    cmd.Parameters.Add(paramMail);
                    cmd.ExecuteNonQuery();
                    connection.Close();

                }

        }

        public static void CreateUsuario(Usuario usuario)
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
                cmd.CommandText = "Insert into Usuario VALUES (@Nombre,@Apellido,@NombreUsuario,@Contrasenia,@mail)";
                //No se declara en una tabla con Identity
                //var paramId = new SqlParameter();
                //paramId.ParameterName = "Id";
                //paramId.SqlDbType = System.Data.SqlDbType.BigInt;
                //paramId.Value = newprod.Id;

                var paramNombre = new SqlParameter();
                paramNombre.ParameterName = "Nombre";
                paramNombre.SqlDbType = System.Data.SqlDbType.VarChar;
                paramNombre.Value = usuario.Nombre;

                var paramApellido = new SqlParameter();
                paramApellido.ParameterName = "Apellido";
                paramApellido.SqlDbType = System.Data.SqlDbType.VarChar;
                paramApellido.Value = usuario.Apellido;

                var paramNomUsu = new SqlParameter();
                paramNomUsu.ParameterName = "NombreUsuario";
                paramNomUsu.SqlDbType = System.Data.SqlDbType.VarChar;
                paramNomUsu.Value = usuario.NombreUsuario;

                var paramPw = new SqlParameter();
                paramPw.ParameterName = "Contrasenia";
                paramPw.SqlDbType = System.Data.SqlDbType.VarChar;
                paramPw.Value = usuario.Contrasenia;

                var paramMail = new SqlParameter();
                paramMail.ParameterName = "Mail";
                paramMail.SqlDbType = System.Data.SqlDbType.VarChar;
                paramMail.Value = usuario.Mail;


                cmd.Parameters.Add(paramNombre);
                cmd.Parameters.Add(paramApellido);
                cmd.Parameters.Add(paramNomUsu);
                cmd.Parameters.Add(paramPw);
                cmd.Parameters.Add(paramMail);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

    }
}
