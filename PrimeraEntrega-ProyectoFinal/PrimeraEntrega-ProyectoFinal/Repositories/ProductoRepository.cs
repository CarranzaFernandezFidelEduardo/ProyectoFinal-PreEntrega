using PrimeraEntrega_ProyectoFinal.Models;
using System.Data.SqlClient;
using System.Data;

namespace PrimeraEntrega_ProyectoFinal.Repositories
{
    public class ProductoRepository
    {
        public List<Producto> TraerProducto(int IdUsuario)
        {

            var listaProductos = new List<Producto>();

            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "DESKTOP-KU34FRJ\\MSSSQLSERVER";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;

            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM producto WHERE IdUsuario = @idUsuario";

                var param = new SqlParameter("idUsuario", SqlDbType.Int);
                param.Value = IdUsuario;

                cmd.Parameters.Add(param);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Producto producto = new Producto();

                    producto.Id = Convert.ToInt32(reader.GetValue(0));
                    producto.Descripciones = reader.GetValue(1).ToString();
                    producto.Costo = Convert.ToDouble(reader.GetValue(2));
                    producto.PrecioVenta = Convert.ToDouble(reader.GetValue(3));
                    producto.Stock = Convert.ToInt32(reader.GetValue(4));
                    producto.IdUsuario = Convert.ToInt32(reader.GetValue(5));

                    listaProductos.Add(producto);

                }

                reader.Close();

                return listaProductos;

            }
        }

        public List<Producto> TraerProductos()
        {

            var listaProductos = new List<Producto>();

            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "DESKTOP-KU34FRJ\\MSSSQLSERVER";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;

            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM producto";

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Producto producto = new Producto();

                    producto.Id = Convert.ToInt32(reader.GetValue(0));
                    producto.Descripciones = reader.GetValue(1).ToString();
                    producto.Costo = Convert.ToDouble(reader.GetValue(2));
                    producto.PrecioVenta = Convert.ToDouble(reader.GetValue(3));
                    producto.Stock = Convert.ToInt32(reader.GetValue(4));
                    producto.IdUsuario = Convert.ToInt32(reader.GetValue(5));

                    listaProductos.Add(producto);

                }

                reader.Close();

                return listaProductos;

            }
        }

        public List<Producto> TraerProductoParaPruductoVendido(int IdProducto)
        {

            var listaProductos = new List<Producto>();

            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "DESKTOP-KU34FRJ\\MSSSQLSERVER";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;

            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM producto WHERE Id = @idProducto";

                var param = new SqlParameter("idProducto", SqlDbType.Int);
                param.Value = IdProducto;

                cmd.Parameters.Add(param);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Producto producto = new Producto();

                    producto.Id = Convert.ToInt32(reader.GetValue(0));
                    producto.Descripciones = reader.GetValue(1).ToString();
                    producto.Costo = Convert.ToDouble(reader.GetValue(2));
                    producto.PrecioVenta = Convert.ToDouble(reader.GetValue(3));
                    producto.Stock = Convert.ToInt32(reader.GetValue(4));
                    producto.IdUsuario = Convert.ToInt32(reader.GetValue(5));

                    listaProductos.Add(producto);

                }

                reader.Close();

                return listaProductos;

            }
        }


    }
}
