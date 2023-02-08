using Microsoft.EntityFrameworkCore;
using RFETest.DataBase;
using RFETest.Models;

namespace RFETest.Extensions
{
    /// <summary>
    /// Extensions for manage database data
    /// </summary>
    public static class DataBaseExtensions
    {
        /// <summary>
        /// Get data from InputDb by id
        /// </summary>
        /// <param name="db">Data base name</param>
        /// <param name="id">Input Id</param>
        /// <returns>List of InputData</returns>
        public static async Task<List<InputData>> GetIdMemoryData(this InputDb db, string id)
            => await db.Inputs.Where(m => m.InputId == id).ToListAsync();

        /// Get data from InputDb by type
        /// </summary>
        /// <param name="db">Data base</param>
        /// <param name="type">Type of direction</param>
        /// <returns>List of InputData</returns>
        public static async Task<List<InputData>> GetTypeMemoryData(this InputDb db, string type)
            => await db.Inputs.Where(m => m.InputType == type).ToListAsync();


    }
}
