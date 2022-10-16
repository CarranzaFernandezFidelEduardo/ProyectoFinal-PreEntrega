using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preentrega_proyecto
{
    public class Usuario
    {
        private int Id;
        private string Nombre;
        private string Apellido;
        private string NombreUsuario;
        private string Password;
        private string Mail;

        public Usuario()
        {
            Id = 0;
            Nombre = string.Empty;
            Apellido = string.Empty;
            NombreUsuario = string.Empty;
            Password = string.Empty;
            Mail = string.Empty;
        }

        public void TraerUsuario(List<Usuario> usuarios, string  NombreUsuario)
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
                cmd.CommandText = "SELECT * FROM usuario WHERE NombreUsuario = @NombreUser";

                var param = new SqlParameter("NombreUser", SqlDbType.VarChar);
                param.Value = NombreUsuario;

                cmd.Parameters.Add(param);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Usuario user = new Usuario();

                    user.Id = Convert.ToInt32(reader.GetValue(0));
                    user.Nombre = reader.GetValue(1).ToString();
                    user.Apellido = reader.GetValue(2).ToString();
                    user.NombreUsuario = reader.GetValue(3).ToString();
                    user.Password = reader.GetValue(4).ToString();
                    user.Mail = reader.GetValue(5).ToString();

                    usuarios.Add(user);

                }

                if (usuarios.Count >= 1)
                {
                    Console.WriteLine("Usuarios:  ");
                    foreach (var usuer in usuarios)
                    {
                        Console.WriteLine("id: " + usuer.Id);
                        Console.WriteLine("Nombre:: " + usuer.Nombre);
                        Console.WriteLine("Apellido: " + usuer.Apellido);
                        Console.WriteLine("Nombre de usuario:" + usuer.NombreUsuario);
                        Console.WriteLine("Contraseña: " + usuer.Password);
                        Console.WriteLine("Mail: " + usuer.Mail);

                        Console.WriteLine("--------------");
                    }
                }
                else
                {
                    Console.WriteLine("No hay informacion con el nombre de usuario ingresado");
                }

                reader.Close();
            }
        }

        public void InicioSesion(List<Usuario> usuarios, string NombreUsuario, string Password)
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
                cmd.CommandText = "SELECT * FROM usuario WHERE NombreUsuario = @NombreUser AND Contraseña = @Pass";

                var param = new SqlParameter("NombreUser", SqlDbType.VarChar);
                param.Value = NombreUsuario;

                var param2 = new SqlParameter("Pass", SqlDbType.VarChar);
                param2.Value = Password;

                cmd.Parameters.Add(param);
                cmd.Parameters.Add(param2);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Usuario user = new Usuario();

                    user.Id = Convert.ToInt32(reader.GetValue(0));
                    user.Nombre = reader.GetValue(1).ToString();
                    user.Apellido = reader.GetValue(2).ToString();
                    user.NombreUsuario = reader.GetValue(3).ToString();
                    user.Password = reader.GetValue(4).ToString();
                    user.Mail = reader.GetValue(5).ToString();

                    usuarios.Add(user);

                }

                if (usuarios.Count >= 1)
                {
                    Console.WriteLine("Usuarios:  ");
                    foreach (var user in usuarios)
                    {
                        Console.WriteLine("id: " + user.Id);
                        Console.WriteLine("Nombre:: " + user.Nombre);
                        Console.WriteLine("Apellido: " + user.Apellido);
                        Console.WriteLine("Nombre de usuario:" + user.NombreUsuario);
                        Console.WriteLine("Contraseña: " + user.Password);
                        Console.WriteLine("Mail: " + user.Mail);

                        Console.WriteLine("--------------");

                    }
                }
                else
                {
                    Console.WriteLine("No hay informacion con el nombre de usuario y la contraseña ingresado ingresado");

                    Console.WriteLine("id: " + 0);
                    Console.WriteLine("Nombre: " + string.Empty);
                    Console.WriteLine("Apellido: " + string.Empty);
                    Console.WriteLine("Nombre de usuario:" + string.Empty);
                    Console.WriteLine("Contraseña: " + string.Empty);
                    Console.WriteLine("Mail: " + string.Empty);

                    Console.WriteLine("--------------");
                    
                }

                reader.Close();

            }

        }

    }
}
