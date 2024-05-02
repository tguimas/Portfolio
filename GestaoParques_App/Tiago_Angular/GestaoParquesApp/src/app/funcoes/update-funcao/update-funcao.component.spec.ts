import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateFuncaoComponent } from './update-funcao.component';

describe('UpdateFuncaoComponent', () => {
  let component: UpdateFuncaoComponent;
  let fixture: ComponentFixture<UpdateFuncaoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UpdateFuncaoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UpdateFuncaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
