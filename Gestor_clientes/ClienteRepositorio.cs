using Microsoft.Data.SqlClient;

namespace Gestor_clientes
{
    public class ClienteRepositorio
    {
        private List<Cliente> clientes = new List<Cliente>();
        private string cadenaConexion = "Server=.\\SQLEXPRESS;Database=Gestor_clientes;Trusted_Connection=True;TrustServerCertificate=True;";

        public void Agregar(Cliente cliente)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                string consulta = "INSERT INTO Clientes (Nombre, Apellidos, Telefono, Email, FechaAlta) VALUES (@Nombre, @Apellidos, @Telefono, @Email, @FechaAlta)";

                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                comando.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                comando.Parameters.AddWithValue("@Email", cliente.Email);
                comando.Parameters.AddWithValue("@FechaAlta", cliente.FechaAlta);

                comando.ExecuteNonQuery();
            }
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