import { Ingredient } from "../shared/ingredient.model";

export class Recipe {
  public name: string;
  public description: string;
  public ImagePath: string;
  public ingredient: Ingredient[];

  constructor(name: string, desc: string, imagepath: string, ingredient: Ingredient[]) {
    this.name = name;
    this.description = desc;
    this.ImagePath = imagepath;
    this.ingredient = ingredient;
  }
}
