using CommunityToolkit.Mvvm.ComponentModel;
using UserDataBase.Avalonia.Models;

namespace UserDataBase.Avalonia.ViewModels;

public partial class TodoItemViewModel : ViewModelBase
{
    [ObservableProperty]
    private bool _isChecked;
    
    [ObservableProperty]
    private string? _content;

    public TodoItemViewModel()
    {
        
        
    }
    public TodoItemViewModel(ToDoItem item)
    {
        IsChecked = item.IsChecked;
        Content = item.Content;
        
        
    }



}