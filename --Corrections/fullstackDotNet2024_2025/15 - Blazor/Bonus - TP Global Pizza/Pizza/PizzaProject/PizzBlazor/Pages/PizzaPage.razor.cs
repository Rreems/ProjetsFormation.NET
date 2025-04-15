using Microsoft.AspNetCore.Components;
using PizzCore.Models;
using PizzBlazor.DTOs;
using PizzBlazor.Services;
using System.Text.RegularExpressions;

namespace PizzBlazor.Pages
{
    public partial class PizzaPage 
    {
#nullable disable 
        [Inject]
        public IPizzaService PizzaService { get; set; }
#nullable enable
        private bool Loading { get; set; }
        private bool IsAdminMode { get; set; } = false;
        private Dictionary<Pizza, int> Cart { get; set; } = new Dictionary<Pizza, int>();
        private decimal Total => Cart.Sum(pizza => pizza.Key.Price * pizza.Value);
        private List<Pizza> PizzaList { get; set; } = new();
        private PizzaEditDTO? PizzaToEdit { get; set; } = null; // la pizza que l'on cherche à modifier ou ajouter
        private EditionModes EditionMode { get; set; }
        private enum EditionModes
        {
            Post,
            Put
        }
        protected override async Task OnInitializedAsync()
        {
            Loading = true;
            PizzaList = await PizzaService.GetAll();
            Loading = false;
        }
        private void AddToCart(Pizza pizza)
        {
            if (Cart.ContainsKey(pizza))
                Cart[pizza]++; // on augmente le nombre de pizzas
            else
                Cart.Add(pizza, 1); // on ajoute la nouvelle pizza 1 fois
        }
        private void RemoveFromCart(Pizza pizza)
        {
            if (Cart[pizza] == 1)
                Cart.Remove(pizza);
            else
                Cart[pizza]--;
        }
        private void EmptyCart()
        {
            Cart.Clear();
        }
        private void EditPizza(Pizza pizza)
        {
            PizzaToEdit = new PizzaEditDTO()
            {
                Id = pizza.Id,
                IngredientsString = string.Join(",", pizza.Ingredients!),
                Name = pizza.Name,
                Price = pizza.Price,
                ImageLink = Regex.Split(pizza.ImageLink!, @"https:\/\/localhost:\d{1,4}").Last() // pour éviter d'avoir un lien commençant par http://localhost:XXXX => si on déploie l'application elle ne sera plus sur localhost
            };
            EditionMode = EditionModes.Put;
        }
        private void AddPizza()
        {
            PizzaToEdit = new PizzaEditDTO();
            EditionMode = EditionModes.Post;
        }
        private async Task DeletePizza(int id)
        {
            PizzaList.RemoveAll(p=> p.Id == id);
            await PizzaService.Delete(id);
        }
        private async Task SubmitPizza()
        {
            switch (EditionMode)
            {
                case EditionModes.Post:
                    var pizza2 = new Pizza()
                    {
                        Name = PizzaToEdit!.Name,
                        Price = PizzaToEdit.Price,
                        ImageLink = Regex.Split(PizzaToEdit.ImageLink!, @"https:\/\/localhost:\d{1,4}").Last(),
                        Ingredients = PizzaToEdit.IngredientsString!.Split(",")
                        .Select(ingredient => new Ingredient() { Name = ingredient.Trim() })
                        .ToList()
                    };
                    PizzaList.Add(pizza2);
                    await PizzaService.Post(pizza2);
                    break;
                case EditionModes.Put:
                    var pizza = PizzaList.Find(pizza => pizza.Id == PizzaToEdit!.Id)!;
                    pizza.Name = PizzaToEdit!.Name;
                    pizza.Price = PizzaToEdit.Price;
                    pizza.ImageLink = Regex.Split(PizzaToEdit.ImageLink!, @"https:\/\/localhost:\d{1,4}").Last();
                    pizza.Ingredients = PizzaToEdit.IngredientsString!.Split(",")
                        .Select(ingredient => new Ingredient() { PizzaId = pizza.Id, Name = ingredient.Trim() })
                        .ToList();
                    await PizzaService.Put(pizza);
                    break;
                default:
                    break;
            }

            PizzaToEdit = null;
        }

    }
}
