using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimeraEntrega_ProyectoFinal.Models;
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

        [HttpGet("ObtenerVentasPorIdDeVenta")]
        public ActionResult ObtenerVenta([FromQuery] int idVenta)
        {
            var result = ventaRepository.TraerVentaXIdVenta(idVenta);
            return Ok(result);
        }

        [HttpGet("ObtenerVentasPorIdUsuario")]
        public ActionResult ObtenerProductos([FromQuery] int idUsuario)
        {
            var result = ventaRepository.TraerVentaXIdUsuario(idUsuario);
            return Ok(result);
        }
    }
}
