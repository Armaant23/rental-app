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

}