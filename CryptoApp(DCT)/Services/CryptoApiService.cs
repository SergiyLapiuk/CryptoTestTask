using CryptoTestTask.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoTestTask.Services
{
    public interface ICryptoApiService
    {
        Task<List<Asset>> GetCoinsAsync();
    }

    public class CryptoApiService : ICryptoApiService
    {
        private const string ApiUrl = "http://api.coincap.io/v2/assets";
        private readonly RestClient _client;

        public CryptoApiService()
        {
            _client = new RestClient(ApiUrl);
        }

        public async Task<List<Asset>> GetCoinsAsync()
        {
            var request = new RestRequest();
            request.AddHeader("Authorization", "Bearer 935bf130-e617-4926-8b3d-6469e88ff2d3");

            var response = await _client.ExecuteAsync(request);
            if (!response.IsSuccessful)
            {
                throw new Exception("Failed to retrieve data from API.");
            }

            var data = JsonConvert.DeserializeObject<dynamic>(response.Content);
            if (data == null || data.data == null)
            {
                throw new Exception("No data returned from API.");
            }

            var assets = new List<Asset>();
            foreach (var coin in data.data)
            {
                assets.Add(new Asset
                {
                    Id = coin.id,
                    Rank = coin.rank,
                    Symbol = coin.symbol,
                    Name = coin.name,
                    Supply = coin.supply,
                    MaxSupply = coin.maxSupply,
                    MarketCapUsd = coin.marketCapUsd,
                    VolumeUsd24Hr = coin.volumeUsd24Hr,
                    PriceUsd = coin.priceUsd,
                    ChangePercent24Hr = coin.changePercent24Hr,
                    Vwap24Hr = coin.vwap24Hr,
                    Explorer = coin.explorer
                });
            }

            return assets;
        }

    }
}
