using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimeraEntrega_ProyectoFinal.Repositories;

namespace PrimeraEntrega_ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InicioSesionController : ControllerBase
    {
        UsuarioRepository inicioSesionSeRepository;

        public InicioSesionController()
        {
            inicioSesionSeRepository = new UsuarioRepository();
        }

        [HttpGet]
        public ActionResult InicioSesion([FromQuery] string NombreUsuario, string Contra)
        {
            var result = inicioSesionSeRepository.InicioDeSesion(NombreUsuario, Contra);

            return Ok(result);
        }
    }
}
