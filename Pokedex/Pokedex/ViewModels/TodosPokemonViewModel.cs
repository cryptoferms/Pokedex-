using Newtonsoft.Json;
using Pokedex.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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

        public Command LoadingMore { get; }


        public TodosPokemonViewModel()
        {
            isRunLoading = false;
            ListPokemon = new ObservableCollection<Results>();
            LoadingMore = new Command(CarregarMaisPokemon);
            FeedList();
        }

        //diferente da categoria esse método feed de lista é chamado para quando o usuário abrir a pagina e a consulta ser feita.
        private void FeedList()
        {
            ListPokemon = GetAllPokemons();
        }
        //método responsável por encaminhar o nome do pokemon para nossa página de BuscaPokemon
        public async void ItemSelected(string pokemonName)
        {
            //Messaging center para notificar e enviar o tipo string que é o nome do pokemon, para a outra tela receber.
            MessagingCenter.Send<string>(pokemonName, "Pokemon");
            await App.Current.MainPage.Navigation.PopAsync();
        }

        //request para busca de todos os pokemons
        public ObservableCollection<Results> GetAllPokemons(int qtdPokemon = 20)
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

        public async void CarregarMaisPokemon()
        {
            //activity rodando
            isRunLoading = true;

            //quantidade que já tem mais 20
            int qtdPokemon = ListPokemon.Count + 20;

            //lista de pokemon completa

            var listPokemonsFull = new ObservableCollection<Results>();

            //executando em paralelo

            await Task.Run(() =>
            {
              //busca todos os pokemons através da quantidade estabelecida.
              listPokemonsFull = GetAllPokemons(qtdPokemon);

              //esse método irá limpar a lista buscando sempre +20 pokemons e não duplicando / pesando a aplicação
              ListPokemon.Clear();

              foreach (var pokemon in listPokemonsFull)
              {
                  //adiciona o pokemon na lista
                  ListPokemon.Add(pokemon);
              }

            });
            //aqui o activity irá sumir após a busca ter sido completada.
            isRunLoading = false;
        }
    }
}
