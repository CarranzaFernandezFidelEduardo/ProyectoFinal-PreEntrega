using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preentrega_proyecto
{
    public class Venta
    {
        private int Id;
        private string Comentarios;
        private int IdUsuario;

        public Venta()
        {
            Id = 0;
            Comentarios = string.Empty;
            IdUsuario = 0;
        }

        public void TraerVenta(List<Venta> Ventas, int idUsuario)
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
                cmd.CommandText = "SELECT * FROM venta WHERE IdUsuario = @IdUser";

                var param = new SqlParameter("IdUser", SqlDbType.BigInt);
                param.Value = idUsuario;

                cmd.Parameters.Add(param);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Venta venta = new Venta();

                    venta.Id = Convert.ToInt32(reader.GetValue(0));
                    venta.Comentarios = reader.GetValue(1).ToString();
                    venta.IdUsuario = Convert.ToInt32(reader.GetValue(2));

                    Ventas.Add(venta);

                }

                if (Ventas.Count >= 1)
                {
                    Console.WriteLine("Ventas:  ");
                    foreach (var venta in Ventas)
                    {
                        Console.WriteLine("id: " + venta.Id);
                        Console.WriteLine("Comentarios: " + venta.Comentarios);
                        Console.WriteLine("Venta: " + venta.IdUsuario);
                       

                        Console.WriteLine("--------------");

                    }
                }
                else
                {
                    Console.WriteLine("No hay ventas con el id del usuario ingresado");
                }


                reader.Close();

            }
        }
    }

    




    
}
