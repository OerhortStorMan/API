using System;
using RestSharp;
using Newtonsoft.Json;

namespace API
{
    class Program
    {
        static void Main(string[] args)
        {
            RestClient client = new RestClient("https://pokeapi.co/api/v2");
            RestRequest request = new RestRequest();

            Pokemon playerPokemon = new Pokemon();

            bool clientActive = true;
            while (clientActive)
            {
                System.Console.WriteLine("Vilken pokemon vill du hitta?");
                string input = Console.ReadLine();
                input = input.ToLower();

                request = new RestRequest("pokemon/" + input);

                IRestResponse response = client.Get(request);

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    System.Console.WriteLine("Den där pokemonen existerar inte eller så har du stavat fel.");
                }
                else
                {
                    playerPokemon = JsonConvert.DeserializeObject<Pokemon>(response.Content);

                    System.Console.WriteLine();
                    System.Console.WriteLine("Name: " + playerPokemon.name);
                    System.Console.WriteLine("ID: " + playerPokemon.id);
                    System.Console.WriteLine("Weight: " + playerPokemon.weight);
                    System.Console.WriteLine();
                }

            }

        }
    }
}
