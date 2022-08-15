import { Component, OnInit } from '@angular/core';
import { Ingredient } from '../shared/ingredient.model';
import { ShippingListService } from './shopping-list.service';

@Component({
  selector: 'app-shopping-list',
  templateUrl: './shopping-list.component.html',
  styleUrls: ['./shopping-list.component.css']
})
export class ShoppingListComponent implements OnInit {
  ingredients: Ingredient[];

  //ingredients: Ingredient[] = [
  //  new Ingredient('Apple', 10), new Ingredient('Banana', 20)  ];
  constructor(private shoppinglist: ShippingListService) { }


  ngOnInit(): void {
    this.ingredients = this.shoppinglist.getIngredients();
    this.shoppinglist.ingredientAdded.subscribe((ingredient: Ingredient[]) => { this.ingredients = ingredient;});
  }

  //onIngredientAdded(ingredient: Ingredient) {
  //  this.ingredients.push(ingredient);
  //}
}
