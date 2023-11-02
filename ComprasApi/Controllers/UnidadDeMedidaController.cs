using ComprasApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComprasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadDeMedidaController : ControllerBase
    {


        public readonly DbcomprasContext _dbcontext;
        public UnidadDeMedidaController(DbcomprasContext _context)
        {

            _dbcontext = _context;

        }


        [HttpGet]
        [Route("List")]
        public IActionResult List()
        {
            List<UnidadesDeMedidum> Lista = new List<UnidadesDeMedidum>();

            try
            {
                Lista = _dbcontext.UnidadesDeMedida.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = Lista });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = Lista });
            }

        }

        [HttpGet]
        [Route("Get/{idUnidadDeMedida:int}")]
        public IActionResult Get(int idUnidadDeMedida)
        {
            UnidadesDeMedidum unidad = _dbcontext.UnidadesDeMedida.Find(idUnidadDeMedida);

            if (unidad == null)
            {
                return BadRequest("Unidad de medida no encontrada");
            }



            try
            {
                unidad = _dbcontext.UnidadesDeMedida.Where(p => p.Id == idUnidadDeMedida).FirstOrDefault();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = unidad });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = unidad });
            }

        }


        [HttpPost]
        [Route("Set")]
        public IActionResult Set([FromBody] UnidadesDeMedidum unidad)
        {



            try
            {
                _dbcontext.UnidadesDeMedida.Add(unidad);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }

        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] UnidadesDeMedidum unidad)
        {

            UnidadesDeMedidum ud = _dbcontext.UnidadesDeMedida.Find(unidad.Id);

            if (ud == null)
            {
                return BadRequest("Unidad de medida no encontrada");
            }


            try
            {
                ud.Descripcion = unidad.Descripcion is null ? ud.Descripcion : unidad.Descripcion;
                ud.Estado = unidad.Estado is null ? ud.Estado : unidad.Estado;




                _dbcontext.UnidadesDeMedida.Update(unidad);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }

        }

        [HttpDelete]
        [Route("Delete/{idUnidadDeMedida:int}")]

        public IActionResult Delete(int idUnidadDeMedida)
        {
            UnidadesDeMedidum ud = _dbcontext.UnidadesDeMedida.Find(idUnidadDeMedida);

            if (ud == null)
            {
                return BadRequest("Unidad de medida no encontrada");
            }


            try
            {


                _dbcontext.UnidadesDeMedida.Remove(ud);
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
