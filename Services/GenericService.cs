using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Services
{
    public class GenericServices<T> : IGenericService<T> where T : class
    {
        private readonly HttpClient _http;
        readonly HttpClientHandler _clientHandler;
        //Resources 
        private string url = "https://rickandmortyapi.com/api/character";

        public GenericServices()
        {
            //this is to bypass ssl certificate 
            _clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };
            _http = new HttpClient(_clientHandler);
        }

        public async Task<IEnumerable<T>> GetCharactersAsync(string SearchTerm = "", int page = 1)
        {
            if (SearchTerm == "")
            {
                url = $"{url}/?name={SearchTerm}&page={page}";
            }
            else
            {
                url = $"{url}/?page={page}";
            }
            var response = await _http.GetStringAsync(url);
            var data = JsonConvert.DeserializeObject<IEnumerable<T>>(response);
            return data;
        }

        public async Task<T> GetCharacterByIdAsync(int Id)
        {
            url = $"{url}/{Id}";
            var response = await _http.GetStringAsync(url);
            var result = JsonConvert.DeserializeObject<T>(response);
            return result;
        }

        public IEnumerable<T> GetCharacters(string SearchTerm, int limit = 20)
        {
            throw new NotImplementedException();
        }
    }
}
