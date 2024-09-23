import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ButtonKeyComponent } from './button-key.component';

describe('ButtonKeyComponent', () => {
  let component: ButtonKeyComponent;
  let fixture: ComponentFixture<ButtonKeyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ButtonKeyComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ButtonKeyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
