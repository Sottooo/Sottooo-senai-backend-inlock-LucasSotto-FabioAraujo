using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    public class JogosDomain
    {
        public int IdJogo { get; set; }

        [Required]
        public string NomeJogo { get; set; }

        public string Descricao { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }

        [Required]
        public float Valor { get; set; }

        [Required]
        public int IdEstudio { get; set; }

        public EstudioDomain Estudio { get; set; }
    }
}
