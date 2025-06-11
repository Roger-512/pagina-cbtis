using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

[ApiController]
[Route("api/usuarios")]
public class UsuariosController : ControllerBase
{
    //Métodos para hacer las operaciones CRUD
    // C = Create
    // R = Read
    // U = Update
    // D = Delete

    private readonly IMongoCollection<Usuario> collection;

    public UsuariosController()
    {
       var client = new MongoClient(CadenasConexion.MONGO_DB);
        var database = client.GetDatabase("Escuela_Angelina_Rogelio");
        this.collection = database.GetCollection<Usuario>("Usuarios");
    }

    [HttpGet]
    public IActionResult ListarUsuarios()
    {
        var filter = FilterDefinition<Usuario>.Empty;
        var list = this.collection.Find(filter).ToList();
        return Ok(list); 
    }
}