import { Component, Input, OnInit } from '@angular/core';
import { ShippingListService } from '../../shopping-list/shopping-list.service';
import { Recipe } from '../recipe.model';
import { RecipeService } from '../recipe.service';

@Component({
  selector: 'app-recipe-detail',
  templateUrl: './recipe-detail.component.html',
  styleUrls: ['./recipe-detail.component.css']
})
export class RecipeDetailComponent implements OnInit {

  @Input() recipe: Recipe;
  constructor(private recipeservice: RecipeService) { }

  ngOnInit(): void {
  }

  onAddToShoppingList() {
    this.recipeservice.addIngredientsToShoppingList(this.recipe.ingredient);
  }

}
