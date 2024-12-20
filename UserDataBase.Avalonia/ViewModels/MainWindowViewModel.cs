using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace UserDataBase.Avalonia.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!";

    public ObservableCollection<TodoItemViewModel> TodoItems { get; } = new ObservableCollection<TodoItemViewModel>();

    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(AddItemCommand))]
    private string? _newItemContent;
    
    private bool CanAddItem() => !string.IsNullOrWhiteSpace(NewItemContent);

    [RelayCommand(CanExecute = nameof(CanAddItem))]

    private void AddItem()
    {
        TodoItems.Add(new TodoItemViewModel() {Content = NewItemContent} );
        
        NewItemContent = null;
    }

    [RelayCommand]
    private void RemoveItem(TodoItemViewModel item)
    {
        TodoItems.Remove(item);
    }

}