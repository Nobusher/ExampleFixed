using ReactiveUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication2.ViewModels
{
    internal class FilesViewModel : ViewModelBase
    {
        public string Title => "File manager";

        private string _filePath = "";
        private string _fileContent = "";

        public string FilePath 
        {
            get => _filePath;
            set=>this.RaiseAndSetIfChanged(ref _filePath, value);
        }
        public string FileContent 
        {
            get => _fileContent;
            set=>this.RaiseAndSetIfChanged(ref _fileContent, value);
        }
        public ReactiveCommand<Unit, Unit> OpenFileCommand { get; }

        public FilesViewModel()
        {
            OpenFileCommand = ReactiveCommand.Create(() => { });
        }
        public void LoadFile(string filePath) 
        {
            FilePath = filePath;
            FileContent = File.ReadAllText(filePath);
        }

    }
}
