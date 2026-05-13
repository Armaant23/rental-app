using StarterApp.ViewModels;

namespace StarterApp.Views;

public partial class AddItemPage : ContentPage
{
    private readonly AddItemViewModel _viewModel;

    public AddItemPage(AddItemViewModel viewModel)
    {
        InitializeComponent();

        _viewModel = viewModel;

        // sets page data
        BindingContext = _viewModel;
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        // saves item into database
        await _viewModel.SaveItem();

        await DisplayAlert("Success", "Item saved", "OK");
    }
}