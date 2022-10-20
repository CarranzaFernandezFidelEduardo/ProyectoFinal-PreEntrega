using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimeraEntrega_ProyectoFinal.Repositories;

namespace PrimeraEntrega_ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        ProductoVendidoRepository productoVendidoRepository;

        public ProductoVendidoController()
        {
            productoVendidoRepository = new ProductoVendidoRepository();
        }

        [HttpGet]
        public ActionResult ObtenerProductoVendido()
        {
            var result = productoVendidoRepository.TraerProductoVendido();
            return Ok(result);
        }



    }
}
