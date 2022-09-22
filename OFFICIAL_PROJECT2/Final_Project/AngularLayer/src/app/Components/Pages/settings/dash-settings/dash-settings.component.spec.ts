import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DashSettingsComponent } from './dash-settings.component';

describe('DashSettingsComponent', () => {
  let component: DashSettingsComponent;
  let fixture: ComponentFixture<DashSettingsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DashSettingsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DashSettingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
