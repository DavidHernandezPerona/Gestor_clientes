namespace Gestor_clientes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Cliente cliente1 = new Cliente(1, "David", "Hernández", "600123456", "david@mail.com", DateTime.Now);
            Console.WriteLine(cliente1);
        }
    }
}