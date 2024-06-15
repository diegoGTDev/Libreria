import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { iLibro } from 'src/servicios/models/iLibro';
import { LibroService } from 'src/servicios/libro.service';
import { iDevolucion } from 'src/servicios/models/iDevolucion';
@Component({
    selector: 'app-devolver-libro',
    templateUrl: './devolverLibro.component.html',
    styleUrls: ['./devolverLibro.component.css'],

})
export class DevolverLibroComponent {
  devolverLibroForm = this._formBuilder.group({
    idEstudiante: [''],
    Libro: [''],
  });
  libros : iLibro[] = []
  constructor(private _formBuilder: FormBuilder, private _libroService:LibroService) { }
  ngOnInit(){
    this.cargarlibros();
  }
  devolucion : iDevolucion = {
    idLector: 0,
    titulo: "",
    fechaPrestamo: ""
  }
  devolver(){
    var titulo = (this.devolverLibroForm.controls['Libro'].value as unknown as iLibro).titulo;
    var idEstudiante = this.devolverLibroForm.value.idEstudiante as unknown as number;
    var fechaDevolucion = new Date();
    this.devolucion.idLector = idEstudiante;
    this.devolucion.titulo = titulo;
    this.devolucion.fechaPrestamo = fechaDevolucion.toISOString();
    console.log("Devolucion: ", this.devolucion);
    this._libroService.devolverLibro(this.devolucion).subscribe(data => {
      console.log(data);
    });
  }
  cargarlibros(){
    this._libroService.obtenerTodosLibros().subscribe(data => {
      this.libros = data;
      console.log(data);
    });
  }
 }
