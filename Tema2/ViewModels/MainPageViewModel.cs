using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tema2.Services;
using Tema2.Models;
using Tema2.Views;

namespace Tema2.ViewModels;

public partial class MainPageViewModel : BaseViewModel
{
    [ObservableProperty]
    List<TaskToDo> tasks;
    [ObservableProperty]
    TaskToDo task;
    [ObservableProperty]
    TaskToDo toSaveOnDB;

    private readonly DbConnection _dbConnection;
    public MainPageViewModel(DbConnection dbConnection)
    {
        _dbConnection = dbConnection;
        Title = "Hat Jhonule Titlu de Pagina";
        Tasks = new List<TaskToDo>();
        toSaveOnDB = new TaskToDo();
        GetInitialDataCommand.Execute(null);
    }

    [RelayCommand]
    private async void GetInitialData()
    {
        Tasks = await _dbConnection.GetItemsAsync();
    }

    [RelayCommand]
    private async void SaveOnDb()
    {
        await _dbConnection.SaveItemAsync(ToSaveOnDB);
        Tasks = await _dbConnection.GetItemsAsync();
    }
}

