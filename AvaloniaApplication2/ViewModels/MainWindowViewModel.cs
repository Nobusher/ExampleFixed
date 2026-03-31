using ReactiveUI;
using System.Reactive;

namespace AvaloniaApplication2.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _currentPage;

        public ViewModelBase CurrentPage 
        {
            get => _currentPage;
            set => this.RaiseAndSetIfChanged(ref _currentPage, value);
        }

        public ReactiveCommand<Unit, Unit> GoToFilesCommand { get;  }
        public ReactiveCommand<Unit, Unit> GoBackCommand { get;  }

        public MainWindowViewModel()
        {
            _currentPage = new GreetingViewModel();

            GoToFilesCommand = ReactiveCommand.Create(() =>
            {
                CurrentPage = new FilesViewModel();
            });
            GoBackCommand = ReactiveCommand.Create(() => 
            {
                CurrentPage = new GreetingViewModel();
            });
        }
    }
}
