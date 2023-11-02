using ComprasApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComprasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenDeCompraController : ControllerBase
    {
        public readonly DbcomprasContext _dbcontext;
        public OrdenDeCompraController(DbcomprasContext _context)
        {

            _dbcontext = _context;

        }


        [HttpGet]
        [Route("List")]
        public IActionResult List()
        {
            List<OrdenesDeCompra> Lista = new List<OrdenesDeCompra>();

            try
            {
                Lista = _dbcontext.OrdenesDeCompras.Include(c => c.oUnidad).Include(c => c.oArticulo).ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = Lista });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = Lista });
            }

        }

        [HttpGet]
        [Route("Get/{idOrdenDeCompra:int}")]
        public IActionResult Get(int idOrdenDeCompra)
        {
            OrdenesDeCompra orden = _dbcontext.OrdenesDeCompras.Find(idOrdenDeCompra);

            if (orden == null)
            {
                return BadRequest("Orden de compra no encontrada");
            }



            try
            {
                orden = _dbcontext.OrdenesDeCompras.Include(c => c.oUnidad).Include(c => c.oArticulo).Where(p => p.Id == idOrdenDeCompra).FirstOrDefault();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = orden });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = orden });
            }

        }


        [HttpPost]
        [Route("Set")]
        public IActionResult Set([FromBody] OrdenesDeCompra orden)
        {



            try
            {
                _dbcontext.OrdenesDeCompras.Add(orden);
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
        public IActionResult Update([FromBody] OrdenesDeCompra orden)
        {

            OrdenesDeCompra oc = _dbcontext.OrdenesDeCompras.Find(orden.Id);

            if (oc == null)
            {
                return BadRequest("Orden de compra no encontrada");
            }


            try
            {
                oc.FechaDeOrden = orden.FechaDeOrden is null ? oc.FechaDeOrden : orden.FechaDeOrden;
                oc.Estado = orden.Estado is null ? oc.Estado : orden.Estado;
                oc.Articulo = orden.Articulo is null ? oc.Articulo : orden.Articulo;
                oc.Cantidad = orden.Cantidad is null ? oc.Cantidad : orden.Cantidad;
                oc.UnidadDeMedida = orden.UnidadDeMedida is null ? oc.UnidadDeMedida : orden.UnidadDeMedida;
                oc.CostoUnitario = orden.CostoUnitario is null ? oc.CostoUnitario : orden.CostoUnitario;






                _dbcontext.OrdenesDeCompras.Update(orden);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }

        }

        [HttpDelete]
        [Route("Delete/{idOrdenDeCompra:int}")]

        public IActionResult Delete(int idOrdenDeCompra)
        {
            OrdenesDeCompra oc = _dbcontext.OrdenesDeCompras.Find(idOrdenDeCompra);

            if (oc == null)
            {
                return BadRequest("Orden de compra no encontrada");
            }


            try
            {


                _dbcontext.OrdenesDeCompras.Remove(oc);
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
