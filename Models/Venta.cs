namespace ApiCoderFranco.Models
{
    public class Venta
    {
        #region Statements
        private int _id;
        private string _comentarios;
        private int _idusuario;
        #endregion

        #region Propiedades
        public int Id { get { return _id; } set { _id = value; } }
        public string Comentarios { get { return _comentarios; } set { _comentarios = value; } }
        public int IdUsuario { get { return _idusuario; } set { _idusuario = value; } }
        
        #endregion

        #region Constructores
        public Venta()
        {

        }

        public Venta(int id, string comentarios, int idusuario)
        {
            Id = id;
            Comentarios = comentarios;
            IdUsuario = idusuario;
            
        }
        #endregion
        //public List<Venta> GetVentas()
        //{
        //    return new List<Venta>();
        //}
    }
}
