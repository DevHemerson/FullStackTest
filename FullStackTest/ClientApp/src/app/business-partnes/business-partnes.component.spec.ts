import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BusinessPartnerListComponent } from './business-partnes.component';

describe('BusinessPartnesComponent', () => {
  let component: BusinessPartnerListComponent;
  let fixture: ComponentFixture<BusinessPartnerListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [BusinessPartnerListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BusinessPartnerListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
