﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace BlazorApp1.Components.Pokemon.API.Config
{

    public class resultModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public class pokemonModel
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("next")]
        public Uri Next { get; set; }

        [JsonProperty("previous")]
        public object Previous { get; set; }

        [JsonProperty("results")]
        public resultModel[] Results { get; set; }
    }
    public class Api
    {
        static HttpClient client = new HttpClient();
        public string pokemones = "";
        public Api() 
        {
            if (client.BaseAddress == null)
            {
                //client.BaseAddress = new Uri("https://pokeapi.co/api/v2/pokemon/");
            }

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> Inicializar(string pokemonURL)
        {
           
            HttpResponseMessage response = await client.GetAsync(pokemonURL);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("la solicitud se hizo correctamente");
                pokemones = await response.Content.ReadAsStringAsync();
            }
            return pokemones;
        }

        public async Task<string> Next(string pokemonURL)
        {
            Console.WriteLine(pokemonURL);
            HttpResponseMessage response = await client.GetAsync(pokemonURL);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("la solicitud se hizo correctamente");
                pokemones = await response.Content.ReadAsStringAsync();
            }
            return pokemones;
        }

        public async Task<string> Previous(string pokemonURL)
        {
            Console.WriteLine(pokemonURL);
            HttpResponseMessage response = await client.GetAsync(pokemonURL);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("la solicitud se hizo correctamente");
                pokemones = await response.Content.ReadAsStringAsync();
            }

            return pokemones;
        }

        public pokemonModel getObject()
        {
            pokemonModel model= JsonConvert.DeserializeObject<pokemonModel>(pokemones);
            return model;
        }




    }
}
