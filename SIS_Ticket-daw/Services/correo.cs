namespace SIS_Ticket_daw.Services
{
    public class correo
    {
        private IConfiguration _configuration;

        public correo(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Enviar(string destinatario, string asunto, string cuerpo)
        {
            try
            {
                string connectionString = _configuration.GetSection("ConnectionStrings").GetSection("GestionTicketsDB").Value;

                string sqlQuery = "";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener la cadena de conexión: " + ex.Message);
            }
        }
    }
}
