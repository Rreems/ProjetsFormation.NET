// cette méthode d'update modifiée permet de mettre à jour une pizza et ses ingrédients directement en une seule fois

public async Task<bool> Update(Pizza pizza)
{
    var pizzaFromDb = await GetById(pizza.Id);

    if (pizzaFromDb == null)
        return false;

    if (pizzaFromDb.Name != pizza.Name)
        pizzaFromDb.Name = pizza.Name;
    if (pizzaFromDb.Price != pizza.Price)
        pizzaFromDb.Price = pizza.Price;
    if (pizzaFromDb.ImageLink != pizza.ImageLink)
        pizzaFromDb.ImageLink = pizza.ImageLink;

    // mettre à jour les ingrédients :
    if (pizza.Ingredients != null)
    {
        // gestion des ingrédients déjà existants en BDD
        foreach (var ingredientFromDb in pizzaFromDb.Ingredients!)
        {
            var ingredientDejaExistant = pizza.Ingredients.FirstOrDefault(i => i.Name == ingredientFromDb.Name);
            // l'ingrédient existe déjà donc pas de modification => on le retire des ingrédients à traiter
            if (ingredientDejaExistant != null)
            {
                pizza.Ingredients.Remove(ingredientDejaExistant);
                continue;
            }
            // l'ingrédient a été retiré de la pizza donc on le retire de la BDD
            _dbContext.Ingredients.Remove(ingredientFromDb);
        }
        // ajout des nouveaux ingrédients (ceux qui restent dans la pizza à traiter)
        foreach (var nouvelIngredient in pizza.Ingredients)
        {
            await _dbContext.Ingredients.AddAsync(nouvelIngredient);
        }
    }
    else
    {
        // la nouvelle pizza n'a pas d'ingrédients => on supprime les ingrédients existants
        foreach (var ingredientFromDb in pizzaFromDb.Ingredients!)
        {
            _dbContext.Ingredients.Remove(ingredientFromDb);
        }
    }

    return await _dbContext.SaveChangesAsync() > 0;
}