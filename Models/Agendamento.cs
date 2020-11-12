using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoViverBem.Models
{
    public class Agendamento
    {
        [Key]
        public int IdAgendamento { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [ForeignKey("IdMedico")]
        public int IdMedico { get; set; }
        public virtual Medico Medico { get; set; }
        [ForeignKey("IdPaciente")]
        public int IdPaciente { get; set; }
        public virtual Paciente Paciente { get; set; }
    }
}
