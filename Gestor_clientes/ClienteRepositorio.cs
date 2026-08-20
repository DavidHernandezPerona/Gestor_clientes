namespace Gestor_clientes
{
    public class ClienteRepositorio
    {
        private List<Cliente> clientes = new List<Cliente>();

        public void Agregar(Cliente cliente)
        {
            clientes.Add(cliente);
        }

        public List<Cliente> Listar()
        {
            return clientes;
        }

        public Cliente Buscar(int id)
        {
            Cliente clienteEncontrado = null;
            foreach (Cliente c in clientes)
            {
                if (c.Id == id)
                {
                    clienteEncontrado = c;
                }
            }
            return clienteEncontrado;
        }

        public bool Eliminar(int id)
        {
            Cliente cliente = Buscar(id);
            if (cliente == null)
            {
                return false;
            }
            clientes.Remove(cliente);
            return true;
        }

        public bool Modificar(int id, string nombre, string apellidos, string telefono, string email)
        {
            Cliente cliente = Buscar(id);
            if (cliente == null)
            {
                return false;
            }
            cliente.Nombre = nombre;
            cliente.Apellidos = apellidos;
            cliente.Telefono = telefono;
            cliente.Email = email;
            return true;
        }
    }
}