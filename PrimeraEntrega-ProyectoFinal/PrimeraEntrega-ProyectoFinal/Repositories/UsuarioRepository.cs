using PrimeraEntrega_ProyectoFinal.Models;
using System.Data.SqlClient;
using System.Data;

namespace PrimeraEntrega_ProyectoFinal.Repositories
{
    public class UsuarioRepository
    {
        public List<Usuario> TraerUsuario(string NombreUsuario)
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
                cmd.CommandText = "SELECT * FROM usuario WHERE NombreUsuario = @NombreUser";

                var param = new SqlParameter("NombreUser", SqlDbType.VarChar);
                param.Value = NombreUsuario;

                cmd.Parameters.Add(param);

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {

                }

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

                reader.Close();

                return listaUsuario;

            }
        }
    }
}
