namespace Gestor_clientes
{
    public class Cliente
    {
        private int id;
        private string nombre;
        private string apellidos;
        private string telefono;
        private string email;
        private DateTime fechaAlta;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre no puede estar vacio");
                nombre = value;
            }
        }

        public string Apellidos
        {
            get { return apellidos; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El apellido no puede estar vacio");
                apellidos = value;
            }
        }

        public string Telefono
        {
            get { return telefono; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El teléfono no puede estar vacio");
                telefono = value;
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
                    throw new ArgumentException("El email no puede estar vacio o no es válido");
                email = value;
            }
        }

        public DateTime FechaAlta
        {
            get { return fechaAlta; }
            set { fechaAlta = value; }
        }

        public Cliente(int id, string nombre, string apellidos, string telefono, string email, DateTime fechaAlta)
        {
            Id = id;
            Nombre = nombre;
            Apellidos = apellidos;
            Telefono = telefono;
            Email = email;
            FechaAlta = fechaAlta;
        }

        public override string ToString()
        {
            return $"[{Id}] {Nombre} {Apellidos} | Tel: {Telefono} | Email: {Email} | Alta: {FechaAlta:dd/MM/yyyy}";
        }
    }
}