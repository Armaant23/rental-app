using StarterApp.ViewModels;

namespace StarterApp.Views;

public partial class ItemDetailPage : ContentPage
{
    private readonly ItemDetailViewModel _viewModel;

    // connects viewmodel to page
    public ItemDetailPage(ItemDetailViewModel viewModel)
    {
        InitializeComponent();

        _viewModel = viewModel;

        BindingContext = _viewModel;
    }

    // load item when page opens
    public async Task LoadItem(int itemId)
    {
        await _viewModel.LoadItem(itemId);
    }

    // sends rental request
    private async void RentalButton_Clicked(object sender, EventArgs e)
    {
        await _viewModel.RequestRental();

        await DisplayAlert("Success", "Rental request sent", "OK");
    }

    // deletes current item
    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        await _viewModel.DeleteItem();

        await Navigation.PopAsync();
    }

    // opens edit page
private async void EditButton_Clicked(object sender, EventArgs e)
{
    if (_viewModel.ItemData == null)
    {
        return;
    }

    var page = Handler.MauiContext.Services.GetService<EditItemPage>();

    if (page != null)
    {
        await page.LoadItem(_viewModel.ItemData.Id);

        await Navigation.PushAsync(page);
    }
}
}