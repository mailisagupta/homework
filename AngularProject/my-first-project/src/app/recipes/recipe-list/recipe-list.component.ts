import { Output } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { Recipe } from '../recipe.model';
import { RecipeService } from '../recipe.service';
 
@Component({
  selector: 'app-recipe-list',
  templateUrl: './recipe-list.component.html',
  styleUrls: ['./recipe-list.component.css']
})
export class RecipeListComponent implements OnInit {
  //recipes: Recipe[] = [
  //  new Recipe('A Test Recipe', 'This is a simple test',
  //    'https://cookieandkate.com/images/2018/08/crisp-apple-kohlrabi-salad-recipe-1.jpg'),
  //  new Recipe('Mailisas Recipe', 'Mailisas Recipe',
  //    'https://cookieandkate.com/images/2018/08/crisp-apple-kohlrabi-salad-recipe-1.jpg') ];

  recipes: Recipe[];
  constructor(private recipeservice: RecipeService) { }

  ngOnInit(): void {
    this.recipes = this.recipeservice.getRecipe();
  }

 // @Output() recipeWasSelected = new EventEmitter<Recipe>();
  //onrecipeSelected(recipe: Recipe) {
  //  this.recipeWasSelected.emit(recipe);
  //}

}
