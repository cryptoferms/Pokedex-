using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Services
{
    public class TodosPokemonModel
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<Results> results { get; set; }
        
    }
    public class Results
    {
        public string name { get; set; }

        public string image 
        { 
            get
            {
                return  $"https://img.pokemondb.net/artwork/{name}" + ".jpg";
            }
        }
    }
}
