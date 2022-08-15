import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GameContolComponent } from './game-contol.component';

describe('GameContolComponent', () => {
  let component: GameContolComponent;
  let fixture: ComponentFixture<GameContolComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GameContolComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GameContolComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
