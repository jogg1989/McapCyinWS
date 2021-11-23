using McapCyinWS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace McapCyinWS.DataAccess
{
    /// <summary>
    /// JOGONZALEZ
    /// Interfaz para interacción del controlador con la base de datos
    /// </summary>
    public interface IDataAccessProvider
    {

        /// <summary>
        /// Realiza un select a toda la tabla catPersonal
        /// </summary>
        /// <returns>Lista con todos los registros de la tabla catPersonal</returns>
        Task<ActionResult<List<CatPersonal>>> GetPersonal();

        /// <summary>
        /// Registro de la tabla catPersonal encontrado por identificador
        /// </summary>
        /// <param name="id">Identificador del registro a buscar</param>
        /// <returns>Registro de la tabla catPersonal</returns>
        Task<ActionResult<CatPersonal>> GetPersonalById(int id);

        /// <summary>
        /// Lista de registros de la tabla catPersonal encontrados por que la cadena a buscar es una subcadena del nombre
        /// </summary>
        /// <param name="name">Cadena que sera subcadena del campo nombre</param>
        /// <returns>Lista de registrso de la tabla catPersonal</returns>
        Task<ActionResult<List<CatPersonal>>> GetPersonalByName(string name);

        /// <summary>
        /// Inserta registro en la base de datos
        /// </summary>
        /// <param name="personal">Registro a ingresar</param>
        /// <returns>Registro insertado con ID incluido</returns>
        Task<ActionResult<CatPersonal>> CreatePersonal(CatPersonal personal);
    }
}
