using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace EatonTest.Repository;

/// <summary>
/// DictionaryConverter
/// </summary>
/// <typeparam name="TKey">Key type</typeparam>
/// <typeparam name="TValue">Value type</typeparam>
public class DictionaryConverter<TKey, TValue> : ValueConverter<Dictionary<TKey, TValue>, string> where TKey : notnull
{
    public DictionaryConverter() : base(
        v => Convert(v),
        v => ConvertBack(v))
    {
    }

    /// <summary>
    /// Convert from dictionary to string
    /// </summary>
    /// <param name="dictionary">Dictionary</param>
    /// <returns></returns>
    private static string Convert(Dictionary<TKey, TValue>? dictionary)
    {
        if (dictionary == null)
        {
            return "";
        }

        return JsonConvert.SerializeObject(dictionary,
            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
    }

    /// <summary>
    /// Convert from string to dictionary
    /// </summary>
    /// <param name="stringData">String value</param>
    /// <returns></returns>
    private static Dictionary<TKey, TValue> ConvertBack(string stringData)
        => JsonConvert.DeserializeObject<Dictionary<TKey, TValue>>(stringData,
               new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }) ??
           new Dictionary<TKey, TValue>();
}
