import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteFuncaoComponent } from './delete-funcao.component';

describe('DeleteFuncaoComponent', () => {
  let component: DeleteFuncaoComponent;
  let fixture: ComponentFixture<DeleteFuncaoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DeleteFuncaoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DeleteFuncaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
