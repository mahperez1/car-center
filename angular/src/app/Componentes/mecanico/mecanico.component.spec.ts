import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MecanicoComponent } from './mecanico.component';

describe('MecanicoComponent', () => {
  let component: MecanicoComponent;
  let fixture: ComponentFixture<MecanicoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MecanicoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MecanicoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
