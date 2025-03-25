namespace Exo04_JeuDuPendu.Pages;

public partial class WeatherPage : ContentPage
{
    static HttpClient client = new HttpClient();

    public WeatherPage()
    {
        InitializeComponent();

        callApi();
    }

    public async void callApi()
    {
        HttpClient client = new HttpClient();

        HttpResponseMessage response = await client.GetAsync("https://api.open-meteo.com/v1/forecast?latitude=50.633&longitude=3.0586&hourly=temperature_2m");
        if (response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);

            DataAPI.Text = responseBody;
        }
    }

    
}