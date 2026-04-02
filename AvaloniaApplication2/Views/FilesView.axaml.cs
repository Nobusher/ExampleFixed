using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using System.Linq;
namespace AvaloniaApplication2;

public partial class FilesView : UserControl
{
    public FilesView()
    {
        InitializeComponent();
    }
    private async void OpenFileButton_Click(object sender,
        RoutedEventArgs e)
    {
        var topLevel = TopLevel.GetTopLevel(this);
        if (topLevel == null) { return; }
        var files = await topLevel.StorageProvider.OpenFilePickerAsync
            (
                new Avalonia.Platform.Storage.FilePickerOpenOptions
                {
                    Title = "Select a file",
                    AllowMultiple = false,
                    FileTypeFilter = new[]
                    {
                        new FilePickerFileType("Text files")
                        {
                            Patterns = new [] {"*.txt","*.cs",".json"}
                        }
                    }
                }
            );

        if (files.Count == 0) { return; }

        var path = files.First().Path.LocalPath;
        if (DataContext is ViewModels.FilesViewModel vm) 
        {
            vm.LoadFile(path);
        }

    }
}