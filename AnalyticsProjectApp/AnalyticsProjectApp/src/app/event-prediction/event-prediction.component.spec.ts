import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventPredictionComponent } from './event-prediction.component';

describe('EventPredictionComponent', () => {
  let component: EventPredictionComponent;
  let fixture: ComponentFixture<EventPredictionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EventPredictionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EventPredictionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
