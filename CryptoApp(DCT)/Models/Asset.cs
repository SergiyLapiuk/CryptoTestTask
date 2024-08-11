using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTestTask.Models
{
    public class Asset
    {
        private string id;
        private int? rank;
        private string symbol;
        private string name;
        private string explorer;
        private double? supply;
        private double? maxSupply;
        private double? marketCapUsd;
        private double? volumeUsd24Hr;
        private double? priceUsd;
        private double? changePercent24Hr;
        private double? vwap24Hr;

        public string Id
        {
            get { return id; }
            set
            {
                id = value;
            }
        }
        public int? Rank
        {
            get { return rank; }
            set
            {
                rank = value ?? -1;
            }
        }
        public string Symbol
        {
            get { return symbol; }
            set
            {
                symbol = value;
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }
        public double? Supply
        {
            get { return supply; }
            set
            {
                supply = value ?? 0;
            }
        }
        public double? MaxSupply
        {
            get { return maxSupply; }
            set
            {
                maxSupply = value ?? 0;
            }
        }
        public double? MarketCapUsd
        {
            get { return marketCapUsd; }
            set
            {
                marketCapUsd = value ?? 0;
            }
        }
        public double? VolumeUsd24Hr
        {
            get { return volumeUsd24Hr; }
            set
            {
                volumeUsd24Hr = value ?? 0;
            }
        }
        public double? PriceUsd
        {
            get { return priceUsd; }
            set
            {
                priceUsd = value ?? 0;
            }
        }
        public double? ChangePercent24Hr
        {
            get { return changePercent24Hr; }
            set
            {
                changePercent24Hr = value ?? 0;
            }
        }
        public double? Vwap24Hr
        {
            get { return vwap24Hr; }
            set
            {
                vwap24Hr = value ?? 0;
            }
        }
        public string Explorer
        {
            get { return explorer; }
            set
            {
                explorer = value;
            }
        }
    }
}
