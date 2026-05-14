using StarterApp.ViewModels;

namespace StarterApp.Views;

public partial class RentalsPage : ContentPage
{
    private readonly RentalsViewModel _viewModel;

    // connect  viewmodel to page
    public RentalsPage(RentalsViewModel viewModel)
    {
        InitializeComponent();

        _viewModel = viewModel;

        BindingContext = _viewModel;

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _viewModel.LoadRentals();
    }

    // approve request
private async void ApproveButton_Clicked(object sender, EventArgs e)
{
    if (sender is Button button && button.CommandParameter is int rentalId)
    {
        await _viewModel.ApproveRental(rentalId);
    }
}

// reject request
private async void RejectButton_Clicked(object sender, EventArgs e)
{
    if (sender is Button button && button.CommandParameter is int rentalId)
    {
        await _viewModel.RejectRental(rentalId);
    }
}

}