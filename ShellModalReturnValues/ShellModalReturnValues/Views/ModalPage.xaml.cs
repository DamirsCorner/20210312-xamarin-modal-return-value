using ShellModalReturnValues.Models;
using ShellModalReturnValues.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShellModalReturnValues.Views
{
    [QueryProperty(nameof(Message), nameof(Message))]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModalPage : ContentPage
    {

        public ModalPage()
        {
            InitializeComponent();

            BindingContext = ViewModel;
        }

        public ModalViewModel ViewModel { get; } = new ModalViewModel();

        public string Message 
        { 
            get => ViewModel.Message;
            set => ViewModel.Message = Uri.UnescapeDataString(value ?? string.Empty);
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        public static async Task<bool> Show(string message)
        {
            var taskCompletionSource = new TaskCompletionSource<bool>();

            ModalViewModel viewModel = null;

            void ClosedHandler(object sender, ModalClosedEventArgs e)
            {
                viewModel.Closed -= ClosedHandler;
                taskCompletionSource.SetResult(e.Result);
            }

            void NavigatedHandler(object sender, ShellNavigatedEventArgs e)
            {
                if (Shell.Current.CurrentPage is ModalPage page)
                {
                    viewModel = page.ViewModel;
                    page.ViewModel.Closed += ClosedHandler;
                }

                Shell.Current.Navigated -= NavigatedHandler;
            }

            Shell.Current.Navigated += NavigatedHandler;

            await Shell.Current.GoToAsync($"{nameof(ModalPage)}?{nameof(ModalPage.Message)}={Uri.EscapeDataString(message)}");

            return await taskCompletionSource.Task;
        }

    }
}