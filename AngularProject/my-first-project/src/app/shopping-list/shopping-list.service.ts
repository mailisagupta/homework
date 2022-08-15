import { EventEmitter } from "@angular/core";
import { Ingredient } from "../shared/ingredient.model";

export class ShippingListService {
private ingredients: Ingredient[] = [
    new Ingredient('Apple', 10), new Ingredient('Banana', 20)];

  ingredientAdded = new EventEmitter<Ingredient[]>();

  
  getIngredients() {
    return this.ingredients.slice();
  }
  addIngredients(ingretient: Ingredient) {
    this.ingredients.push(ingretient);
    this.ingredientAdded.emit(this.ingredients.slice());
  }

  addIngredient(ingredient: Ingredient[]) {
    //for (let i of ingredient) {
    //  this.ingredients.push(i);
    //}

    this.ingredients.push(...ingredient);
    this.ingredientAdded.emit(this.ingredients.slice());


  }
}
