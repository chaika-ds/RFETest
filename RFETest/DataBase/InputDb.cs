using Microsoft.EntityFrameworkCore;
using RFETest.Models;

namespace RFETest.DataBase;

/// <summary>
/// InputDb context
/// </summary>
public class InputDb : DbContext
{
    public InputDb(DbContextOptions<InputDb> options)
        : base(options) { }

    /// <summary>
    /// DbSet of InputData tables
    /// </summary>
    public DbSet<InputData> Inputs => Set<InputData>();
}