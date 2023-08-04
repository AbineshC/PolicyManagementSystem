import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClaimsAddComponent } from './claims-add.component';

describe('ClaimsAddComponent', () => {
  let component: ClaimsAddComponent;
  let fixture: ComponentFixture<ClaimsAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClaimsAddComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClaimsAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
