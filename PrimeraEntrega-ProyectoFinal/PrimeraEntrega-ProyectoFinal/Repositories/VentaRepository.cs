using PrimeraEntrega_ProyectoFinal.Models;
using System.Data.SqlClient;
using System.Data;

namespace PrimeraEntrega_ProyectoFinal.Repositories
{
    public class VentaRepository
    {
        public List<Venta> TraerVentaXIdVenta(int IdVenta)
        {

            var listaVenta = new List<Venta>();

            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "DESKTOP-KU34FRJ\\MSSSQLSERVER";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;

            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM venta WHERE Id = @idVenta";

                var param = new SqlParameter("idVenta", SqlDbType.Int);
                param.Value = IdVenta;

                cmd.Parameters.Add(param);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Venta venta = new Venta();

                    venta.Id = Convert.ToInt32(reader.GetValue(0));
                    venta.Comentarios = reader.GetValue(1).ToString();
                    venta.IdUsuario = Convert.ToInt32(reader.GetValue(2));

                    listaVenta.Add(venta);

                }

                reader.Close();

                return listaVenta;

            }
        }

        public List<Venta> TraerVentaXIdUsuario(int IdUsuario)
        {

            var listaVenta = new List<Venta>();

            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "DESKTOP-KU34FRJ\\MSSSQLSERVER";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;

            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM venta WHERE IdUsuario = @idUsuario";

                var param = new SqlParameter("idUsuario", SqlDbType.Int);
                param.Value = IdUsuario;

                cmd.Parameters.Add(param);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Venta venta = new Venta();

                    venta.Id = Convert.ToInt32(reader.GetValue(0));
                    venta.Comentarios = reader.GetValue(1).ToString();
                    venta.IdUsuario = Convert.ToInt32(reader.GetValue(2));

                    listaVenta.Add(venta);

                }

                reader.Close();

                return listaVenta;

            }
        }
    }
}
