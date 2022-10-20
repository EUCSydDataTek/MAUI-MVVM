using MVVM.Models;
using MVVM.ViewModels;

namespace MVVM.Views;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;

        MessagingCenter.Subscribe<MainPageViewModel, Person>(new MainPageViewModel(),
            "AgeButtonClicked", (sender, arg) =>
            {
                DisplayAlert("Age", $"{arg.Name} er {arg.Age} år!", "OK");
            });

        MessagingCenter.Subscribe<MainPageViewModel, string>(new MainPageViewModel(),
            "AnswerToLifeClicked", (sender, arg) =>
            {
                DisplayAlert("Answer to Life", $"The answer is {arg}!", "OK");
            });
    }
}