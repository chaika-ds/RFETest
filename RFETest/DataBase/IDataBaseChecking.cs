using RFETest.Models;

namespace RFETest.DataBase
{
    /// <summary>
    /// Vhecking for data base
    /// </summary>
    public interface IDataBaseChecking
    {
        /// <summary>
        /// Check if data for input Id is in DB
        /// </summary>
        /// <param name="inMemoryData">Data input</param>
        /// <param name="id">Input Id</param>
        /// <returns>Chack if this id is already in db</returns>
        public Task<bool> CheckIfIdIsInDb(List<InputData> inMemoryData, string id);

        /// <summary>
        /// Check if values from DB is equal
        /// </summary>
        /// <param name="inMemoryData">Data input</param>
        /// <param name="directions">Type of direction</param>
        /// <returns>Equality direction values</returns>
        bool CheckDirectionsValues(List<InputData> inMemoryData, string[] directions);

        /// <summary>
        /// Check if values from DB is equal size
        /// </summary>
        /// <param name="inMemoryData">Data input</param>
        /// <param name="directions">Type of direction</param>
        /// <returns>Equality direction values size</returns>
        bool CheckDirectionsSize(List<InputData> inMemoryData, string[] directions);
    }
}
