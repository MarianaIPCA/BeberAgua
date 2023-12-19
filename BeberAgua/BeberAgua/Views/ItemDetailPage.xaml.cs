using BeberAgua.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace BeberAgua.Views
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