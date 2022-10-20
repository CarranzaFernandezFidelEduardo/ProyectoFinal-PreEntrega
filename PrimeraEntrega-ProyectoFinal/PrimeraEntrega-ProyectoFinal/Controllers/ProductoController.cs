using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimeraEntrega_ProyectoFinal.Repositories;

namespace PrimeraEntrega_ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        ProductoRepository productoRepository;

        public ProductoController()
        {
            productoRepository = new ProductoRepository();
        }

        [HttpGet("ObtenerProducto")]
        public ActionResult ObtenerProducto([FromQuery] int IdUsuario)
        {
            var result = productoRepository.TraerProducto(IdUsuario);
            return Ok(result);
        }

        [HttpGet("ObtenerProductos")]
        public ActionResult ObtenerProductos()
        {
            var result = productoRepository.TraerProductos();
            return Ok(result);
        }
    }
}
