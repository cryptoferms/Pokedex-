using Pokedex.Services;
using Pokedex.View;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Pokedex.ViewModels
{
    public class BuscaPokemonViewModel : BaseViewModel
    {
        public BuscaPokemonViewModel()
        {
            //chamando o método  que irá Filtrar os pokemon por nome sempre que clicar na busca

            GoCategoryPokemon = new Command(OpenCategoryPokemon);
            GoAllPokemon = new Command(OpenAllPokemon);
            SearchPokemon = new Command(FilterPokemonAction);

            //messagingCenter esperando receber a mensagem com o mesmo nome.
            //quando receber, aciona o método FilterPokemonByName.
            MessagingCenter.Subscribe<string>(this, "Pokemon", (sender) =>
            {
                FilterPokemonByName(sender);
            });
        }

        private void FilterPokemonAction()
        {
             FilterPokemonByName();
        }

        private async void FilterPokemonByName(string nomePokemon = null)
        {
            //string pokemon recebe o que o usuario digitar
            if (string.IsNullOrEmpty(FilterPokemon))
                FilterPokemon = "";
            String pokemon = FilterPokemon.Trim().ToLower();

            if (!string.IsNullOrEmpty(nomePokemon))
                pokemon = nomePokemon;

            try
            {
                //api cliente que recebe nossa URL definida no caminho Base
                var apiClient = RestService.For<IPokemonApi>(BasePath.BaseUrl);
                //essa variavel irá receber a URL com o nome do pokemon
                var pokemonnome = await apiClient.GetPokemonAsync(pokemon);

                //operação feita para exibir a altura em metros e o peso em KG
                float resultHeight = (float)pokemonnome.Height / (float)10;
                float resultWeight = (float)pokemonnome.Weight / (float)10;

                //dados que serão exibidos na view
                NamePokemon = string.Format($"Nome: {pokemonnome.Name}");
                IdPokemon = string.Format($"N°: {pokemonnome.Id}");
                HeightPokemon = string.Format($"Altura: {resultHeight}");
                WeightPokemon = string.Format($"Peso: {resultWeight} KG");
                BaseExperience = string.Format($"Experiência Base: {pokemonnome.Base_experience}");
                Abilities = string.Format($"Habilidades: {pokemonnome.Abilities}");
                Image = string.Format($"https://pokeres.bastionbot.org/images/pokemon/{pokemonnome.Id}.png");
            }

            catch (Exception e)
            {
                Console.WriteLine("Erro na busca de Pokemon, tente novamente mais tarde" + e.Message);
            }

        }

        //Acessa a pagina de todos os pokemons
        private async void OpenAllPokemon()
        {
            await App.Current.MainPage.Navigation.PushAsync(new TodosPokemon());
        }
        //Navega para a pagina de categoria dos Pokemon
        private async void OpenCategoryPokemon()
        {
            await App.Current.MainPage.Navigation.PushAsync(new CategoriaPokemon());
        }

        #region Propriedades de Binding
        private string _idPokemon;
        public string IdPokemon
        {
            get { return _idPokemon; }
            set { SetProperty(ref _idPokemon, value); }
        }
        private string _namePokemon;
        public string NamePokemon
        {
            get { return _namePokemon; }
            set { SetProperty(ref _namePokemon, value); }
        }
        private string _heightPokemon;
        public string HeightPokemon
        {
            get { return _heightPokemon; }
            set { SetProperty(ref _heightPokemon, value); }
        }
        private string _baseExperience;
        public string BaseExperience
        {
            get { return _baseExperience; }
            set { SetProperty(ref _baseExperience, value); }
        }
        private string _weightPokemon;
        public string WeightPokemon
        {
            get { return _weightPokemon; }
            set { SetProperty(ref _weightPokemon, value); }
        }
        private string _image;

        public string Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }

        private string _filterPokemon;

        public string FilterPokemon
        {
            get { return _filterPokemon; }
            set { SetProperty(ref _filterPokemon, value); }
        }
        private string _abilities;

        public string Abilities
        {
            get { return _abilities; }
            set { SetProperty(ref _abilities, value); }
        }













        #endregion

        public Command GoCategoryPokemon { get; set; }
        public Command GoAllPokemon { get; set; }
        public Command SearchPokemon { get; set; }


    }
}
