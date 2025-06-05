using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("mi-proyecto")]
public class MiProyectoController : ControllerBase {
    
    [HttpGet("integrantes")]
    public IActionResult Integrantes(){
        var proyecto = new MiProyecto
            {
                NombreIntegrante1 = "Angelina Martínez García",
                NombreIntegrante2 = "Rogelio Sánchez Barrón "
            };

        return Ok(proyecto);
    }
}