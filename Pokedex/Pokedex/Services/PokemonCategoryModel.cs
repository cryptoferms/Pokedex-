using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Services
{
    //propriedades responsáveis por filtrar pela categoria de pokemon, recendo da pokeapi
    public class PokemonCategoryModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<PokemonCategoria> pokemon { get; set; }
    }

    public class PokemonCategoria
    {
        public int slot { get; set; }
        public Results pokemon { get; set; }

    }
}
