using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("mi-proyecto")]
public class MiProyectoController : ControllerBase
{
   

    [HttpGet("integrantes")]
    public IActionResult Integrantes()
    {
        var proyecto = new MiProyecto
        {
            NombreIntegrante1 = "Angelina Martínez García",
            NombreIntegrante2 = "Rogelio Sánchez Barrón "
        };

        return Ok(proyecto);
    }

    [HttpGet("presentacion")]
    public IActionResult Presentacion()
    {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Escuela_Angelina_Rogelio");
        var collection = db.GetCollection<Equipo>("Equipo");

        var lista = collection.Find(FilterDefinition<Equipo>.Empty).ToList();

        return Ok(lista);
        
    }
}

