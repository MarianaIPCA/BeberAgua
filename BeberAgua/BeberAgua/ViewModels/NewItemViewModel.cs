using BeberAgua.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;


namespace BeberAgua.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string nome;
        private string especie;
        private int idade;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave,ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();

        }
        
       private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(nome)
                && !String.IsNullOrWhiteSpace(especie)
                && idade>0;
        }
        
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
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Nome = Nome,
                Especie = Especie, 
                Idade = Idade,
            };

            await DataStore.AddItemAsync(newItem);
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
