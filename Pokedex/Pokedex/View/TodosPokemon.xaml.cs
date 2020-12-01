using Pokedex.Services;
using Pokedex.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pokedex.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodosPokemon : ContentPage
    {
        TodosPokemonViewModel todosPokemonViewModel; 
        public TodosPokemon()
        {
            InitializeComponent();
            BindingContext = todosPokemonViewModel = new TodosPokemonViewModel();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var contato = e.Item as Results;

            todosPokemonViewModel.ItemSelected(contato.name);
        }
    }
}