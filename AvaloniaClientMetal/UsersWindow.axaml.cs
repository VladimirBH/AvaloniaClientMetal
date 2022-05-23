using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaClientMetal.Models;

namespace AvaloniaClientMetal;

public partial class UsersWindow : Window
{
    public UsersWindow()
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

    private async void TopLevel_OnOpened(object? sender, EventArgs e)
    {
        UserDataGrid.Items = await UserImplementation.GetAllUsers();
    }
}