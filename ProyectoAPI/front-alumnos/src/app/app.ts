import { Component } from '@angular/core';
import { AlumnosComponent } from './alumnos/alumnos';
import { ProfesoresComponent } from './profesores/profesores';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [AlumnosComponent, ProfesoresComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class Appcomponent {
  title = 'UniversidadPOO'
}