import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrincipalVendasComponent } from './principal-vendas.component';

describe('PrincipalVendasComponent', () => {
  let component: PrincipalVendasComponent;
  let fixture: ComponentFixture<PrincipalVendasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PrincipalVendasComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrincipalVendasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
