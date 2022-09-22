import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MakeProductComponent } from './make-product.component';

describe('MakeProductComponent', () => {
  let component: MakeProductComponent;
  let fixture: ComponentFixture<MakeProductComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MakeProductComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MakeProductComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
