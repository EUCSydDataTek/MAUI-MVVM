using MVVM.Models;
using MVVM.ViewModels;

namespace MVVM.Views;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;

        MessagingCenter.Subscribe<MainPageViewModel, string>(this,
            "AnswerToLifeClicked", (sender, arg) => DisplayAlert("Answer to Life", $"The answer is {arg}!", "OK"));


        MessagingCenter.Subscribe<MainPageViewModel, Person>(this,
            "AgeButtonClicked", (sender, arg) =>
            {
                DisplayAlert("Age", $"{arg.Name} er {arg.Age} år!", "OK");
            });

        
    }
}