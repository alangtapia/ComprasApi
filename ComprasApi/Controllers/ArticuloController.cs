using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ComprasApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;

namespace ComprasApi.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        public readonly DbcomprasContext _dbcontext;
        public ArticuloController(DbcomprasContext _context)
        {

            _dbcontext = _context;

        }


        [HttpGet]
        [Route("List")]        
        public IActionResult List() { 
        List<Articulo> Lista = new List<Articulo>();

            try {
                Lista = _dbcontext.Articulos.Include(c => c.oUnidad).ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = Lista });
            }
            catch (Exception ex) {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = Lista });
                    }
        
        }

        [HttpGet]
        [Route("Get/{idArticulo:int}")]
        public IActionResult Get(int idArticulo)
        {
            Articulo articulo = _dbcontext.Articulos.Find(idArticulo);

            if (articulo == null)
            {
                return BadRequest("Articulo no encontrado");
            }



            try
            {
                articulo = _dbcontext.Articulos.Include(c => c.oUnidad).Where(p => p.Id == idArticulo).FirstOrDefault();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = articulo });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = articulo });
            }

        }


        [HttpPost]
        [Route("Set")]
        public IActionResult Set([FromBody] Articulo articulo)
        {
         


            try
            {
                _dbcontext.Articulos.Add(articulo);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok"});
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }

        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] Articulo articulo)
        {

            Articulo ar = _dbcontext.Articulos.Find(articulo.Id);

            if (ar == null)
            {
                return BadRequest("Articulo no encontrado");
            }


            try
            {
                ar.UnidadDeMedida = articulo.UnidadDeMedida is null ? ar.UnidadDeMedida : articulo.UnidadDeMedida ;
                ar.Descripcion = articulo.Descripcion is null ? ar.Descripcion : articulo.Descripcion;
                ar.Marca = articulo.Marca is null ? ar.Marca : articulo.Marca;
                ar.Estado = articulo.Estado is null ? ar.Estado : articulo.Estado;
                ar.Existencia = articulo.Existencia is null ? ar.Existencia : articulo.Existencia;



                _dbcontext.Articulos.Update(articulo);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }

        }

        [HttpDelete]
        [Route("Delete/{idArticulo:int}")]

        public IActionResult Delete (int idArticulo)
        {
            Articulo ar = _dbcontext.Articulos.Find(idArticulo);

            if (ar == null)
            {
                return BadRequest("Articulo no encontrado");
            }


            try
            {
             

                _dbcontext.Articulos.Remove(ar);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }


        }

    }
}
