using Newtonsoft.Json;
using Pokedex.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace Pokedex.ViewModels
{
    public class TodosPokemonViewModel : BaseViewModel
    {
        public ObservableCollection<Results> ListPokemon { get; set; }


        //propriedade responsável para indiciar o carregamento da pagina
        private bool _isRunLoading;
        public bool isRunLoading
        {
            get { return _isRunLoading; }
            set { SetProperty(ref _isRunLoading, value); }
        }

        public Command CarregandoMais { get; }


        public TodosPokemonViewModel()
        {
            isRunLoading = false;
            ListPokemon = new ObservableCollection<Results>();
            CarregandoMais = new Command(CarregarMaisPokemon);
            FeedList();
        }

        //diferente da categoria esse método feed de lista é chamado para quando o usuário abrir a pagina e a consulta ser feita.
        private void FeedList()
        {
            ListPokemon = GetAllPokemons();
        }

        //request para busca de todos os pokemons
        private ObservableCollection<Results> GetAllPokemons(int qtdPokemon = 20)
        {
            var url = $"https://pokeapi.co/api/v2/pokemon/?offset=0&limit={qtdPokemon}";
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var content = httpClient.GetStringAsync(url).Result;

                    var retorneConsulta = JsonConvert.DeserializeObject<TodosPokemonModel>(content);

                    //results é a lista retornada da model (Todos os Pokemon)
                    return new ObservableCollection<Results>(retorneConsulta.results);

                }
                catch (Exception exc)
                {
                    isRunLoading = false;
                    Console.WriteLine(exc.Message);
                    return new ObservableCollection<Results>();
                }
            }
        }

        private void CarregarMaisPokemon()
        {
            //activity rodando
            isRunLoading = true;

        }
    }
}
