import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FuncoesRoutingModule } from './funcoes-routing.module';
import { FuncoesComponent } from './funcoes.component';
import { CreateFuncaoComponent } from './create-funcao/create-funcao.component';
import { UpdateFuncaoComponent } from './update-funcao/update-funcao.component';
import { ReadFuncaoComponent } from './read-funcao/read-funcao.component';
import { ListFuncoesComponent } from './list-funcoes/list-funcoes.component';
import { DeleteFuncaoComponent } from './delete-funcao/delete-funcao.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    FuncoesComponent,
    CreateFuncaoComponent,
    UpdateFuncaoComponent,
    ReadFuncaoComponent,
    ListFuncoesComponent,
    DeleteFuncaoComponent
  ],
  imports: [
    CommonModule,
    FuncoesRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class FuncoesModule { }
