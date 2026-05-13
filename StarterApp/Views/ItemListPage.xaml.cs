using StarterApp.ViewModels;

namespace StarterApp.Views;

public partial class ItemListPage : ContentPage
{
    private readonly ItemListViewModel _viewModel;

    public ItemListPage(ItemListViewModel viewModel)
    {
        InitializeComponent();

        _viewModel = viewModel;

        // sets page data
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // loads items when page opens
        await _viewModel.LoadItems();
    }
}