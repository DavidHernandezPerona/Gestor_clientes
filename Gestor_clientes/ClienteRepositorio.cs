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
            List<Cliente> listaClientes = new List<Cliente>();

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                string consulta = "SELECT Id, Nombre, Apellidos, Telefono, Email, FechaAlta FROM Clientes";
                SqlCommand comando = new SqlCommand(consulta, conexion);

                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    int id = lector.GetInt32(0);
                    string nombre = lector.GetString(1);
                    string apellidos = lector.GetString(2);
                    string telefono = lector.GetString(3);
                    string email = lector.GetString(4);
                    DateTime fechaAlta = lector.GetDateTime(5);

                    Cliente cliente = new Cliente(id, nombre, apellidos, telefono, email, fechaAlta);
                    listaClientes.Add(cliente);
                }
            }

            return listaClientes;
        }

        public Cliente Buscar(int id)
        {
            Cliente clienteEncontrado = null;

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                string consulta = "SELECT Id, Nombre, Apellidos, Telefono, Email, FechaAlta FROM Clientes WHERE Id = @Id";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@Id", id);

                SqlDataReader lector = comando.ExecuteReader();

                if (lector.Read())
                {
                    int idLeido = lector.GetInt32(0);
                    string nombre = lector.GetString(1);
                    string apellidos = lector.GetString(2);
                    string telefono = lector.GetString(3);
                    string email = lector.GetString(4);
                    DateTime fechaAlta = lector.GetDateTime(5);

                    clienteEncontrado = new Cliente(idLeido, nombre, apellidos, telefono, email, fechaAlta);
                }
            }

            return clienteEncontrado;
        }

        public bool Eliminar(int id)
        {
            bool eliminado = false;

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                string consulta = "DELETE FROM Clientes WHERE Id = @Id";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@Id", id);

                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    eliminado = true;
                }
            }

            return eliminado;
        }

        public bool Modificar(int id, string nombre, string apellidos, string telefono, string email)
        {
            bool modificado = false;

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                string consulta = "UPDATE Clientes SET Nombre = @Nombre, Apellidos = @Apellidos, Telefono = @Telefono, Email = @Email WHERE Id = @Id";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Apellidos", apellidos);
                comando.Parameters.AddWithValue("@Telefono", telefono);
                comando.Parameters.AddWithValue("@Email", email);
                comando.Parameters.AddWithValue("@Id", id);

                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    modificado = true;
                }
            }

            return modificado;
        }
    }
}