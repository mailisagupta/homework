import { HostBinding } from "@angular/core";
import { Directive, HostListener } from "@angular/core";

@Directive({
  selector:'[appDropdown]'
})
export class DropDownDirective {
  @HostBinding('class.open') isOpen = false; ////open is a css class that open the dropdown
  @HostListener('click') toogleOpen() {
    this.isOpen = !this.isOpen;
  }
}
