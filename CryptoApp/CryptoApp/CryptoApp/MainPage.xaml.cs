using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using CryptoApp.Model;

namespace CryptoApp
{
    public partial class MainPage : ContentPage
    {
        private string apiKey = "8D80406E-01F6-4CDC-BC8F-5EEB515DABD2";
        private string baseImageUrl = "https://s3.eu-central-1.amazonaws.com/bbxt-static-icons/type-id/png_64/";
        public MainPage()
        {
            InitializeComponent();

            coinListView.ItemsSource = GetCoins();
        }

        private void RefreshButton_Clicked(object sender, EventArgs e)
        {
            coinListView.ItemsSource = GetCoins();
        }

        private List<Coin> GetCoins()
        {
            List<Coin> coins;

            var client = new RestClient("http://rest.coinapi.io/v1/assets?filter_asset_id=BTC;ETH;XMR;LTC;BCH");
            var request = new RestRequest(Method.GET);
            request.AddHeader("X-CoinAPI-Key", apiKey);
            var response = client.Execute<List<Coin>>(request);
            coins = JsonConvert.DeserializeObject<List<Coin>>(response.Content);

            foreach (var c in coins)
            {
                c.Icon_Url = baseImageUrl + c.Id_Icon.Replace("-", "") + ".png";
            }

            return coins;
        }
    }
}
