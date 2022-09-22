import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShareProductComponent } from './share-product.component';

describe('ShareProductComponent', () => {
  let component: ShareProductComponent;
  let fixture: ComponentFixture<ShareProductComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShareProductComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShareProductComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
