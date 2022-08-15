import { EventEmitter, Output } from '@angular/core';
import { ElementRef, ViewChild } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { Ingredient } from '../../shared/ingredient.model';
import { ShippingListService } from '../shopping-list.service';

@Component({
  selector: 'app-shopping-edit',
  templateUrl: './shopping-edit.component.html',
  styleUrls: ['./shopping-edit.component.css']
})
export class ShoppingEditComponent implements OnInit {
  @ViewChild('nameInput') nameInputRef: ElementRef;
  @ViewChild('amountInput') amountInputRef: ElementRef;
  ///@Output() ingredientAdded = new EventEmitter<Ingredient>();
  constructor(private shoppinglist: ShippingListService) { }

  ngOnInit(): void {
  }

  onAddItem() {
    const newIngredient = new Ingredient(this.nameInputRef.nativeElement.value, this.amountInputRef.nativeElement.value);
    /* this.ingredientAdded.emit(newIngredient);*/
    this.shoppinglist.addIngredients(newIngredient);
  }

}
