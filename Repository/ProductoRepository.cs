using ApiCoderFranco.Models;
using System.Data.SqlClient;

namespace ApiCoderFranco.Repository
{
    public class ProductoRepository
    {
        public List<Producto> GetProductos()
        {
            var list = new List<Producto>();
            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "DESKTOP-MALR5B3\\SQLEXPRESS";
            conecctionbuilder.InitialCatalog = "master";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM Producto";
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

                    list.Add(prod);

                }

                return list;
            }

        }
    }
}
