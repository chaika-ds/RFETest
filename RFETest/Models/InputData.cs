namespace RFETest.Models;

/// <summary>
/// Class for Rfe input data
/// </summary>
public class InputData
{
    /// <summary>
    /// Id for DB
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Id for input endpoint
    /// </summary>
    public string InputId { get; set; }

    /// <summary>
    /// Input value
    /// </summary>
    public string Input { get; set; }

    /// <summary>
    /// Type of input
    /// </summary>
    public string InputType { get; set; }
}