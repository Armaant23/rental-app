using StarterApp.ViewModels;

namespace StarterApp.Views;

public partial class AddItemPage : ContentPage
{
    private readonly AddItemViewModel _viewModel;
// connects viewmodel to page
    public AddItemPage(AddItemViewModel viewModel)
    {
        InitializeComponent();

        _viewModel = viewModel;

        // sets page data
        BindingContext = _viewModel;
    }

}