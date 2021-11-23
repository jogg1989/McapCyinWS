using McapCyinWS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McapCyinWS.DataAccess
{
    /// <summary>
    /// Clase que inplementa la interfaz para obtención de datos
    /// </summary>
    public class DataAccessProvider : IDataAccessProvider
    {
        /// <summary>
        /// Parametro de Contexto de PostgreSQL
        /// </summary>
        private readonly PostgreSqlContext _context;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="context">Inicializador de contexto</param>
        public DataAccessProvider(PostgreSqlContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Inserta registro en la base de datos
        /// </summary>
        /// <param name="personal">Registro a ingresar</param>
        /// <returns>Registro insertado con ID incluido</returns>
        public async Task<ActionResult<CatPersonal>> CreatePersonal(CatPersonal personal)
        {
            _context.Add(personal);
            await _context.SaveChangesAsync();
            return personal;
        }

        /// <summary>
        /// Realiza un select a toda la tabla catPersonal
        /// </summary>
        /// <returns>Lista con todos los registros de la tabla catPersonal</returns>
        public async Task<ActionResult<List<CatPersonal>>> GetPersonal()
        {
            return await _context.catPersonal.ToListAsync();
        }

        /// <summary>
        /// Registro de la tabla catPersonal encontrado por identificador
        /// </summary>
        /// <param name="id">Identificador del registro a buscar</param>
        /// <returns>Registro de la tabla catPersonal</returns>
        public async Task<ActionResult<CatPersonal>> GetPersonalById(int id)
        {
            return await _context.catPersonal.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Lista de registros de la tabla catPersonal encontrados por que la cadena a buscar es una subcadena del nombre
        /// </summary>
        /// <param name="name">Cadena que sera subcadena del campo nombre</param>
        /// <returns>Lista de registrso de la tabla catPersonal</returns>
        public async Task<ActionResult<List<CatPersonal>>> GetPersonalByName(string name)
        {
            return await _context.catPersonal.Where(x => x.Nombre.Contains(name)).ToListAsync();
        }
    }
}
