namespace LightF_API.Models
{
    public class Supervisor
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string IdentificationNumber { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Jurisdiction { get; set; } = string.Empty;
    }
}
