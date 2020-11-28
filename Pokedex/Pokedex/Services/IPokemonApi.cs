using Pokedex.Model;
using Refit;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pokedex.Services
{
    public interface IPokemonApi
    {
        //REFIT
        //Essa interface vai fazer a busca de URL do get na API 
        
        /// <summary>
        /// metodo para retornar a API passando o parameter nome do pokemon
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [Get("/pokemon/{name}")]
        Task<SearchPokemon> GetPokemonAsync(string name);
        Task GetPokemonAsync(Entry entry_pokemon);
    }
}
