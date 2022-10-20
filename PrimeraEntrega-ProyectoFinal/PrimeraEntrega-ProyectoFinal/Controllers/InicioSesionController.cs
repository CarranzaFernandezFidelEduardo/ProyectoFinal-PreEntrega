using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimeraEntrega_ProyectoFinal.Repositories;

namespace PrimeraEntrega_ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InicioSesionController : ControllerBase
    {
        InicioSesionRepository inicioSesionRepository;

        public InicioSesionController()
        {
            inicioSesionRepository = new InicioSesionRepository();
        }

        [HttpGet]
        public ActionResult InicioSesion([FromQuery] string NombreUsuario, string Contra)
        {
            var result = inicioSesionRepository.InicioDeSesion(NombreUsuario, Contra);
            return Ok(result);
        }
    }
}
