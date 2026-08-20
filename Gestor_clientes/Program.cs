namespace Gestor_clientes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ClienteRepositorio repositorio = new ClienteRepositorio();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n--- Gestor de Clientes ---");
                Console.WriteLine("1. Alta de cliente");
                Console.WriteLine("2. Listar clientes");
                Console.WriteLine("3. Modificar cliente");
                Console.WriteLine("4. Baja de cliente");
                Console.WriteLine("5. Salir");
                Console.Write("Elige una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        try
                        {
                            Console.Write("Nombre: ");
                            string nombre = Console.ReadLine();

                            Console.Write("Apellidos: ");
                            string apellidos = Console.ReadLine();

                            Console.Write("Teléfono: ");
                            string telefono = Console.ReadLine();

                            Console.Write("Email: ");
                            string email = Console.ReadLine();

                            Cliente nuevoCliente = new Cliente(repositorio.Listar().Count + 1, nombre, apellidos, telefono, email, DateTime.Now);
                            repositorio.Agregar(nuevoCliente);

                            Console.WriteLine("Cliente añadido correctamente.");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Error en los datos: {ex.Message}");
                        }
                        break;

                    case "2":
                        List<Cliente> listaClientes = repositorio.Listar();
                        if (listaClientes.Count == 0)
                        {
                            Console.WriteLine("No hay clientes registrados.");
                        }
                        else
                        {
                            foreach (Cliente c in listaClientes)
                            {
                                Console.WriteLine(c);
                            }
                        }
                        break;

                    case "3":
                        try
                        {
                            Console.Write("Introduce el Id del cliente a modificar: ");
                            string inputIdMod = Console.ReadLine();
                            int idBuscadoMod = int.Parse(inputIdMod);

                            Console.Write("Nuevo nombre: ");
                            string nuevoNombre = Console.ReadLine();

                            Console.Write("Nuevos apellidos: ");
                            string nuevoApellidos = Console.ReadLine();

                            Console.Write("Nuevo teléfono: ");
                            string nuevoTelefono = Console.ReadLine();

                            Console.Write("Nuevo email: ");
                            string nuevoEmail = Console.ReadLine();

                            bool modificado = repositorio.Modificar(idBuscadoMod, nuevoNombre, nuevoApellidos, nuevoTelefono, nuevoEmail);

                            if (modificado)
                            {
                                Console.WriteLine("Cliente modificado correctamente.");
                            }
                            else
                            {
                                Console.WriteLine("No se ha encontrado ningún cliente con ese Id.");
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Debes introducir un número válido de Id.");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Error en los datos: {ex.Message}");
                        }
                        break;

                    case "4":
                        try
                        {
                            Console.Write("Introduce el Id del cliente a eliminar: ");
                            string inputId = Console.ReadLine();
                            int idBuscado = int.Parse(inputId);

                            bool eliminado = repositorio.Eliminar(idBuscado);

                            if (eliminado)
                            {
                                Console.WriteLine("Cliente eliminado correctamente.");
                            }
                            else
                            {
                                Console.WriteLine("No se ha encontrado ningún cliente con ese Id.");
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Debes introducir un número válido de Id.");
                        }
                        break;

                    case "5":
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
}