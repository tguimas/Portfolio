import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FuncoesComponent } from './funcoes.component';
import { CreateFuncaoComponent } from './create-funcao/create-funcao.component';
import { DeleteFuncaoComponent } from './delete-funcao/delete-funcao.component';
import { ReadFuncaoComponent } from './read-funcao/read-funcao.component';
import { UpdateFuncaoComponent } from './update-funcao/update-funcao.component';
import { ListFuncoesComponent } from './list-funcoes/list-funcoes.component';

const routes: Routes = [
  { path: '', component: FuncoesComponent },
  {path: 'create-funcao', component: CreateFuncaoComponent},
  {path: 'delete-funcao/:id', component: DeleteFuncaoComponent},
  {path: 'read-funcao', component: ReadFuncaoComponent},
  {path: 'update-funcao/:id', component: UpdateFuncaoComponent},
  {path: 'list-funcoes', component: ListFuncoesComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FuncoesRoutingModule { }
