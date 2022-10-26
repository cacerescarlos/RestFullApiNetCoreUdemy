using ApiAutores.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace ApiAutores.Controllers
{
    [ApiController] // Permite hacer validaciones automaticas
    [Route("api/autores")] // Ruta base de controlador
    public class AutoresController: ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Autor>> Get()
        {
            return new List<Autor>()
            { 
                new Autor(){Id = 1, Nombre = "Autor 1"  },
                new Autor(){Id = 2, Nombre = "Autor 2"  },
            };
                ;
        }

    }
}
