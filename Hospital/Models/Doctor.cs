using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Hospital.Models
{
    public class Doctor
    {
        [Key]
        public int ID { get; set; }
        public string Especialidad { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;

        [JsonIgnore]
        public virtual ICollection<Consulta>? Consultas { get; set; }
    }
}
