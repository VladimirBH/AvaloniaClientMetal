using System;
using System.Net.Mime;
using System.Security.Authentication;
using System.Text.Json;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Styling;
using AvaloniaClientMetal.Models;
using MessageBox.Avalonia.DTO;
using MessageBox.Avalonia.Enums;

namespace AvaloniaClientMetal
{
    public partial class MainWindow : Window
    {
        private UserImplementation _userImplementation;
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ButtonSubmit_OnClick(object? sender, RoutedEventArgs e)
        {
            if (!(string.IsNullOrEmpty(TextBoxLogin.Text) || string.IsNullOrEmpty(TextBoxPassword.Text)))
            {
                _userImplementation = new UserImplementation();
                var tokenPair = 
                    _userImplementation.UserAuthorization(new DataAuth
                    {
                        Login = TextBoxLogin.Text,
                        Password = TextBoxPassword.Text
                    });
                try
                {
                    await tokenPair;
                    var messageBox = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Успех",
                        "Вход выполнен успешно \t", ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Success);
                    await messageBox.Show();
                    
                    KeepRoleId.RoleId = tokenPair.Result.IdRole;
                }
                catch (AuthenticationException ex)
                {
                    await MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Ошибка", ex.Message,
                        ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Error).Show();
                }
                catch (JsonException ex)
                {
                    await MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Ошибка", ex.Message,
                        ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Error).Show();
                }
                catch (Exception ex)
                {
                    await MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Ошибка", "Произошла ошибка, попробуйте повторить действие позже \t",
                        ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Error).Show();
                }
            }
            else
            {
                await MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Ошибка", "Заполните все поля",
                    ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Error).Show();
            }
        }
    }
}