import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateFuncaoComponent } from './create-funcao.component';

describe('CreateFuncaoComponent', () => {
  let component: CreateFuncaoComponent;
  let fixture: ComponentFixture<CreateFuncaoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CreateFuncaoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CreateFuncaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
