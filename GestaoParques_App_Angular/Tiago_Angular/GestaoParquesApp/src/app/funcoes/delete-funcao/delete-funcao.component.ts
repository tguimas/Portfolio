import { Component, OnInit } from '@angular/core';
import { Funcao } from '../funcao';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FuncaoService } from '../funcao.service';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-update-funcao',
  templateUrl: './delete-funcao.component.html',
  styleUrl: './delete-funcao.component.css'
})
export class DeleteFuncaoComponent implements OnInit {
  funcao: Funcao;
  deleteForm: FormGroup;

  constructor(private service: FuncaoService, private formBuilder: FormBuilder, private route: ActivatedRoute,private router: Router ){
    this.deleteForm = this.formBuilder.group({
      idFuncao: [0, [Validators.required]],
      nomeFuncao: ['', [Validators.required]],
      

    })
    this.funcao = {
      idFuncao: 0,
      nomeFuncao: ''
    }
  }
  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const id = +params['id']; // Captura o ID da rota e converte para número
      this.funcao.idFuncao = id;
      
      this.service.getById(id).then(data => {
        data.subscribe(data=>{
          this.funcao = data;
      }) 
      })
    });
  }

  async eliminar() {
    try {
      console.log(this.funcao);
      const id = this.funcao.idFuncao ?? 0;
      await (await this.service.delete(id)).toPromise(); // Convert Observable to Promise
      console.log('Função eliminada com sucesso');
      alert('Função foi eliminada com sucesso');
      this.deleteForm.reset();
      this.funcao = { idFuncao: 0, nomeFuncao: '' };
      this.router.navigate(['/funcoes']);
    } catch (error) {
      console.log('Erro ao eliminar Função:', error);
      if (error instanceof Error) {
        alert('Não foi possível eliminar a Função: ' + error.message);
      } else {
        alert('Não foi possível eliminar a Função.');
      }
      this.router.navigate(['/funcoes']);
    }
  }
  
}   
      