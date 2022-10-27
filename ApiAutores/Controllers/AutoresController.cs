using ApiAutores.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiAutores.Controllers
{
    [ApiController] // Permite hacer validaciones automaticas
    [Route("api/autores")] // Ruta base de controlador
    public class AutoresController : ControllerBase
    {
        /// <summary>
        /// Se injecta y se crea la propiedad del contexto
        /// </summary>
        private readonly ApplicationDbContext context;
        public AutoresController(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Obtener El listado de autores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Autor>>> Get()
        {
            return await context.Autores.ToListAsync();
        }

        /// <summary>
        /// Creación de autore
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post(Autor autor) // Los argumentos se deben manejar con DTO
        {
            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok();
        }


        /// <summary>
        /// Actualizar Autor dado el id
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Autor autor, int id) // Los argumentos se deben manejar con DTO
        {
            if (autor.Id != id)
            {
                return BadRequest("El id de la URL, no coincide con el autor del body");
            }

            context.Update(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        /// <summary>
        /// Eliminar un autor dado un Id
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await context.Autores.AnyAsync(a => a.Id == id);
            if (!exist)
            {
                return NotFound("El id del autor no existe");
            }
            context.Remove(new Autor() { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }

        //[HttpGet]
        //public ActionResult<List<Autor>> Get()
        //{
        //    return new List<Autor>()
        //    {
        //        new Autor(){Id = 1, Nombre = "Autor 1"  },
        //        new Autor(){Id = 2, Nombre = "Autor 2"  },
        //    };
        //}


    }
}
