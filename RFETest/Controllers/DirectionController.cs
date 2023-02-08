using RFETest.DataBase;
using RFETest.Extensions;
using RFETest.Models;

namespace RFETest.Controllers;

/// <summary>
/// Extensions for REST enpoint functions
/// </summary>
public class DirectionController
{
    private readonly IDataBaseChecking _dataBaseChecking;

    public DirectionController(IServiceProvider serviceProvider)
    {
        _dataBaseChecking = new Lazy<IDataBaseChecking>(serviceProvider.GetRequiredService<IDataBaseChecking>()).Value;
    }

    /// <summary>
    /// Add income data to In memory
    /// </summary>
    /// <param name="db">InputDb</param>
    /// <param name="inputId">Id of input</param>
    /// <param name="input">Input value</param>
    /// <param name="type">Type of direstion for uri</param>
    /// <param name="uri">Uri</param>
    /// <returns>IResult</returns>
    public async Task<IResult> AddIncomePost(InputDb db, string inputId, InputData input, string type, string uri)
    {
        using var inputData = db.GetTypeMemoryData(type);

        if (await _dataBaseChecking.CheckIfIdIsInDb(await inputData, inputId))
            return Results.NotFound();

        var inputValue = new InputData()
        {
            InputId = inputId,
            InputType = type,
            Input = input.Input
        };

        await SaveItems(db, inputValue);

        return Results.Created(uri + type, inputValue);
    }

    /// <summary>
    /// Save items to In memory
    /// </summary>
    /// <param name="db">Name of db</param>
    /// <param name="input">Input value</param>
    private async Task SaveItems(InputDb db, InputData input)
    {
        db.Inputs.Add(input);
        await db.SaveChangesAsync();
    }

    /// <summary>
    /// Compare data for id from In memory
    /// </summary>
    /// <param name="db">Data base</param>
    /// <param name="id">Id for select data</param>
    /// <param name="directions">Query directions</param>
    /// <returns>Comparison result</returns>
    public async Task<IResult> CompareIncomeGet(InputDb db, string id, string[] directions)
    {
        using var inMemoryData = db.GetIdMemoryData(id);

        var inMemory = await inMemoryData;
        if (!_dataBaseChecking.CheckDirectionsValues(inMemory, directions))
        {
            if (_dataBaseChecking.CheckDirectionsSize(inMemory, directions))
            {
                return Results.Text(string.Concat($"Input {directions[0]} value: ",
                    $"{inMemory.Where(t => t.InputType == directions[0]).Select(x => x.Input).FirstOrDefault()}",
                    "\n",
                    $"Input {directions[1]} value: ",
                    $"{inMemory.Where(t => t.InputType == directions[1]).Select(x => x.Input).FirstOrDefault()}",
                    "\n",
                    $"Input {directions[0]} length: ",
                    $"{inMemory.Where(t => t.InputType == directions[0]).Select(x => x.Input.Length).FirstOrDefault()}",
                    "\n",
                    $"Input {directions[1]} length: ",
                    $"{inMemory.Where(t => t.InputType == directions[1]).Select(x => x.Input.Length).FirstOrDefault()}"
                ));
            }
            else
            {
                return Results.Text("inputs are of different size");
            }
        }
        else
        {
            return Results.Text("inputs were equal");
        }
    }
}