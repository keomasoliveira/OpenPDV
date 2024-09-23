import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InputKeyComponent } from './input-key.component';

describe('InputKeyComponent', () => {
  let component: InputKeyComponent;
  let fixture: ComponentFixture<InputKeyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InputKeyComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InputKeyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
