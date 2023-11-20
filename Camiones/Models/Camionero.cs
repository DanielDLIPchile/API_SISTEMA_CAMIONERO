using System;
using System.ComponentModel.DataAnnotations;

namespace Camiones.Models
{
    public class Camionero
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(50)]
        public string ApellidoPaterno { get; set; } = string.Empty;

        [StringLength(50)]
        public string ApellidoMaterno { get; set; } = string.Empty;

        public int Edad { get; set; } = 0;

        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; } = DateTime.MinValue;

        [StringLength(10)]
        public string Genero { get; set; } = string.Empty;

        [StringLength(20)]
        public string EstadoCivil { get; set; } = string.Empty;

        public int NumeroHijos { get; set; } = 0;
    }
}
