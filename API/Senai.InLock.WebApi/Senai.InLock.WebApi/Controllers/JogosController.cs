using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repository;

namespace Senai.InLock.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private IJogosRepository _jogosRepository { get; set; }

        public JogosController()
        {
            _jogosRepository = new JogosRepository();
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Cadastrar(JogosDomain jogoCadastrado)
        {
            if (jogoCadastrado != null)
            {

                _jogosRepository.CadastrarJogo(jogoCadastrado);
                return StatusCode(201, "Jogo cadastrado");

            }
            return StatusCode(400, "Jogo nao cadastrado");
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<JogosDomain> Listar()
        {
            return _jogosRepository.ListarJogos();
        }
    }
}