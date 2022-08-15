import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  name = 'mailisa';
  UserName = '';
  DisplayButton = false;
  /*log:number[]=[];*/
  log: Date[] = [];
  oddNumber: number[] = [];
  evenNumber: number[] = [];

  disableButton(){
    if (this.UserName === '') {
      return true;
    }
    else
      return false;
  }

  OnButtonClick() {
    this.UserName = '';
    return this.UserName;
  }
  OnDisplayButton() {
    this.DisplayButton = !this.DisplayButton;
    /*this.log.push(this.log.length + 1);*/
    this.log.push(new Date());
  }
  onIntervalFired(firedNumber: number) {
    console.log(firedNumber);
    if (firedNumber % 2 === 0) {
      this.evenNumber.push(firedNumber);

    } else {
      this.oddNumber.push(firedNumber);
    }
  }

  loadedFeature: string ='recipe';
  onNavigate(feature: string) {
    this.loadedFeature = feature;
  }

  @ViewChild('templateref') public templateref: TemplateRef<any>;

  ngOnInit() {
  console.log('in ngoninit ' + this.templateref);  ///templateref is used to access ng-template or group of elements(for example all the elements that are under the div block). the elementref is used to access the element like input, a, button...etc
  }

}
