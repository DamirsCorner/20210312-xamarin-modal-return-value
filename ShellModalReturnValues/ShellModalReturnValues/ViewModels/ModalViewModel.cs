using ShellModalReturnValues.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ShellModalReturnValues.ViewModels
{
    public class ModalViewModel : BaseViewModel
    {
        private string message;

        public ModalViewModel()
        {
            YesCommand = new Command(async () => await Close(true));
            NoCommand = new Command(async () => await Close(false));
        }

        public event EventHandler<ModalClosedEventArgs> Closed;

        public string Message 
        { 
            get => message; 
            set => SetProperty(ref message, value); 
        }

        public ICommand YesCommand { get; }
        public ICommand NoCommand { get; }

        private async Task Close(bool result)
        {
            await Shell.Current.GoToAsync("..");
            Closed?.Invoke(this, new ModalClosedEventArgs(result));
        }
    }
}
