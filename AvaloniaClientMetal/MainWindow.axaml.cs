using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AvaloniaClientMetal
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonSubmit_OnClick(object? sender, RoutedEventArgs e)
        {
            if (TextBoxLogin.Text != "" && TextBoxPassword.Text != "")
            {
                
            }
        }
    }
}