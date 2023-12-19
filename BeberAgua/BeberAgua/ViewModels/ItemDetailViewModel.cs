using BeberAgua.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BeberAgua.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string nome;
        private string especie;
        private int idade;
        public string Id { get; set; }

        public string Nome
        {
            get => nome;
            set => SetProperty(ref nome, value);
        }

        public string Especie
        {
            get => especie;
            set => SetProperty(ref especie, value);
        }

        public int Idade
        {
            get => idade;
            set => SetProperty(ref idade, value);
        }
        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
         {
             try
             {
                 var item = await DataStore.GetItemAsync(itemId);
                 Id = item.Id;
                 Nome = item.Nome;
                 Especie = item.Especie;
                 Idade = item.Idade;

             }
             catch (Exception)
             {
                 Debug.WriteLine("Failed to Load Item");
             }
         }


       


    }
}
