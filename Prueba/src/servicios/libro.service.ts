import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { iLibro } from './models/iLibro';
import { iPrestamo } from './models/iPrestamo';
import { iDevolucion } from './models/iDevolucion';
@Injectable({
  providedIn: 'root'
})
export class LibroService {

  private url = 'http://localhost:5280/api/libro';
  constructor(private _http : HttpClient) { }
  obtenerTodosLibros(){
    return this._http.get<iLibro[]>(this.url);
  }
  prestarLibro(prestamo : iPrestamo){
    return this._http.post<any>(`${this.url}/prestar`, prestamo);
  }
  devolverLibro(devolucion : iDevolucion){
    return this._http.post<any>(`${this.url}/devolver`, devolucion);
  }

}
