import { Component, OnInit } from '@angular/core';
import { Funcao } from '../funcao';
import { FuncaoService } from '../funcao.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-list-funcoes',
  templateUrl: './list-funcoes.component.html',
  styleUrl: './list-funcoes.component.css'
})
export class ListFuncoesComponent implements OnInit {
  funcoesList: Funcao[] = [];
  funcao?: Funcao = undefined;
  constructor(private service: FuncaoService) {

  }
  ngOnInit(): void {
    this.service.getAll().then((data: Observable<Funcao[]>) => {
      data.subscribe(list => {
        console.log(list);
        this.funcoesList = list;
      });

    }).catch(error => {
      console.log(error);
    })

  }
}
