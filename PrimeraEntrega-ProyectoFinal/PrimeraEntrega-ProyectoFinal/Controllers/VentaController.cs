using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimeraEntrega_ProyectoFinal.Repositories;

namespace PrimeraEntrega_ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        VentaRepository ventaRepository;

        public VentaController()
        {
            ventaRepository = new VentaRepository();
        }

        [HttpGet]
        public ActionResult ObtenerVenta([FromQuery] int idVenta)
        {
            var result = ventaRepository.TraerVenta(idVenta);
            return Ok(result);
        }
    }
}
