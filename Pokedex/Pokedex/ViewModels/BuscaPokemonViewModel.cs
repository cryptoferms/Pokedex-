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
            GoCategoryPokemon
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
            set { SetProperty(ref _abilities , value); }
        }













        #endregion

        public Command GoCategoryPokemon { get; set; }
        public Command GoAllPokemon { get; set; }
        public Command SearchPokemon { get; set; }


    }
}
