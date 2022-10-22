import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewsTimesViewComponent } from './views-times-view.component';

describe('ViewsTimesViewComponent', () => {
  let component: ViewsTimesViewComponent;
  let fixture: ComponentFixture<ViewsTimesViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewsTimesViewComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewsTimesViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
