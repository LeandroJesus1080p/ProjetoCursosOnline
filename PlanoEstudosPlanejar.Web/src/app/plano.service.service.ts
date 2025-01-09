import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { Observable } from 'rxjs';
import { UsuarioListar } from './models/plano.model';

@Injectable({
  providedIn: 'root'
})
export class PlanoServiceService {

  ApiUrl = environment.UrlApi

  constructor(private http: HttpClient) {}

  GetUsuarios(): Observable<UsuarioListar[]>{
    return this.http.get<UsuarioListar[]>(this.ApiUrl);
  }
}
