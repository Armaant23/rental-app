using Microsoft.Extensions.DependencyInjection;
using StarterApp.ViewModels;

namespace StarterApp.Views;

public partial class MainPage : ContentPage
{
    private readonly IServiceProvider _services;

    
// connects services and viewmodels to page
    public MainPage(MainViewModel viewModel, IServiceProvider services)
    {
        InitializeComponent();

        BindingContext = viewModel;
        _services = services;
    }

    // opens item list page
    private async void GoToItemsPage(object sender, EventArgs e)
    {
        var page = _services.GetRequiredService<ItemListPage>();

        await Navigation.PushAsync(page);
    }

    // opens add item page
    private async void GoToAddItemPage(object sender, EventArgs e)
    {
        var page = _services.GetRequiredService<AddItemPage>();

        await Navigation.PushAsync(page);
    }
}