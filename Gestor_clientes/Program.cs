namespace Gestor_clientes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Cliente cliente1 = new(1, "David", "Hernández", "600123456", "david@mail.com", DateTime.Now);

            List<Cliente> clientes = new();
            clientes.Add(cliente1);

            Cliente cliente2 = new Cliente(2, "Laura", "Gómez", "611987654", "laura@mail.com", DateTime.Now);
            clientes.Add(cliente2);

            foreach (Cliente c in clientes)
            {
                Console.WriteLine(c);
            }

            Console.WriteLine($"La lista tiene {clientes.Count} cliente(s).");
        }
    }
}