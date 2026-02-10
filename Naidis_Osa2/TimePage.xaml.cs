using Microsoft.Maui.Controls;

namespace Naidis_Osa2
{
    public partial class Timer_Page : ContentPage
    {
        private bool on_off = false;
        private CancellationTokenSource? _cts;

        public TimePage()
        {
            InitializeComponent();  // Важно: загружает XAML
        }

        // Метод из вашего кода для показа времени
        private async void ShowTime()
        {
            while (on_off)
            {
                timer_btn.Text = DateTime.Now.ToString("T");
                await Task.Delay(1000);
            }
        }

        // Метод из вашего кода для обработки кнопки
        private void timer_btn_Clicked(object sender, EventArgs e)
        {
            if (on_off)
            {
                on_off = false;
                timer_btn.Text = "Naita info";  // Возвращаем исходный текст
            }
            else
            {
                on_off = true;
                timer_btn.Text = "Peata";  // Меняем текст на "Остановить"
                ShowTime();  // Запускаем таймер
            }
        }

        // Обработчик нажатия на Label
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            lbl.Text = $"Vajutati: {DateTime.Now.ToString("T")}";
        }

        // Обработчик кнопки "Назад"
        private async void tagasi_Clicked(object sender, EventArgs e)
        {
            on_off = false;  // Останавливаем таймер
            await Navigation.PopAsync();
        }

        // Останавливаем таймер при закрытии страницы
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            on_off = false;  // Останавливаем таймер
        }
    }
}