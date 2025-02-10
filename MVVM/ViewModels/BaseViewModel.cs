using CommunityToolkit.Mvvm.ComponentModel;

namespace MVVM.ViewModels;
public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    public partial bool IsBusy { get; set; }

    [ObservableProperty]
    public partial string Title { get; set; }
}