using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preentrega_proyecto
{
    public class Producto
    {
        public int Id { get; set; }
        public string Descripciones { get; set; }
        public double Costo { get; set; }
        public double PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int IdUsuario { get; set; }

        public Producto()
        {
            Id = 0;
            Descripciones = string.Empty;
            Costo = 0;
            PrecioVenta = 0;
            Stock = 0;
            IdUsuario = 0;
        }

        public void TraerProducto(List<Producto> productos, int IdUsuario)
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
                cmd.CommandText = "select * from producto where IdUsuario = @idUser";

                var param = new SqlParameter("idUser", SqlDbType.BigInt);
                param.Value = IdUsuario;

                cmd.Parameters.Add(param);
                

                var reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Producto produc = new Producto();

                    produc.Id = Convert.ToInt32(reader.GetValue(0));
                    produc.Descripciones = reader.GetValue(1).ToString();
                    produc.Costo = Convert.ToDouble(reader.GetValue(2));
                    produc.PrecioVenta = Convert.ToDouble(reader.GetValue(3));
                    produc.Stock = Convert.ToInt32(reader.GetValue(4));
                    produc.IdUsuario = Convert.ToInt32(reader.GetValue(5));

                    productos.Add(produc);

                }

                if(productos.Count >=1)
                {
                    Console.WriteLine("Productos:  ");
                    foreach (var produc in productos)
                    {
                        Console.WriteLine("id: " + produc.Id);
                        Console.WriteLine("Descripciones:" + produc.Descripciones);
                        Console.WriteLine("Costo:" + produc.Costo);
                        Console.WriteLine("PrecioVenta: " + produc.PrecioVenta);
                        Console.WriteLine("Stock: " + produc.Stock);
                        Console.WriteLine("IdUsuario: " + produc.IdUsuario);

                        Console.WriteLine("--------------");

                    }
                }
                else
                {
                    Console.WriteLine("No hay productos con el id del usuario ingresado");
                }
                

                reader.Close();

            }
        }
    }
}
