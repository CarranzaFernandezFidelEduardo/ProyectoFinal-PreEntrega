using PrimeraEntrega_ProyectoFinal.Models;
using System.Data;
using System.Data.SqlClient;

namespace PrimeraEntrega_ProyectoFinal.Repositories
{
    public class ProductoVendidoRepository
    {
        public List<ProductoVendido> TraerProductoVendido()
        {
            List<ProductoVendido> listaProductosVendidos = new List<ProductoVendido>();

            var text = string.Empty;

            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "DESKTOP-KU34FRJ\\MSSSQLSERVER";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;

            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM ProductoVendido";

                var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ProductoVendido ProductoVendido = new ProductoVendido();


                        ProductoVendido.Id = Convert.ToInt32(reader.GetValue(0));
                        ProductoVendido.Stock = Convert.ToInt32(reader.GetValue(1));
                        ProductoVendido.IdProducto = Convert.ToInt32(reader.GetValue(2));
                        ProductoVendido.IdVenta = Convert.ToInt32(reader.GetValue(3));


                        listaProductosVendidos.Add(ProductoVendido);

                        ProductoVendido.Producto = new ProductoRepository().TraerProducto(ProductoVendido.IdProducto);


                    }
                

            

                reader.Close();

                return listaProductosVendidos;
            }
        }
    }
}
