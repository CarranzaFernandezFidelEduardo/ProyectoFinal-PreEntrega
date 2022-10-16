using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preentrega_proyecto
{
    public class ProductoVendido : Producto
    {
        private int Id;
        private int IdProducto;
        private int Stock;
        private int IdVenta;
    
        public ProductoVendido()
        {
            Id = 0;
            IdProducto = 0;
            Stock = 0;
            IdVenta = 0;
        }

        public void TraerProductoVendido(List<ProductoVendido> productosVendidos, int IdProducto)
        {

            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "DESKTOP-KU34FRJ\\MSSSQLSERVER";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;

            var cs = conecctionbuilder.ConnectionString;
            
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT PV.Id, PV.Stock, PV.IdProducto, PV.IdVenta, P.Descripciones, P.Costo,  P.PrecioVenta, P.IdUsuario FROM ProductoVendido PV INNER JOIN Producto P ON PV.IdProducto = P.Id WHERE PV.IdProducto = @IdProduc";

                var param = new SqlParameter("IdProduc", SqlDbType.BigInt);
                param.Value = IdProducto;

                cmd.Parameters.Add(param);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProductoVendido producVendido = new ProductoVendido();
                    

                    producVendido.Id = Convert.ToInt32(reader.GetValue(0));
                    producVendido.Stock = Convert.ToInt32(reader.GetValue(1));
                    producVendido.IdProducto = Convert.ToInt32(reader.GetValue(2));
                    producVendido.IdVenta = Convert.ToInt32(reader.GetValue(3));
                    producVendido.Descripciones = reader.GetValue(4).ToString();
                    producVendido.Costo = Convert.ToInt32(reader.GetValue(5));
                    producVendido.PrecioVenta = Convert.ToInt32(reader.GetValue(6));
                    producVendido.IdUsuario = Convert.ToInt32(reader.GetValue(7));

                    productosVendidos.Add(producVendido);
                    

                }


                if (productosVendidos.Count >= 1)
                {

                    Console.WriteLine("Producto vendidos:  ");
                    foreach (var PV in productosVendidos)
                    {
                        Console.WriteLine("id: " + PV.Id);
                        Console.WriteLine("Stock: " + PV.Stock);
                        Console.WriteLine("Id del producto: " + PV.IdProducto);
                        Console.WriteLine("Id de la venta: " + PV.IdVenta);
                        Console.WriteLine("Descripciones: " + PV.Descripciones);
                        Console.WriteLine("Costo: " + PV.Costo);
                        Console.WriteLine("Precio de venta: " + PV.PrecioVenta);
                        Console.WriteLine("Id del usuario: " + PV.IdUsuario);

                        Console.WriteLine("--------------");
                    }
                    

                }
                else
                {
                    Console.WriteLine("No hay productos vendidos con el id del producto ingresado");
                }

                reader.Close();

            }
        }

    }
}
