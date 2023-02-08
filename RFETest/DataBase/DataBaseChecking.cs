using Microsoft.EntityFrameworkCore;
using RFETest.Models;

namespace RFETest.DataBase;

/// <summary>
/// Ckass for checking data from DB
/// </summary>
internal class DataBaseChecking : IDataBaseChecking
{
    /// <summary>
    /// Check if data for input Id is in DB
    /// </summary>
    /// <param name="inMemoryData">Data input</param>
    /// <param name="id">Input Id</param>
    /// <returns>Chack if this id is already in db</returns>
    public async Task<bool> CheckIfIdIsInDb(List<InputData> inMemoryData, string id) =>
        inMemoryData.Select(d => d.InputId).Contains(id);

    /// <summary>
    /// Check if values from DB is equal
    /// </summary>
    /// <param name="inMemoryData">Data input</param>
    /// <param name="directions">Type of direction</param>
    /// <returns>Equality direction values</returns>
    public bool CheckDirectionsValues(List<InputData> inMemoryData, string[] directions)
    {
        return Equals(inMemoryData.Where(m => m.InputType == directions[0]).Select(d => d.Input).FirstOrDefault(),
            inMemoryData.Where(m => m.InputType == directions[1]).Select(d => d.Input).FirstOrDefault());
    }


    /// <summary>
    /// Check if values from DB is equal size
    /// </summary>
    /// <param name="inMemoryData">Data input</param>
    /// <param name="directions">Type of direction</param>
    /// <returns>Equality direction values size</returns>
    public bool CheckDirectionsSize(List<InputData> inMemoryData, string[] directions)
    {
         return Equals(inMemoryData.Where(m => m.InputType == directions[0]).Select(d => d.Input.Length).Single(),
            inMemoryData.Where(m => m.InputType == directions[1]).Select(d => d.Input.Length).Single());
    }    
}