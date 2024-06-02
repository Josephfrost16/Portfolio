
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
    window.location.href="./GastosM.html"
  });

  let IDUsuario = localStorage.getItem('IdUsuario');

  let url = `https://localhost:7250/api/Categorias/GetCategorias_Activas?IDLogeado=${IDUsuario}`;

  const HTMLResponseBody2 = document.querySelector("#tabla-Categorias");
 
  fetch(url)
  .then((response) => response.json())
  .then((data) => {
    data.forEach((element) => {

    console.log(element);

  // Creacion de las tablas por cagegoria:
  // const tablaCategorias = document.createElement("table");
  // // Id de las tablas
  // const FilaEncabezados = document.createElement("tr");

  // const columna1 = document.createElement("th");
  // columna1.textContent="Nombre";

  // const columna2 = document.createElement("th");
  // columna2.textContent="Monto";
  
  // //Asignacion de ID unico
  // tablaCategorias.id = `tabla-${element.id}`; 

  // // Encabezados
  // FilaEncabezados.appendChild(columna1);
  // FilaEncabezados.appendChild(columna2);

  // tablaCategorias.appendChild(FilaEncabezados);

  // HTMLResponseBody2.appendChild(tablaCategorias);
  
  
  });
});
  
  

  let url2 = "https://localhost:7250/api/Categorias/AgregarCategoria";

  document.getElementById("agregarbutton").addEventListener("click", function(){

    var Nombreactual = document.getElementById("name").value;
    
    fetch(url2, {
        method: 'POST', 
        headers: {'Content-Type': 'application/json',},
        body: JSON.stringify({
            Nombre: Nombreactual,
            Estado: true,
            idusuario: IDUsuario
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
});

  