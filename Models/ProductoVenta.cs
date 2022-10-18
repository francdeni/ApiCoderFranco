namespace ApiCoderFranco.Models
{
    public class ProductoVenta
    {
        #region Statements
        private int _id;
        private int _stock;
        private int _idproducto;
        private int _idventa;

        #endregion

        #region Propiedades
        public int Id { get { return _id; } set { _id = value; } }
        public int Stock { get { return _stock; } set { _stock = value; } }
        public int IdProducto { get { return _idproducto; } set { _idproducto = value; } }
        public int IdVenta { get { return _idventa; } set { _idventa = value; } }
        #endregion

        #region Constructores
        public ProductoVenta()
        {

        }

        public ProductoVenta(int id, int stock, int idproducto, int idventa)
        {
            Id = id;
            Stock = stock;
            IdProducto = idproducto;
            IdVenta = idventa;


        }
        #endregion
        public List<ProductoVenta> GetProdVentas()
        {
            return new List<ProductoVenta>();
        }
    }
}
