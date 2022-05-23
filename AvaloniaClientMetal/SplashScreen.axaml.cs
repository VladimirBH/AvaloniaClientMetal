using System;
using System.Security.Authentication;
using System.Text.Json;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaClientMetal.Models;
using MessageBox.Avalonia.Enums;

namespace AvaloniaClientMetal;

public partial class SplashScreen : Window
{
    public SplashScreen()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private async void SplashScreen_OnOpened(object? sender, EventArgs e)
    {

        try
        {
            PreparedLocalStorage.LoadLocalStorage();
            TokenPair tokenPair = PreparedLocalStorage.GetTokenPairFromLocalStorage();
            tokenPair = await UserImplementation.RefreshTokenPair(tokenPair.RefreshToken);
            PreparedLocalStorage.PutTokenPairFromLocalStorage(tokenPair);
            PreparedLocalStorage.SaveLocalStorage();
            KeepRoleId.RoleId = tokenPair.IdRole;
            Hide();
            if (KeepRoleId.RoleId == 1)
            {
                MainMenuAdmin mainMenuAdmin = new MainMenuAdmin();
                mainMenuAdmin.Show();
            }
            else
            {
                
            }
        }
        catch (Exception ex)
        {
            var messageBox = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Успех",
                ex.Message+"\t", ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Success);
            await messageBox.Show();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}