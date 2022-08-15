import { EventEmitter, Injectable } from "@angular/core";
import { Ingredient } from "../shared/ingredient.model";
import { ShippingListService } from "../shopping-list/shopping-list.service";
import { Recipe } from "./recipe.model";

@Injectable()
export class RecipeService {
  private recipes: Recipe[] = [
    new Recipe('A Test Recipe', 'This is a simple test',
      'https://cookieandkate.com/images/2018/08/crisp-apple-kohlrabi-salad-recipe-1.jpg', [new Ingredient('meat', 1), new Ingredient('apple', 1)]),
    new Recipe('Mailisas Recipe', 'Mailisas Recipe',
      'https://cookieandkate.com/images/2018/08/crisp-apple-kohlrabi-salad-recipe-1.jpg', [new Ingredient('bread', 1), new Ingredient('orange', 1)])];

  getRecipe() {
    return this.recipes.slice();
  }

  recipeSelected = new EventEmitter<Recipe>();

  constructor(private shoppinglist: ShippingListService) {}

  addIngredientsToShoppingList(ingredient: Ingredient[]) {
    this.shoppinglist.addIngredient(ingredient);}
}
