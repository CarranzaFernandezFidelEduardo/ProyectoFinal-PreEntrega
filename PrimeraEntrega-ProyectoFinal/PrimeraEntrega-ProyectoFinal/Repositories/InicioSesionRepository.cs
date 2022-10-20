using PrimeraEntrega_ProyectoFinal.Models;
using System.Data.SqlClient;
using System.Data;

namespace PrimeraEntrega_ProyectoFinal.Repositories
{
    public class InicioSesionRepository
    {
        public List<Usuario> InicioDeSesion(string NombreUsuario, string Contra)
        {

            var listaUsuario = new List<Usuario>();

            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "DESKTOP-KU34FRJ\\MSSSQLSERVER";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;

            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM usuario WHERE NombreUsuario = @NombreUser AND Contraseña = @Pass";

                var param = new SqlParameter("NombreUser", SqlDbType.VarChar);
                param.Value = NombreUsuario;

                var param2 = new SqlParameter("Pass", SqlDbType.VarChar);
                param2.Value = Contra;

                cmd.Parameters.Add(param);
                cmd.Parameters.Add(param2);

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Usuario usuario = new Usuario();

                        usuario.Id = Convert.ToInt32(reader.GetValue(0));
                        usuario.Nombre = reader.GetValue(1).ToString();
                        usuario.Apellido = reader.GetValue(2).ToString();
                        usuario.NombreUsuario = reader.GetValue(3).ToString();
                        usuario.Password = reader.GetValue(4).ToString();
                        usuario.Mail = reader.GetValue(5).ToString();

                        listaUsuario.Add(usuario);

                    }
                }
                else
                {
                    Usuario usuario = new Usuario();

                    usuario.Id = 0;
                    usuario.Nombre = string.Empty;
                    usuario.Apellido = string.Empty;
                    usuario.NombreUsuario = string.Empty;
                    usuario.Password = string.Empty;
                    usuario.Mail = string.Empty;

                    listaUsuario.Add(usuario);
                }
               

                reader.Close();

                return listaUsuario;

            }
        }
    }
}
