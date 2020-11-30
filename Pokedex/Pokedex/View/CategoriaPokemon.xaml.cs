using Pokedex.Services;
using Pokedex.ViewModels;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pokedex.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriaPokemon : ContentPage
    {
        CategoriaPokemonViewModel categoriaPokemonViewModel;
        public CategoriaPokemon()
        {
            InitializeComponent();
            categoriaPokemonViewModel = new CategoriaPokemonViewModel();
            BindingContext = categoriaPokemonViewModel;
        }

        private void categoria_pokemon_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = categoria_pokemon.Items[categoria_pokemon.SelectedIndex];
            categoriaPokemonViewModel.SelectedCategoriaPokemon(selectedItem);
        }

        //private void CollectionView_SelectionChanged(object sender, ItemTappedEventArgs e)
        //{
        //    //var contato = e.Item as Results;
        //    //categoriaPokemonViewModel.ItemSelected(contato.name);
        //}

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var contato = e.CurrentSelection.FirstOrDefault() as Results;
            categoriaPokemonViewModel.ItemSelected(contato.name);
        }
    }
}