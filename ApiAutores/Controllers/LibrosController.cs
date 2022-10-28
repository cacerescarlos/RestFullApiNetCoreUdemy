using ApiAutores.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiAutores.Controllers
{
    [ApiController]
    [Route("api/libros")]
    public class LibrosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public LibrosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Libro>>> Get()
        {
            var result = await context.Libros.Include(x => x.Autor).ToListAsync(); 
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Libro>> Get(int id)
        {
            var result = await context.Libros.Include(x=>x.Autor).FirstOrDefaultAsync(item => item.Id == id);

            if (result is null)
            {
                return BadRequest("No se encontro registro");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Libro libro)
        {
            var existAutor = await context.Autores.AnyAsync(item => item.Id== libro.AutorId);

            if (!existAutor)
            {
                return BadRequest("No existe el autor");
            }

            //context.Libros.Add(libro);//Por que no asi?
            context.Add(libro);
            await context.SaveChangesAsync();
            return Ok();
        }
        /// <summary>
        /// No found
        /// </summary>
        //[HttpPut("{id:int}")]
        //public async Task<ActionResult> Put(Libro libro, int id)
        //{
        //    var exists = FindById(id);

        //    if (exists is null)
        //    {
        //        return BadRequest("No se encontro registro para actualizar");
        //    }
        //    context.Libros.Update(libro);
        //    await context.SaveChangesAsync();
        //    return Ok();
        //}

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Libro>> Delete(int id)
        {
            var libro = FindById(id);

            if (libro is null)
            {
                return BadRequest("No se encontro registro para actualizar");
            }
            context.Libros.Remove(libro);
            //context.Remove(new Autor() { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }

        private Libro FindById(int id)
        {
            //return context.Libros.Where(item => item.Id == id).FirstOrDefault();
            return context.Libros.FirstOrDefault(item => item.Id == id);
        }


    }
}
