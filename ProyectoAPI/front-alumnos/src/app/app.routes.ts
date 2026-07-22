import { Routes } from "@angular/router";
import { AlumnosComponent } from "./alumnos/alumnos";
import { ProfesoresComponent } from "./profesores/profesores";

export const routes: Routes = [
    {
        path: 'Alumno',
        component: AlumnosComponent
    },
    {
        path: 'Profesor',
        component: ProfesoresComponent
    }
];