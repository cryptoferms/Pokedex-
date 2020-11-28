using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Pokedex.Model
{
    /// <summary>
    /// Essa classe é responsável por retornar o nome dos Pokemons no nosso mecanismo de busca
    /// </summary>
    public class SearchPokemon
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("height")]
        public long Height { get; set; }
        [JsonProperty("base_experience")]
        public long Base_experience { get; set; }
        [JsonProperty("weight")]
        public long Weight { get; set; }
        [JsonProperty("ability")]
        public string Abilities { get; set; }
    }
}
