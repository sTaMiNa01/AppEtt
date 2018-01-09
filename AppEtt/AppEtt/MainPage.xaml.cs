using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace AppEtt
{
	public partial class MainPage : ContentPage
	{
        private Uri _uri;
        private HttpClient _client;

        public MainPage()
		{
            InitializeComponent();
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("Accept", "text/plain");
            _client.DefaultRequestHeaders.Add("X-Mashape-Key", "sJRlUlJ0EOmshgDMFNT8fcpcz9Oip14MPlsjsn93KdfdX8sgNN");

        }

        public async void OnUIButtonClicked(object sender, EventArgs args)
        {
            string searchText = UserInput.Text;

            var apiResponce = await GetYodaText(searchText);

            string yodaReply = apiResponce.ToString();

            activityIndicator.IsRunning = false;

            await this.DisplayAlert("Yoda answerd:", yodaReply, "Cool");

        }

        public async Task<string> GetYodaText(string searchText)
        {
            activityIndicator.IsRunning = true;

            _uri = new Uri( $"https://yoda.p.mashape.com/yoda?sentence={searchText}"); 

            var responce = await _client.GetAsync(_uri);

            var responceContent = await responce.Content.ReadAsStringAsync();

            return responceContent;
        }


    }
}
