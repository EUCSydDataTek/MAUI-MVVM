# 4.DemoCommunityToolkitMVVM

## Normal MVVM kode

> [MVVM source generators Overview](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/generators/overview)
> 
> [ObservableProperty attribute](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/generators/observableproperty)
> 
> [RelayCommand attribute](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/generators/relaycommand)
> 
>[Announcing .NET Community Toolkit 8.0! MVVM, Diagnostics, Performance, and more!](https://devblogs.microsoft.com/dotnet/announcing-the-dotnet-community-toolkit-800/)


## Demo af [RelayCommand] og [ObservableProperty] samt Changing og Changed Events
Klik på knappen "Sync UI with backend" og den skriver John Doe. I terminalen ses at Change og Changed events køres.

Synkroniseringen med INotifyPropertyChange kan ses her:

I Solution Explorer, under Dependencies | netX.0-android | Analyzers | CommunityToolkit.Mvvm.SourceGenerators |
CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator og filen MAUICommunityToolkitMVVM.ViewModels.MainPageViewModel.g.cs.

Command koden kan ses næsten samme sted, vælg i stedet: CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator og filerne: 
MAUICommunityToolkitMVVM.ViewModels.MainPageViewModel.GreetUser.g.cs. og ...SyncUI.g.cs.

## Demo af [NotifyPropertyChangedFor(nameof(FullName))]
Bemærk at `FullName` ikke bliver opdateret. Nu indkobles `[NotifyPropertyChangedFor(nameof(FullName))]` for både firstName og lastName. Ændrer man noget, påvirker det nu også fullName.

## Demo af [NotifyCanExecuteChangedFor()]
Knappen "GreetUser" er disabled, selv om `firstName` og `lastName` er udfyldt. Der mangler en notificering om ændringen. Tilføj `[NotifyCanExecuteChangedFor()]` til `GreetUserCommand`.