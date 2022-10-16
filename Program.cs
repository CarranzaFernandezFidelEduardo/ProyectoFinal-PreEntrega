using Preentrega_proyecto;
using System.Data.SqlClient;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {

        var listaProductos = new List<Producto>();
        var listaUsuarios = new List<Usuario>();
        var listaVentas = new List<Venta>();
        var listProductosVendidos = new List<ProductoVendido>();

        Producto producto1 = new Producto();
        Usuario usuario1 = new Usuario();
        Venta venta1 = new Venta();
        ProductoVendido productoVendido = new ProductoVendido();

        bool indice = true;

        do
        {
            Console.WriteLine("\nSeleccione una opción:");
            Console.WriteLine("1. Traer Usuario");
            Console.WriteLine("2. Traer Producto");
            Console.WriteLine("3. Traer Producto Vendido");
            Console.WriteLine("4. Traer Venta");
            Console.WriteLine("5. Iniciar Sesión");
            Console.WriteLine("6. Salir");

            Console.Write("\nElija una opción: ");
            byte opcion = Convert.ToByte(Console.ReadLine());

            switch (opcion)
            {
                case 1:

                    Console.WriteLine("Ingrese el nombre de usuario:");
                    string nombreUsuario = Console.ReadLine();

                    usuario1.TraerUsuario(listaUsuarios, nombreUsuario);

                    listaUsuarios.Clear();

                    indice = true;

                    break;
                case 2:

                    Console.WriteLine("Ingrese el id del usuario: ");
                    int idUsuario = Convert.ToInt32(Console.ReadLine());

                    producto1.TraerProducto(listaProductos, idUsuario);

                    listaProductos.Clear();

                    indice = true;

                    break;
                case 3:

                    Console.WriteLine("Ingrese el id del producto: ");
                    int IdProducto = Convert.ToInt32(Console.ReadLine());

                    productoVendido.TraerProductoVendido(listProductosVendidos, IdProducto);

                    listProductosVendidos.Clear();

                    indice =true;

                    break;
                case 4:

                    Console.WriteLine("Ingrese el id del usuario:");
                    int idUsuario2 = Convert.ToInt32(Console.ReadLine());

                    venta1.TraerVenta(listaVentas, idUsuario2);

                    listaVentas.Clear();

                    indice = true;

                    break;
                case 5:

                    Console.WriteLine("Ingrese el nombre de usuario:");
                    string nombreUsuario2 = Console.ReadLine();

                    Console.WriteLine("Ingrese la contraseña");
                    string contraseña = Console.ReadLine();

                    usuario1.InicioSesion(listaUsuarios, nombreUsuario2, contraseña);

                    listaUsuarios.Clear();

                    indice = true;
                    break;
                case 6:

                    indice = false;

                    break;
            }

        } while (indice == true);

    }

}