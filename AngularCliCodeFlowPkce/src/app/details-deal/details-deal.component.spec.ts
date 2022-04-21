import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailsDealComponent } from './details-deal.component';

describe('DetailsDealComponent', () => {
  let component: DetailsDealComponent;
  let fixture: ComponentFixture<DetailsDealComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetailsDealComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailsDealComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
