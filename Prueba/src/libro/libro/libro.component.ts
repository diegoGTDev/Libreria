import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { map } from 'rxjs';
import { LibroService } from 'src/servicios/libro.service';
import { iLibro } from 'src/servicios/models/iLibro';
import { iPrestamo } from 'src/servicios/models/iPrestamo';
@Component({
    selector: 'app-libro',
    templateUrl: './libro.component.html',
    styleUrls: ['./libro.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush,
})
export class LibroComponent {
  constructor(private _formBuilder: FormBuilder, private _libroService : LibroService) { }
  prestarLibroForm = this._formBuilder.group({
    idEstudiante: [''],
    Libro: [''],
    FechaDePrestamo: ['']
  });

  libros : iLibro[] = []
  prestamo: iPrestamo = {
    idLector: 0,
    titulo: "",
    fechaPrestamo: ""
  }
  ngOnInit(){
    this.cargarLibros();

  }
  prestar(){
    var fechaPrestamo = new Date(this.prestarLibroForm.value.FechaDePrestamo as string);
    var fechaActual = new Date();
    if (fechaPrestamo < fechaActual){
      alert("No se puede prestar un libro en el pasado");
      return;
    }
    var titulo = (this.prestarLibroForm.controls['Libro'].value as unknown as iLibro).titulo;
    this.prestamo.fechaPrestamo = fechaPrestamo.toISOString();
    this.prestamo.idLector = this.prestarLibroForm.value.idEstudiante as unknown as number;
    this.prestamo.titulo = titulo;
    console.log("Prestamo: ", this.prestamo);
    this._libroService.prestarLibro(this.prestamo).subscribe(
    );
  }
  cargarLibros(){
    this._libroService.obtenerTodosLibros().subscribe(data => {
      this.libros = data;
      console.log(data);
    });
  }


}
