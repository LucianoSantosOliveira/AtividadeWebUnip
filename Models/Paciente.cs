using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoViverBem.Models
{
    public class Paciente
    {
        [Key]
        public int IdPaciente { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Telefone { get; set; }
        public List<Agendamento> Agendamentos { get; set; }
    }
}
