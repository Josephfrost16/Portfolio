
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
  
  const perfilLink = document.querySelector(".nav-link");
  let url ="https://localhost:7250/api/Usuarios/GetUsuarios";
  let url2;
  
  let lista = [];
  let indice;
  let MontoComprobado;
  
  const nombreInput = document.getElementById("Nombre");
  const correoInput = document.getElementById("username");
  const passwordInput = document.getElementById("password");
  const MontoInput = document.getElementById("montolimite");
  
  let logeado = localStorage.getItem("IdUsuario");
  
  

fetch(url)
  .then((response) => response.json())
  .then((data) => {
    data.forEach((element) => {
      console.log(element);
      obtener(element);
    });
  });


function obtener(datos) {

  lista.push({
    id: datos.id,
    nombre: datos.nombre,
    correo: datos.correo,
    password: datos.password,
    montoLimite: datos.montoLimite
  })

    indice = lista.length - 1;
    let usuario = lista[indice];


    console.log(usuario.nombre);
    console.log(usuario.id);
    console.log(logeado);

    if (usuario.id == logeado){

        // MontoComprobado = usuario.montoLimite;
        nombreInput.value = usuario.nombre;
        correoInput.value = usuario.correo;
        passwordInput.value = usuario.password;
        MontoInput.value = usuario.montoLimite;

    }
}


document.getElementById("Editbutton").addEventListener("click", function() {
    
    nombreInput.removeAttribute("readonly");
    correoInput.removeAttribute("readonly");
    passwordInput.removeAttribute("readonly");
    MontoInput.removeAttribute("readonly");
    
  });

  document.getElementById("Savebutton").addEventListener("click", function() {


    url2  = ` https://localhost:7250/api/Usuarios/EditarMonto?IDLogeado=${logeado}`;

   
    fetch(url2, {
        method: 'POST', 
        headers: {'Content-Type': 'application/json',},
        body: JSON.stringify({
            Nombre: nombreInput.value,
            montoLimite: MontoInput.value,
            Correo: correoInput.value,
            Password: passwordInput.value
        }),
    })
    .then((response) => {
        if (!response.ok) {
            console.log( new Error(`HTTP error! Status: ${response.status}`))
        }
        console.log(nombreInput.value);
        console.log(MontoInput.value);
        return response.json();
    })  .then((data) => {
      // Check Respuesta de la api
      if (data != null) {
          // Respuesta de la Api positiva'
          fetch(url)
          .then((response) => response.json())
          .then((data) => {
            data.forEach((element) => {
              console.log(element);
              obtener(element);
            });
          });
      } else {
          // Invalid username or password
          alert("Error al editar el usuario");
      }
  })
    MontoInput.setAttribute("readonly","readonly");
    nombreInput.setAttribute("readonly","readonly");
    correoInput.setAttribute("readonly","readonly");
    passwordInput.setAttribute("readonly","readonly");
  });

 
