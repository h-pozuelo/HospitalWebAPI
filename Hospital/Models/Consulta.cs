using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Hospital.Models
{
    public class Consulta
    {
        [Key]
        public int ID { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;

        [JsonIgnore]
        public virtual Doctor? Doctor { get; set; }
        [ForeignKey(nameof(Doctor))]
        public int IdDoctor { get; set; }
        [JsonIgnore]
        public virtual Paciente? Paciente { get; set; }
        [ForeignKey(nameof(Paciente))]
        public int IdPaciente { get; set; }
    }
}
