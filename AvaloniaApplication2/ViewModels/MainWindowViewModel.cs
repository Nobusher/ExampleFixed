using ReactiveUI;
using System.Reactive;

namespace AvaloniaApplication2.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private string _name = "";
        private string _message = "";

        public string Name
        {
            get => _name;
            set 
            {
                this.RaiseAndSetIfChanged(ref _name, value);
                this.RaisePropertyChanged(nameof(Greeting));
            } 
        }

        public string Message
        {
            get => _message;
            set => this.RaiseAndSetIfChanged(ref _message, value);
        }

        public string Greeting => string.IsNullOrEmpty(_name)
            ? "Name unknown..."
            : $"Hello, {_name}!";

        public ReactiveCommand<Unit, Unit> SayHelloCommand { get; }

        public MainWindowViewModel()
        {
            var canExecute = this.WhenAnyValue(
                x => x.Name,
                name => !string.IsNullOrWhiteSpace(name));

            SayHelloCommand = ReactiveCommand.Create(() =>
            {
                Message = $"{Name}!?";
            }, canExecute);
        }
    }
}
