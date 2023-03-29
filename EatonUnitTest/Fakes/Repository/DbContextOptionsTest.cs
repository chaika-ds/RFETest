using System.ComponentModel.DataAnnotations.Schema;

namespace EatonUnitTest.Fakes.Repository;

/// <summary>
/// DbContext Options Test
/// </summary>
internal class DbContextOptionsTest : IDbContextOptionsTest
{
    /// <summary>
    ///     DatabaseId
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid DatabaseId { get; set; }

    public DbContextOptionsTest()
    {
        DatabaseId = Guid.NewGuid();

    }
}