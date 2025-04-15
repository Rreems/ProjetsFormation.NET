using System.Text.Json;
using M2i.Learning.Styling.Models;

namespace M2i.Learning.Styling.Pages;

public partial class SecondPage : ContentPage
{
	HttpClient _http;
	public SecondPage()
	{
		InitializeComponent();
		_http = new HttpClient();
	}

    private void btnGetPosts_Clicked(object sender, EventArgs e)
    {
		GetAllPosts();
    }

	private async Task GetAllPosts() 
	{
		var response = await _http.GetAsync("https://jsonplaceholder.typicode.com/posts");
		if (response.IsSuccessStatusCode)
		{
			using var contentAsStream = await response.Content.ReadAsStreamAsync();
			var data = await JsonSerializer.DeserializeAsync<List<AppUser>>(contentAsStream);
		}
	}
}