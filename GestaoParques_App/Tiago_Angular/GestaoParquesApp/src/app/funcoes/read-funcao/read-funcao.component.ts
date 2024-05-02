import { Component } from '@angular/core';
import { Funcao } from '../funcao';
import { FuncaoService } from '../funcao.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-read-funcao',
  templateUrl: './read-funcao.component.html',
  styleUrls: ['./read-funcao.component.css']
})
export class ReadFuncaoComponent {
  funcaoId: number = 0;
  funcao: Funcao | undefined;

  constructor(private service: FuncaoService) {}

  buscarFuncao(){
    if (!this.funcaoId) {
      alert('Por favor, insira um ID válido.');
      return;
    }
  
      //const observablePromise: Promise<Observable<Funcao>> = this.service.getById(this.funcaoId);
      //const observable: Observable<Funcao> = await observablePromise;

      this.service.getById(this.funcaoId).then(data =>{
        data.subscribe(data => {
          this.funcao = data;
        });
      }).catch (error => {
        console.error('Erro ao buscar função:', error);
      });
      
    }
  
}
