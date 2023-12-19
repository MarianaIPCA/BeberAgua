using BeberAgua.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace BeberAgua.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoricoPage : ContentPage
    {
        private ObservableCollection<ItemHistorico> ItensHistorico { get; } = new ObservableCollection<ItemHistorico>();

         public HistoricoPage()
         {
             InitializeComponent();

             listViewHistorico = new ListView
              {
                  ItemTemplate = new DataTemplate(() =>
                  {
                      var imagem = new Image { WidthRequest = 30, HeightRequest = 30, VerticalOptions = LayoutOptions.Center };
                      imagem.SetBinding(Image.SourceProperty, "Imagem");

                      var label = new Label { VerticalOptions = LayoutOptions.Center };
                      label.SetBinding(Label.TextProperty, "Texto");

                      return new ViewCell { View = new StackLayout { Orientation = StackOrientation.Horizontal, Children = { imagem, label } } };
                  })
              };

              Content = new StackLayout { Children = { listViewHistorico } };

              // Subscreve o evento para recarregar os itens quando a página aparece
              this.Appearing += (sender, e) => CarregarHistorico();


         }

         private void CarregarHistorico()
         {
             // Carrega os itens de histórico na ListView
             listViewHistorico.ItemsSource = ItensHistorico;
         }
        //novo
            // Define um evento para notificar alterações na quantidade de água
            public event EventHandler<int> QuantidadeAguaAtualizada;

        public void AdicionarItemHistorico(string opcao, int quantidade)
        {
             // Adiciona a opção selecionada à lista de histórico
             ItensHistorico.Add(new ItemHistorico
             {
                 Imagem = ObterImagemCorrespondente(opcao),
                 Texto = $"{opcao}: {quantidade} mL"
             });
           
        }

        private ImageSource ObterImagemCorrespondente(string opcao)
        {
            switch (opcao)
            {
                case "1 Chávena = 50mL": return "chavena.png";
                case "1 Copo pequeno = 100mL": return "copopequeno.png";
                case "1 Copo grande = 250mL": return "copogrande.png";
                case "1 Caneca = 500mL": return "caneca.png";
                case "1 Garrafa = 750mL": return "garrafa.png";
                case "1 Jarra = 1000mL": return "jarra.png";
                default: return null;
            }
        }
      
    } 

    public class ItemHistorico
    {
            public ImageSource Imagem { get; set; }
            public string Texto { get; set; }
        
    }

   
}



