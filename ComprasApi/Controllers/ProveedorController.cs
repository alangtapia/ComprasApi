using ComprasApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComprasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {

        public readonly DbcomprasContext _dbcontext;
        public ProveedorController(DbcomprasContext _context)
        {

            _dbcontext = _context;

        }


        [HttpGet]
        [Route("List")]
        public IActionResult List()
        {
            List<Proveedore> Lista = new List<Proveedore>();

            try
            {
                Lista = _dbcontext.Proveedores.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = Lista });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = Lista });
            }

        }

        [HttpGet]
        [Route("Get/{idProveedor:int}")]
        public IActionResult Get(int idProveedor)
        {
            Proveedore proveedor = _dbcontext.Proveedores.Find(idProveedor);

            if (proveedor == null)
            {
                return BadRequest("Proveedor no encontrado");
            }



            try
            {
                proveedor = _dbcontext.Proveedores.Where(p => p.Id == idProveedor).FirstOrDefault();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = proveedor });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = proveedor });
            }

        }


        [HttpPost]
        [Route("Set")]
        public IActionResult Set([FromBody] Proveedore proveedor)
        {



            try
            {
                _dbcontext.Proveedores.Add(proveedor);
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
        public IActionResult Update([FromBody] Proveedore proveedor)
        {

            Proveedore pd = _dbcontext.Proveedores.Find(proveedor.Id);

            if (pd == null)
            {
                return BadRequest("Proveedor no encontrado");
            }


            try
            {
                pd.CedulaRnc = proveedor.CedulaRnc is null ? pd.CedulaRnc : proveedor.CedulaRnc;
                pd.NombreComercial = proveedor.NombreComercial is null ? pd.NombreComercial : proveedor.NombreComercial;
                pd.Estado = proveedor.Estado is null ? pd.Estado : proveedor.Estado;




                _dbcontext.Proveedores.Update(proveedor);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }

        }

        [HttpDelete]
        [Route("Delete/{idProveedor:int}")]

        public IActionResult Delete(int idProveedor)
        {
            Proveedore pd = _dbcontext.Proveedores.Find(idProveedor);

            if (pd == null)
            {
                return BadRequest("Proveedor no encontrado");
            }


            try
            {


                _dbcontext.Proveedores.Remove(pd);
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
