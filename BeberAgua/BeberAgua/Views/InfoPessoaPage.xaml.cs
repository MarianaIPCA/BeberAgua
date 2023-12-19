using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeberAgua.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InfoPessoaPage : ContentPage
	{
        private DefinicaoPage _definicaoPage;

        public InfoPessoaPage(DefinicaoPage definicaoPage)
        {
            InitializeComponent();
            _definicaoPage = definicaoPage;
        }

        private async void OnSaveEdicaoClicked(object sender, EventArgs e)
        {
            string nome = nomeEntry.Text;
            string idade = idadeEntry.Text;
            string peso = pesoEntry.Text;

            _definicaoPage.AtualizarInformacoes(nome, idade, peso);

            await Navigation.PopAsync();
        }


      

    }
}