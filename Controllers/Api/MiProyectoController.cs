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
        var client = new MongoClient(CadenasConexion.MONGO_DB);
        var database = client.GetDatabase("Escuela_Angelina_Rogelio");
        var collection = database.GetCollection<Equipo>("Equipo");

        var filter = FilterDefinition<Equipo>.Empty;
        var item = collection.Find(filter).FirstOrDefault();

        return Ok(item);
        
    }
}

