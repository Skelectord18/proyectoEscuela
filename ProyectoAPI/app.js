const urlAPI= 'https://localhost:7031/Alumnos';
let botonCargar= document.getElementById('btnCargarDatos');
let lista = document.getElementById('ListaResultados');

botonCargar.addEventListener('click', async function(){
    let respuesta = await
    fetch(urlAPI);
    let datos = await respuesta.text();

    Listas.innerHTML = "";
    
    let elementoLista= document.createElement('li');
    elementoLista.textContent = datos;
    lista.appendChild(elementoLista);
});

let botonGuardar = document.getElementById('btnGuardar');
botonGuardar.addEventListener('click', async function (e) {
    e.preventDefault();

let nom= document.getElementById('NombreInput').value;
let mat= document.getElementById('MatriculaInput').value;

let datosJuntos = nom + " - " + mat;

let peticion = await fetch(urlAPI,
    {
        method: 'POST',
        headers: {
            'Content-Type':
            'application/json'
        },
        body:
    JSON.stringify(datosJuntos)
    });

    let msj = await peticion.text();
    alert(msj);
});
