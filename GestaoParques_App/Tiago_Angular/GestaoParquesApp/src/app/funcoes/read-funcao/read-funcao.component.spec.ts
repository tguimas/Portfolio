import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReadFuncaoComponent } from './read-funcao.component';

describe('ReadFuncaoComponent', () => {
  let component: ReadFuncaoComponent;
  let fixture: ComponentFixture<ReadFuncaoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ReadFuncaoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ReadFuncaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
