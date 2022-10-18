namespace ApiCoderFranco.Models
{
    public class Producto
    {

        #region Statements
        private int _id;
        private string _descripciones;
        private double _costo;
        private double _precioventa;
        private int _stock;
        private int _idusuario;
        #endregion

        #region Propiedades
        public int Id { get { return _id; } set { _id = value; } }
        public string Descripciones { get { return _descripciones; } set { _descripciones = value; } }
        public double Costo { get { return _costo; } set { _costo = value; } }
        public double PrecioVenta { get { return _precioventa; } set { _precioventa = value; } }
        public int Stock { get { return _stock; } set { _stock = value; } }
        public int IdUsuario { get { return _idusuario; } set { _idusuario = value; } }
        #endregion

        #region Constructores
        public Producto()
        {

        }

        public Producto(int id, string descripciones, double costo, double precioventa, int stock, int idusuario)
        {
            Id = id;
            Descripciones = descripciones;
            Costo = costo;
            PrecioVenta = precioventa;
            Stock = stock;
            IdUsuario = idusuario;


        }
        #endregion
        public List<Producto> GetProductos()
        {
            return new List<Producto>();
        }
    }
}
