import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { EstudianteService } from 'src/servicios/estudiante.service';

@Component({
    selector: 'app-buscar',
    templateUrl: './buscar.component.html',
    styleUrls: ['./buscar.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush,
    providers: [EstudianteService]
})
export class BuscarComponent {
  constructor(private estudianteService : EstudianteService, private _formBuilder : FormBuilder) { }
  buscarEstudiante = this._formBuilder.group({
    name: [''],
    id: ['']
  });

  buscar(){
    var nombreEstudiante = this.buscarEstudiante.value.name as string;
    this.estudianteService.postObtenerIdEstudiante(nombreEstudiante).subscribe(data => {
      console.log(data);
      var id= data.toString();
      this.buscarEstudiante.controls['id'].setValue(id);
    });
  }
}
