using Newtonsoft.Json;
using Pokedex.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace Pokedex.ViewModels
{
    public class CategoriaPokemonViewModel
    {
        string url;

        private ObservableCollection<Results> _listPokemon;

        public ObservableCollection<Results> ListPokemon
        {
            get { return _listPokemon; }
            set { _listPokemon = value; }
        }
        public CategoriaPokemonViewModel()
        {
            ListPokemon = new ObservableCollection<Results>();
        }
        public void SelectedCategoriaPokemon(string pokemonName)
        {
            url = string.Format($"https://pokeapi.co/api/v2/type/{pokemonName}");
            FeedList();
        }

        public void FeedList()
        {
            ListPokemon.Clear();
            GetAllPokemons();
        }
        public async void ItemSelected(string pokemonName)
        {
            MessagingCenter.Send<string>(pokemonName, "Pokemon");
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private void GetAllPokemons()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    //JSON padrao para deserializar e montar os objetos que irão popular nossa collectionView
                    string content = httpClient.GetStringAsync(url).Result;
                    var returnConsult = JsonConvert.DeserializeObject<PokemonCategoryModel>(content);

                    //Linq para fazer a consulta por select
                    foreach (var item in returnConsult.pokemon.Select(x=> x.pokemon).ToList())
                    {
                        ListPokemon.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
