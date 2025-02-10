using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVM.Models;
using System.Collections.ObjectModel;

namespace MVVM.ViewModels;
public partial class MainPageViewModel : BaseViewModel
{
    public ObservableCollection<Person> Persons { get; }

    #region CONSTRUCTOR
    public MainPageViewModel()
    {
        Persons = new ObservableCollection<Person>
                {
                    new Person { Name = "Anna", Age = 27 },
                    new Person { Name = "Christian", Age = 32 },
                    new Person { Name = "Helle", Age = 54 }
                };
    }
    #endregion

    #region PROPERTY
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ShowAgeCommand), nameof(MakeOlderCommand), nameof(DeleteCommand))]
    public partial Person PersonSelectedItem { get; set; }

    partial void OnPersonSelectedItemChanging(Person value)
    {
        Name = value.Name;
        Age = value.Age;
    }


    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AddCommand))]
    public partial string Name { get; set; }

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AddCommand))]
    public partial int Age { get; set; }
    #endregion

    #region COMMANDING
    [RelayCommand]
    private void ClearEntries()
    {
        Name = string.Empty;
        Age = 0;
    }

    [RelayCommand(CanExecute = nameof(CanAdd))]
    private void Add(object obj)
    {
        Persons.Add(new Person { Name = Name, Age = Age });
    }
    private bool CanAdd(object arg)
    {
        return Name?.Length > 0 && Age > 0;
    }

    [RelayCommand(CanExecute = nameof(CanShowAge))]
    private void ShowAge()
    {
        Shell.Current.DisplayAlert("AgeButtonClicked", $"{PersonSelectedItem.Name} er {PersonSelectedItem.Age}", "OK");
    }
    private bool CanShowAge() => PersonSelectedItem != null;


    [RelayCommand(CanExecute = nameof(CanMakeOlder))]
    private void MakeOlder()
    {
        Age++;
        PersonSelectedItem.Age = Age;
    }
    private bool CanMakeOlder() => PersonSelectedItem != null;


    [RelayCommand(CanExecute = nameof(CanDelete))]
    private void Delete() => Persons.Remove(PersonSelectedItem ?? null);
    private bool CanDelete() => PersonSelectedItem != null && Persons.Count > 1;


    // Command with parameter
    [RelayCommand]
    private void AnswerToLife(string param)
    {
        Shell.Current.DisplayAlert("AnswerToLifeClicked", $"{param}", "OK");
    }
    #endregion
}