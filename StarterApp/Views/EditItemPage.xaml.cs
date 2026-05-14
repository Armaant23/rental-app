using StarterApp.ViewModels;

namespace StarterApp.Views;

public partial class EditItemPage : ContentPage
{
    private readonly EditItemViewModel _viewModel;

    // connects page to viewmodel
    public EditItemPage(EditItemViewModel viewModel)
    {
        InitializeComponent();

        _viewModel = viewModel;

        BindingContext = _viewModel;
    }

    // loads selected item
    public async Task LoadItem(int itemId)
    {
        await _viewModel.LoadItem(itemId);
    }

    // saves updated item
    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        await _viewModel.SaveChanges();

        await DisplayAlert("Saved", "Item updated", "OK");

        await Navigation.PopAsync();
    }
}