using System;
using System.ComponentModel;
using System.Security.Authentication;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using AvaloniaClientMetal.Models;
using MessageBox.Avalonia.Enums;
using Newtonsoft.Json;

namespace AvaloniaClientMetal;

public partial class MainMenuAdmin : Window
{
    public MainMenuAdmin()
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

    private void Window_OnClosing(object? sender, CancelEventArgs e)
    {
        Environment.Exit(1);
    }

    private void ButtonUsers_OnClick(object? sender, RoutedEventArgs e)
    {
        UsersWindow usersWindow = new UsersWindow();
        usersWindow.Show();
    }

    private void ButtonRoles_OnClick(object? sender, RoutedEventArgs e)
    {
        
    }
}