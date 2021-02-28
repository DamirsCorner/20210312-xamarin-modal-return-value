using ShellModalReturnValues.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ShellModalReturnValues.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}