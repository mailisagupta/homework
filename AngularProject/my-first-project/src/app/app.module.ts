import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule} from '@angular/forms';
import { AppComponent } from './app.component';
import { AppWarningAlertComponent } from './app-WarningAlert/app-WarningAlert.component';
import { AppSucessAlertComponent } from './app-SucessAlert/app-SucessAlert.component';
import { HeaderComponent } from './header/header.component';
import { RecipesComponent } from './recipes/recipes.component';
import { RecipeListComponent } from './recipes/recipe-list/recipe-list.component';
import { RecipeDetailComponent } from './recipes/recipe-detail/recipe-detail.component';
import { RecipeItemComponent } from './recipes/recipe-list/recipe-item/recipe-item.component';
import { ShoppingListComponent } from './shopping-list/shopping-list.component';
import { ShoppingEditComponent } from './shopping-list/shopping-edit/shopping-edit.component';
import { GameContolComponent } from './game-contol/game-contol.component';
import { OddComponent } from './odd/odd.component';
import { EvenComponent } from './even/even.component';
import { DropDownDirective } from './shared/dropdown-directive';
import { RecipeService } from './recipes/recipe.service';
import { ShippingListService } from './shopping-list/shopping-list.service';
@NgModule({
  declarations: [
    AppComponent,
    AppWarningAlertComponent,
    AppSucessAlertComponent,
    HeaderComponent,
    RecipesComponent,
    RecipeListComponent,
    RecipeDetailComponent,
    RecipeItemComponent,
    ShoppingListComponent,
    ShoppingEditComponent,
    GameContolComponent,
    OddComponent,
    EvenComponent,
    DropDownDirective
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  providers: [RecipeService,ShippingListService],
  bootstrap: [AppComponent]
})
export class AppModule { }
