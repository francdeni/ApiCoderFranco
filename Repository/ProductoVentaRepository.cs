using ApiCoderFranco.Models;
using System.Data.SqlClient;

namespace ApiCoderFranco.Repository
{
    public class ProductoVentaRepository
    {
        public static List<ProductoVenta> GetProdVentas(int idUser)
        {
            var listaProd = ProductoRepository.GetProductos(idUser);
            var list = new List<ProductoVenta>();
            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "DESKTOP-MALR5B3\\SQLEXPRESS";
            conecctionbuilder.InitialCatalog = "master";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;
            
            using (SqlConnection connection = new SqlConnection(cs))
            {
                
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
               
                cmd.CommandText = "SELECT * FROM ProductoVendido WHERE IdProducto in (";
                foreach (var item in listaProd)
                {
                    cmd.CommandText += "'"+ Convert.ToString(item.Id) + "'"+",";
                }
                cmd.CommandText.Remove(0, cmd.CommandText.Length - 1);
                cmd.CommandText += ")";
               
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var prodVenta = new ProductoVenta();

                    prodVenta.Id = Convert.ToInt32(reader.GetValue(0));
                    prodVenta.Stock = Convert.ToInt32(reader.GetValue(1));
                    prodVenta.IdProducto = Convert.ToInt32(reader.GetValue(2));
                    prodVenta.IdVenta = Convert.ToInt32(reader.GetValue(3));

                    list.Add(prodVenta);

                }

                return list;
            }
        }
    }
}
