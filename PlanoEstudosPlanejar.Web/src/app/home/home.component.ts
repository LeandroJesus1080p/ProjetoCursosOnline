import { Component, OnInit } from '@angular/core';
import { PlanoServiceService } from '../plano.service.service';
import { UsuarioListar } from '../models/plano.model';

@Component({
  selector: 'app-home',
  imports: [],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {

  usuarios: UsuarioListar[] = [];
  usuariosGeral: UsuarioListar[] = [];

  constructor(private serviceUsuario: PlanoServiceService){

  }
  ngOnInit(): void {
    
    this.serviceUsuario.GetUsuarios().subscribe();
  }

}
