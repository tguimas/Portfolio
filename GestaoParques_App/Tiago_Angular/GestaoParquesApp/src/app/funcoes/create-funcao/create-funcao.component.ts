import { Component } from '@angular/core';
import { Funcao } from '../funcao';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FuncaoService } from '../funcao.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-create-funcao',
  templateUrl: './create-funcao.component.html',
  styleUrl: './create-funcao.component.css'
})
export class CreateFuncaoComponent {
  funcao: Funcao;
  createForm: FormGroup;

  constructor(private service: FuncaoService, private formBuilder: FormBuilder, private route: ActivatedRoute,private router: Router){
    this.createForm = this.formBuilder.group({
      idFuncao: [0, [Validators.required]],
      nomeFuncao: ['', [Validators.required]]
    })
    this.funcao = {
      idFuncao: 0,
      nomeFuncao: ''
    }
  }

  create() {
    console.log(this.funcao);
    this.service.create(this.funcao).then(data =>{
      data.subscribe(data =>{
        console.log('Função adicionada com sucesso', data);
        alert("Função foi adicionada")
      })
    }).then(()=>{
      this.createForm.reset();
      this.funcao = {
        idFuncao: 0,
        nomeFuncao: ''
      }    
    }).catch(error =>{
      console.log('Função não pode ser criada', error);
      alert("Função não pode ser adicionada")

    })
      
  }



}
