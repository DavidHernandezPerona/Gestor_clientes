namespace Gestor_clientes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Cliente> clientes = new List<Cliente>();
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
                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine();

                        Console.Write("Apellidos: ");
                        string apellidos = Console.ReadLine();

                        Console.Write("Teléfono: ");
                        string telefono = Console.ReadLine();

                        Console.Write("Email: ");
                        string email = Console.ReadLine();

                        Cliente nuevoCliente = new Cliente(clientes.Count + 1, nombre, apellidos, telefono, email, DateTime.Now);
                        clientes.Add(nuevoCliente);

                        Console.WriteLine("Cliente añadido correctamente.");
                        break;

                    case "2":
                        if (clientes.Count == 0)
                        {
                            Console.WriteLine("No hay clientes registrados");
                        }
                        else
                        {
                            foreach (Cliente c in clientes)
                                Console.WriteLine(c);
                        }
                        break;

                    case "4":
                        Console.Write("Introduce el Id del cliente a eliminar: ");
                        string inputId = Console.ReadLine();
                        int idBuscado = int.Parse(inputId);

                        Cliente clienteAEliminar = null;
                        foreach (Cliente c in clientes)
                        {
                            if (c.Id == idBuscado)
                            {
                                clienteAEliminar = c;
                            }
                        }

                        if (clienteAEliminar == null)
                        {
                            Console.WriteLine("No se ha encontrado ningún cliente con ese Id.");
                        }
                        else
                        {
                            clientes.Remove(clienteAEliminar);
                            Console.WriteLine("Cliente eliminado correctamente.");
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