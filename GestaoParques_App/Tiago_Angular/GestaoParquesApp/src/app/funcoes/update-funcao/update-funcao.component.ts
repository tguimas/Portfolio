import { Component, OnInit } from '@angular/core';
import { Funcao } from '../funcao';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FuncaoService } from '../funcao.service';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-update-funcao',
  templateUrl: './update-funcao.component.html',
  styleUrl: './update-funcao.component.css'
})
export class UpdateFuncaoComponent implements OnInit {
  funcao: Funcao;
  updateForm: FormGroup;

  constructor(private service: FuncaoService, private formBuilder: FormBuilder, private route: ActivatedRoute, private router: Router){
    this.updateForm = this.formBuilder.group({
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
  update() {
    console.log(this.funcao);
    this.service.update(this.funcao.idFuncao, this.funcao).then(data=>{
      data.subscribe(data=>{
        console.log('Função atualizada com sucesso', data);
        alert('Função foi atualizada');
        this.updateForm.reset();
        this.funcao = { idFuncao: 0, nomeFuncao: '' };
      })
      this.router.navigate(['/funcoes']);

    }).catch(error =>{
      console.log('Erro ao atualizar função', error);
        alert('Não foi possível atualizar a função');
    });
  }
  
  
}
