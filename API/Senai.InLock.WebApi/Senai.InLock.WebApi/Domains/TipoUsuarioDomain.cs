﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    public class TipoUsuarioDomain
    {
        public int IdTipoUsuario { get; set; }

        [Required]
        public string Titulo { get; set; }
    }
}
