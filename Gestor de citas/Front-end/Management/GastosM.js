document.querySelector("#graphicbutton").addEventListener("click", function () {
    window.location.href="../GraphicAnalize/graficos.html "
  
  });
  
  document.querySelector("#Listbutton").addEventListener("click", function () {
    window.location.href="../LandingPage/Landing.html"
  
  });
  
  document.querySelector("#CategoryButton").addEventListener("click", function () {
    window.location.href="../Management/CategoriasM.html"
  
  });

  document.querySelector("#Gastosbutton").addEventListener("click", function () {
    window.location.href="../Management/GastosM.html"

  });

let IDUsuario = localStorage.getItem('IdUsuario');

let url = `https://localhost:7250/api/Categorias/GetCategorias_Activas?IDLogeado=${IDUsuario}`;

fetch(url)
  .then((response) => response.json())
  .then((data) => {
    obtenerCategorias(data)
    console.log(data);
})


let selectCategoria = document.getElementById('category');

function obtenerCategorias(datos) {
      
    // Iterar sobre los datos para obtener los nombres de las categorías
    datos.forEach(dato => {
        // Crear un nuevo elemento de opción
        let option = document.createElement('option');
        let nombreCategoria = dato.nombre;
        let idCategoria = dato.id;
        
        // Establecer el valor y texto del option con el nombre de la categoría
        option.value = idCategoria;
        option.text = nombreCategoria;

        // Agregar el option al elemento select
        selectCategoria.appendChild(option);
    });
}


let url3 ="https://localhost:7250/api/Gastos/AgregarGasto";
document.getElementById("gastoButton").addEventListener("click",function(){

    var CategoriaActual = document.getElementById("category").value;
    var Nombreactual = document.getElementById("name").value;
    var MontoActual = document.getElementById("amount").value;

    console.log("Categoría Actual:", CategoriaActual);
    console.log("Nombre Actual:", Nombreactual);
    console.log("Monto Actual:", MontoActual);

    fetch(url3, {
        method: 'POST', 
        headers: {'Content-Type': 'application/json',},
        body: JSON.stringify({
            Nombre: Nombreactual,
            presupuesto:MontoActual,
            estado: true,
            idcategoria: CategoriaActual,
            Idusuario: IDUsuario
        }),
    })
    .then((response) => {
        if (!response.ok) {
            console.log( new Error(`HTTP error! Status: ${response.status}`))
            // throw new Error(`HTTP error! Status: ${response.status}`);
        }
        return response.json();
     })
    .then((data) => {
        // Check Respuesta de la api
        if (data != null) {
            // Respuesta de la Api positiva'
            console.log("Respuesta:" + data);
            alert("¡Gasto agregado exitosamente!");
        } else {
            // Invalid username or password
            alert("Data nula");
        }
    })
})



