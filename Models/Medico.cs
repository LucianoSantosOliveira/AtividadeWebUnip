using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoViverBem.Models
{
    public class Medico
    {
        [Key]
        public int IdMedico { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Especialidade { get; set; }
        [Required]
        public string Telefone { get; set; }
        public List<Agendamento> Agendamentos { get; set; }
    }
}
