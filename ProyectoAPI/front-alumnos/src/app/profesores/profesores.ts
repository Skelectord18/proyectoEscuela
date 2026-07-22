import { Component } from '@angular/core';

@Component({
  selector: 'app-profesores',
  standalone: true,
  templateUrl: './profesores.html',
  styleUrl: './profesores.css',
})
export class ProfesoresComponent {
  async guardarProfesor(nombre: string, matricula: string){
    const idEntero = parseInt(matricula, 10);
    const datosProfesor ={
      nombre: nombre,
      id: idEntero
    };

    try {
      let peticion = await fetch('https://localhost:7031/Profesores', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(datosProfesor)
      });

      if (peticion.ok) {
        alert("¡Profesor registrado con exito!");
      } else {
        alert("Error Al Guardar Al Profesor");
      }

    } catch (error) {
      console.error("Error de conexion con la API de Profesores:", error);
    }
  }
}