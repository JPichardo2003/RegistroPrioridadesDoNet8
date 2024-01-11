using System.ComponentModel.DataAnnotations;

namespace RegistroPrioridadesDoNet8.Models
{
    public class Prioridades
    {
        [Key]
        public int PrioridadId { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? Descripción { get; set; }
        [Range(1, 31, ErrorMessage = "Valores Validos entre 1 y 31")]
        public int DiasCompromiso { get; set; }
    }
}
