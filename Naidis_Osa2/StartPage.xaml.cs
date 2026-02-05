using System.Threading.Tasks;

namespace Naidis_Osa2;

public partial class StartPage : ContentPage
{
	VerticalStackLayout vst;
	ScrollView sv;

	public List<ContentPage> Lehed = new List<ContentPage>() { new TextPage(), new FigurePage() }; //Страницы
	public List<string> LeheNimed = new List<string>() { "Tekst", "Joonis" }; //Имена страниц

	public StartPage()
	{
		Title = "Avaleht";
		vst = new VerticalStackLayout { Padding = 20, Spacing = 15 }; //Растояние межлу обьектаим и тд
		for (int i = 0; i < Lehed.Count; i++)
		{
			Button nupp = new Button
			{
				Text = LeheNimed[i],
				FontSize = 18,
				FontFamily = "Lovender400",
                BackgroundColor = Colors.LightGray,
				TextColor = Colors.Black,
				CornerRadius = 10,
				HeightRequest = 50,
				ZIndex = i
			};
			vst.Add(nupp);
			nupp.Clicked += (sender, e) =>
			{
				var valik = Lehed[nupp.ZIndex];
				Navigation.PushAsync(valik);
			};
		}
		sv = new ScrollView { Content = vst };
		Content = sv;
	}

	//private async Task Nupp_Clikced(object? sender, EventArgs e)
	//{
	//	Button nupp = sender as Button;
	//	await Navigation.PushAsync(Lehed[nupp.ZIndex]);
	//}

}