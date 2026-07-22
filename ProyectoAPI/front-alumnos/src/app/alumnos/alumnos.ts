import { Component } from '@angular/core';

@Component({
  selector: 'app-alumnos',
  standalone:true,
  templateUrl: './alumnos.html',
  styleUrl: './alumnos.css',
})
export class AlumnosComponent {

async guardarAlumno (nombre: string, matricula: string){
  const idEntero =parseInt(matricula, 10);
  const datosAlumno ={
    nombre: nombre,
    id: idEntero
  };

  try {
    let peticion = await fetch('https://localhost:7031/Alumnos',{
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(nombre)
  });

  if (peticion.ok){
    alert("¡Alumno Registrado correctamente!");
  } else {
    alert("¡Error Al Guardar Al Alumno!");
  }
} catch (error) {
  console.error("Error de conexion con la API de alumnos:", error);
}
}
}