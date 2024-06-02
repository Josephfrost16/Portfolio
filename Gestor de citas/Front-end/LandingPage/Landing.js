
document.querySelector("#graphicbutton").addEventListener("click", function () {
  window.location.href="../GraphicAnalize/graficos.html "

});

document.querySelector("#Listbutton").addEventListener("click", function () {
  window.location.href="./Landing.html"

});

document.querySelector("#CategoryButton").addEventListener("click", function () {
  window.location.href="../Management/CategoriasM.html"

});

document.querySelector("#Gastosbutton").addEventListener("click", function () {
  window.location.href="../Management/GastosM.html"
});

// Sera posible guardar un evento en LocalStorage?

let IDUsuario = localStorage.getItem('IdUsuario');

let url = `https://localhost:7250/api/Categorias/GetCategorias_Activas?IDLogeado=${IDUsuario}`;

let i;
const HTMLResponseBody = document.querySelector("#tabla-Categorias");

// Fecth de las categorias: 
fetch(url)
  .then((response) => response.json())
  .then((data) => {
      localStorage.setItem('Categorias', JSON.stringify(data));
    data.forEach((element) => {
    console.log(element);

    // Creacion de las tablas por cagegoria:
      const tablaCategorias = document.createElement("table");
      // Id de las tablas
      const FilaEncabezados = document.createElement("tr");

      const columna1 = document.createElement("th");
      columna1.textContent="Nombre";

      const columna2 = document.createElement("th");
      columna2.textContent="Monto";
      
      //Asignacion de ID unico
      tablaCategorias.id = `tabla-${element.id}`; 

      // Encabezados
      FilaEncabezados.appendChild(columna1);
      FilaEncabezados.appendChild(columna2);

      tablaCategorias.appendChild(FilaEncabezados);

      const titulo = document.createElement("h2");
      titulo.innerHTML = `${element.nombre}`;
      
      HTMLResponseBody.appendChild(titulo);
      HTMLResponseBody.appendChild(tablaCategorias);
      });
  });
// Fecthing de categorias del usuario: -->
let data = [];
const categorias = JSON.parse(localStorage.getItem('Categorias'));

function obtenerGastos(datos) {
      
    datos.forEach(dato=>{
      data.push({
        nombre: dato.nombre,
        presupuesto: dato.presupuesto,
        idCategoria: dato.idCategoria,
        idUsuario: dato.idUsuario
      });

      let indice = data.length - 1;
      let gasto = data[indice]
      const categoria = categorias.find(cat => cat.id === gasto.idCategoria);
      
      if(categoria){
        const TablaCategoria = document.getElementById(`tabla-${categoria.id}`)
       if (TablaCategoria){
  
        const fila = document.createElement("tr");
       
        fila.innerHTML = `
        <td>${gasto.nombre}</td>
        <td>${gasto.presupuesto}</td>
         `;
         TablaCategoria.appendChild(fila); 
        } 

      }
    })
    console.log(data);
  }

let url2 = `https://localhost:7250/api/Gastos/GetGastosByID?IDUsuario=${localStorage.getItem('IdUsuario')}`;

fetch(url2)
  .then((response) => response.json())
  .then((data) => {
    obtenerGastos(data);
      console.log(categorias)
    });
  // });
// Fetch de los gastos del usuario -->