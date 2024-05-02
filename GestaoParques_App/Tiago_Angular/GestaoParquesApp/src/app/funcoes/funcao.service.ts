import { HttpClient, HttpHandler, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { Observable } from 'rxjs';
import { Funcao } from './funcao';

@Injectable({
  providedIn: 'root'
})
export class FuncaoService {

  apiUrl: string = "";
  

  constructor(private httpClient: HttpClient){
    this.apiUrl = environment.apiUrl + "Funcao";
  }


  async create(funcaoBody: any): Promise<Observable<Funcao>> {
    console.log(funcaoBody);

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
        //adicione outros cabeçalhos, como autorização, se necessário
      })
    };
    return await this.httpClient.post<Funcao>(this.apiUrl, funcaoBody, httpOptions); //return observable
  }

  async update(id: number, body: any):  Promise<Observable<Funcao>> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
        //adiciona outros cabeçalhos, como autorização, se necessário

      })
    };
    return this.httpClient.put<Funcao>(this.apiUrl + "/" + id, body, httpOptions); //return observable
  }

  async delete(id: number): Promise<Observable<Funcao>>{
    return this.httpClient.delete<Funcao>(this.apiUrl + "/" + id);//return observable
  }


  async getById(id: number): Promise<Observable<Funcao>>{
    return this.httpClient.get<Funcao>(this.apiUrl + "/" + id); //return observable
  }


  async getAll():Promise<Observable<Funcao[]>>{
    return await this.httpClient.get<Funcao[]>(this.apiUrl);
  }
}
