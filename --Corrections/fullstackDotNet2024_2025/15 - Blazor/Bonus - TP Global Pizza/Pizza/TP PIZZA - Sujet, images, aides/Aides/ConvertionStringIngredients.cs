// Dans le sujet, on demande de saisir les ingrédients sous forme d'une chaine du style "annanas, bacon, anchois"


// Dans le Model Ingredient, pour définir qu'il est possible de convertir/cast une chaine caractère en ingrédient et vice-versa
// (définition de cast implicites dans les 2 sens)
public static implicit operator string(Ingredient ingredient) => ingredient.Name ?? "";
public static implicit operator Ingredient(string str) => new Ingredient() { Name = str };


// Dans Blazor :

// pour passer de cette chaine vers une liste d'ingrédients, vous pouvez utiliser cette méthode
List<Ingredient> ingredientsList = ingredientsString.Split(", ")
                                          .Select(ingredient => new Ingredient() {​​​​​​​ PizzaId = pizza.Id, Name = ingredient.Trim() }​​​​​​​)
                                          .ToList();

// à l'inverse pour passer de la liste vers une chaine de caractères, vous pouvez utiliser cette méthode
string ingredientsString = string.Join(", ", ingredientsList);
