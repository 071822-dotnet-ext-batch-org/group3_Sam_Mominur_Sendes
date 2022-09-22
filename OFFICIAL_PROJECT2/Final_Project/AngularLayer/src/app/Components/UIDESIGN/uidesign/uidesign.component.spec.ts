import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UIDESIGNComponent } from './uidesign.component';

describe('UIDESIGNComponent', () => {
  let component: UIDESIGNComponent;
  let fixture: ComponentFixture<UIDESIGNComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UIDESIGNComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UIDESIGNComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
