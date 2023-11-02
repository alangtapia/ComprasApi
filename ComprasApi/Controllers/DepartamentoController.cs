using ComprasApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComprasApi.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {

        public readonly DbcomprasContext _dbcontext;
        public DepartamentoController(DbcomprasContext _context)
        {

            _dbcontext = _context;

        }


        [HttpGet]
        [Route("List")]
        public IActionResult List()
        {
            List<Departamento> Lista = new List<Departamento>();

            try
            {
                Lista = _dbcontext.Departamentos.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = Lista });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = Lista });
            }

        }

        [HttpGet]
        [Route("Get/{idDepartamento:int}")]
        public IActionResult Get(int idDepartamento)
        {
            Departamento departamento = _dbcontext.Departamentos.Find(idDepartamento);

            if (departamento == null)
            {
                return BadRequest("Departamento no encontrado");
            }



            try
            {
                departamento = _dbcontext.Departamentos.Where(p => p.Id == idDepartamento).FirstOrDefault();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = departamento });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = departamento });
            }

        }


        [HttpPost]
        [Route("Set")]
        public IActionResult Set([FromBody] Departamento departamento)
        {



            try
            {
                _dbcontext.Departamentos.Add(departamento);
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
        public IActionResult Update([FromBody] Departamento departamento)
        {

            Departamento dp = _dbcontext.Departamentos.Find(departamento.Id);

            if (dp == null)
            {
                return BadRequest("Departamento no encontrado");
            }


            try
            {
                dp.Nombre = departamento.Nombre is null ? dp.Nombre : departamento.Nombre;
                dp.Estado = departamento.Estado is null ? dp.Estado : departamento.Estado;




                _dbcontext.Departamentos.Update(departamento);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }

        }

        [HttpDelete]
        [Route("Delete/{idDepartamento:int}")]

        public IActionResult Delete(int idDepartamento)
        {
            Departamento dp = _dbcontext.Departamentos.Find(idDepartamento);

            if (dp == null)
            {
                return BadRequest("Departamento no encontrado");
            }


            try
            {


                _dbcontext.Departamentos.Remove(dp);
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
