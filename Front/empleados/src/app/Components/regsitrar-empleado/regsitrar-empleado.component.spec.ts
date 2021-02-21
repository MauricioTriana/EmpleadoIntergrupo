import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegsitrarEmpleadoComponent } from './regsitrar-empleado.component';

describe('RegsitrarEmpleadoComponent', () => {
  let component: RegsitrarEmpleadoComponent;
  let fixture: ComponentFixture<RegsitrarEmpleadoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegsitrarEmpleadoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegsitrarEmpleadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
