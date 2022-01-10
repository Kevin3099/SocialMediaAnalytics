import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventComparisonComponent } from './event-comparison.component';

describe('EventComparisonComponent', () => {
  let component: EventComparisonComponent;
  let fixture: ComponentFixture<EventComparisonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EventComparisonComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EventComparisonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
