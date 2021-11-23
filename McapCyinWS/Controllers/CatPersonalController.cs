using McapCyinWS.DataAccess;
using McapCyinWS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace McapCyinWS.Controllers
{
    /// <summary>
    /// Controlador que se comunica entre las solicitudes GET Y POST 
    /// y las operaciones SELECT e INSERT
    /// jogonzalez
    /// 2021-11-22
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CatPersonalController : ControllerBase
    {
        /// <summary>
        /// Objeto de acceso a datos
        /// </summary>
        private readonly IDataAccessProvider _dataAccessProvider;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dataAccessProvider"></param>
        public CatPersonalController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        /// <summary>
        /// Metodo GET que regresa todos los registros de la tabla catPersonal
        /// http://ec2-3-13-229-174.us-east-2.compute.amazonaws.com/api/catPersonal/
        /// </summary>
        /// <returns>Todos los registros de la tabla catpersonal</returns>
        [HttpGet]
        public async Task<ActionResult<List<CatPersonal>>> Get()
        {
            return await _dataAccessProvider.GetPersonal();
        }

        /// <summary>
        /// Metodo GET que regresa un registro de la tabla buscado por id
        /// http://ec2-3-13-229-174.us-east-2.compute.amazonaws.com/api/catPersonal/<id>
        /// </summary>
        /// <param name="id">ID a buscar</param>
        /// <returns>
        /// Registro de la tabla catPersonal encontrado por id.
        /// Status Code 204 si no se encuentra infromación
        /// </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CatPersonal>> GetById(int id)
        {
            var catPersonal = await _dataAccessProvider.GetPersonalById(id);
            if (catPersonal.Value != null)
            {
                return catPersonal; 
            }
            else
            {
                return StatusCode((int) HttpStatusCode.NoContent);
            }
        }

        /// <summary>
        /// Metodo GET que regresa una lista de registros de la tabla buscado por nombre        /// 
        /// http://ec2-3-13-229-174.us-east-2.compute.amazonaws.com/api/catPersonal/SearchByName/?name=<nombre>
        /// </summary>
        /// <param name="name">Nombre a buscar</param>
        /// <returns>
        /// Lista de registros de la tabla catPersonal encontrados por nombre que contienen el nombre a buscar
        /// Status Code 204 si no se encuentra algun recurso
        /// </returns>
        [HttpGet]
        [Route("SearchByName")]
        public async Task<ActionResult<List<CatPersonal>>> GetByName(string name)
        {
            var list = await _dataAccessProvider.GetPersonalByName(name);
            if(list.Value != null && list.Value.Count > 0)
            {
                return list;
            }
            else
            {
                return StatusCode((int) HttpStatusCode.NoContent);
            }
        }

        /// <summary>
        /// Metodo POST para un nuevo registro en la tabla catPersonal
        /// httprepl http://ec2-3-13-229-174.us-east-2.compute.amazonaws.com/api/catPersonal/
        /// post -h Content-Type=application/json -c "{"nombre":"<nombre>","cargo":"<cargo>"}"
        /// </summary>
        /// <param name="nuevo">Nuevo registro a insertar</param>
        /// <returns>
        /// Status Code 201 en registro éxitoso con el ID del registro creado
        /// Status Code 400 en caso de que no se proporcione un parametro válidos
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<CatPersonal>> Post(CatPersonal nuevo) {
            if (nuevo == null || nuevo.Nombre == null || nuevo.Nombre == "" || nuevo.Cargo == null ||  nuevo.Cargo == "")
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "Se debe especificar un objeto catPersonal con los atributos nombre y cargo");
            }
            var personal = await _dataAccessProvider.CreatePersonal(nuevo);
            return StatusCode((int) HttpStatusCode.Created, personal.Value.Id);
        }
    }
}
