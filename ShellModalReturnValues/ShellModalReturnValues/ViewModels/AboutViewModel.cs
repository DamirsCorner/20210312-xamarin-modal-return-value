using ShellModalReturnValues.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ShellModalReturnValues.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private bool? modalResult;

        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
            OpenModalCommand = new Command(async () => await OpenModal());
        }

        public ICommand OpenWebCommand { get; }

        public ICommand OpenModalCommand { get; }

        public bool? ModalResult 
        { 
            get => modalResult; 
            set => SetProperty(ref modalResult, value);
        }

        private async Task OpenModal()
        {
            ModalResult = await ModalPage.Show("Do you agree?");
        }
    }
}