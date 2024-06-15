import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BuscarComponent } from 'src/estudiante/buscar/buscar.component';
import { DevolverLibroComponent } from 'src/libro/devolver/devolverLibro.component';
import { LibroComponent } from 'src/libro/libro/libro.component';

const routes: Routes = [
  {path: '', component: LibroComponent},
  {path: 'buscar-estudiante', component: BuscarComponent},
  {path: 'devolver-libro', component: DevolverLibroComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
