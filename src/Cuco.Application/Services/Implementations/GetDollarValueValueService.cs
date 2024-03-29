using Cuco.Commons.Base;
using Cuco.Domain.Currencies.Services.Repositories;

namespace Cuco.Application.Services.Implementations;

internal class GetDollarValueValueService : IGetDollarValueService
{
    private const string BaseCurrencySymbol = "USD";
    private const decimal BaseValue = 1;
    private const decimal DefaultNonValue = 0;

    private readonly ICurrencyRepository _currencyRepository;
    private readonly IRedisCache _redisCache;

    public GetDollarValueValueService(ICurrencyRepository currencyRepository, IRedisCache redisCache)
    {
        _currencyRepository = currencyRepository;
        _redisCache = redisCache;
    }

    public async Task<decimal[]> Convert(string[] symbols)
    {
        if (symbols.Length == 0) return Array.Empty<decimal>();

        var convertedValues = new decimal[symbols.Length];
        for (var i = 0; i < symbols.Length; i++)
        {
            var symbol = symbols[i]?.ToUpper();
            if (string.IsNullOrEmpty(symbol))
            {
                convertedValues[i] = DefaultNonValue;
                continue;
            }

            convertedValues[i]
                = symbol == BaseCurrencySymbol
                ? BaseValue
                : await GetValue(symbol);
        }

        return convertedValues;
    }

    private async Task<decimal> GetValue(string symbol)
    {
        try
        {
            if(decimal.TryParse(await _redisCache.GetAsync(symbol), out var cachedValue))
                return cachedValue;
            var currency = await _currencyRepository.GetBySymbolAsync(symbol);
            return currency.ValueInDollar;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return DefaultNonValue;
        }
    }
}