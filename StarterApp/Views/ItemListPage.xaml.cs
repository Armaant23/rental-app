using Microsoft.Extensions.DependencyInjection;
using StarterApp.Database.Models;
using StarterApp.ViewModels;

namespace StarterApp.Views;

public partial class ItemListPage : ContentPage
{
    private readonly ItemListViewModel _viewModel;
    private readonly IServiceProvider _services;

    // connects viewmodel and services to page
    public ItemListPage(ItemListViewModel viewModel, IServiceProvider services)
    {
        InitializeComponent();

        _viewModel = viewModel;
        _services = services;

        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // loads items when page opens
        await _viewModel.LoadItems();
    }


    // opens chosen item
    private async void ItemTapped(object sender, TappedEventArgs e)
    {
        if (sender is Frame frame && frame.BindingContext is Item item)
        {
            var page = _services.GetRequiredService<ItemDetailPage>();

            await page.LoadItem(item.Id);

            await Navigation.PushAsync(page);
        }
    }
}