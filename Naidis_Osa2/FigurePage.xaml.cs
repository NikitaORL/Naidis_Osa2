using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Devices;

namespace Naidis_Osa2;

public partial class FigurePage : ContentPage
{
    Polygon kolmnurk;
    BoxView boxView;
    Ellipse pall;
    Random rnd = new Random();
    HorizontalStackLayout hsl;
    List<string> nupud = new List<string>() { "Tagasi", "Avaleht", "Edasi" };

    public FigurePage()
    {
        int r = rnd.Next(256);
        int g = rnd.Next(256);
        int b = rnd.Next(256);

        boxView = new BoxView
        {
            Color = Color.FromRgb(r, g, b),
            WidthRequest = 200,
            HeightRequest = 200,
            HorizontalOptions = LayoutOptions.Center,
            BackgroundColor = Color.FromRgba(0, 0, 0, 0),
            CornerRadius = 30
        };

        TapGestureRecognizer tapBox = new TapGestureRecognizer();
        boxView.GestureRecognizers.Add(tapBox);
        tapBox.Tapped += (sender, e) =>
        {
            int newR = rnd.Next(256);
            int newG = rnd.Next(256);
            int newB = rnd.Next(256);
            boxView.Color = Color.FromRgb(newR, newG, newB);
            boxView.WidthRequest = boxView.Width + 20;
            boxView.HeightRequest = boxView.Height + 30;

            if (boxView.WidthRequest > (int)DeviceDisplay.MainDisplayInfo.Width / 3)
            {
                boxView.WidthRequest = 200;
                boxView.HeightRequest = 200;
            }
        };

        pall = new Ellipse
        {
            WidthRequest = 200,
            HeightRequest = 200,
            Fill = new SolidColorBrush(Color.FromRgb(b, g, r)),
            Stroke = Colors.BurlyWood,
            StrokeThickness = 5,
            HorizontalOptions = LayoutOptions.Center
        };

        TapGestureRecognizer tap_kolmnurk = new TapGestureRecognizer();
        pall.GestureRecognizers.Add(tap_kolmnurk);
        tap_kolmnurk.Tapped += (sender, e) =>
        {

        };
       


        // Polygon kasutamine
        kolmnurk = new Polygon
        {
            Points = new PointCollection
            {
                new Point(0, 200),
                new Point(100, 0),
                new Point(200, 200)
            },
            Fill = new SolidColorBrush(Color.FromRgb(g, b, r)),
            Stroke = Colors.Aquamarine,
            StrokeThickness = 5,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };


        kolmnurk.GestureRecognizers.Add(tap_kolmnurk);
        tap_kolmnurk.Tapped += (sender, e) =>
        {
            int newR = rnd.Next(256);
            int newG = rnd.Next(256);
            int newB = rnd.Next(256);
            kolmnurk.Fill = new SolidColorBrush(Color.FromRgb(newR, newG, newB));
        };

        hsl = new HorizontalStackLayout { Spacing = 20, HorizontalOptions = LayoutOptions.Center };

        for (int j = 0; j < nupud.Count; j++)
        {
            Button nupp = new Button
            {
                Text = nupud[j],
                FontSize = 18,
                FontFamily = "Lovender400",
                BackgroundColor = Colors.LightGray,
                TextColor = Colors.Black,
                CornerRadius = 10,
                HeightRequest = 50,
                ZIndex = j
            };
            hsl.Add(nupp);
            nupp.Clicked += Liikumine;
        }

        // Добавляем все элементы в вертикальный стек - ИСПРАВЛЕННАЯ ВЕРСИЯ
        var verticalLayout = new VerticalStackLayout
        {
            Spacing = 30,
            Padding = 20,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            Children =
            {
                new Label
                {
                    Text = "Joonise leht",
                    FontSize = 24,
                    FontAttributes = FontAttributes.Bold,
                    HorizontalOptions = LayoutOptions.Center
                },
                boxView,
                pall,
                kolmnurk,
                hsl
            }
        };

        Content = verticalLayout;
    }

    private void Liikumine(object? sender, EventArgs e)
    {
        Button nupp = sender as Button;

        if (nupp.ZIndex == 0)
        {
            Navigation.PopAsync();
        }
        else if (nupp.ZIndex == 1)
        {
            Navigation.PopToRootAsync();
        }
        else if (nupp.ZIndex == 2)
        {
            Navigation.PushAsync(new FigurePage());
        }
    }
}