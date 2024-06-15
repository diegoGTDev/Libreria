import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class EstudianteService {

  constructor(private _http : HttpClient) { }

  private url = 'http://localhost:5280/api/estudiante';
  headers = new HttpHeaders().set('Content-Type', 'application/json');
  postObtenerIdEstudiante(nombre: string){
    var estudiante = {
      "idLector": 0,
      "ci": "string",
      "Nombre": "string",
      "direccion": "string",
      "carrera": "string",
      "edad": 0
    };
    estudiante.Nombre = nombre;
    console.log(estudiante.Nombre);
    var id = this._http.post<number>(this.url, estudiante);
    return id;



  }
}
