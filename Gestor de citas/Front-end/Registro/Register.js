let url = "https://localhost:7250/api/Usuarios/Registro";

document.getElementById("loginbutton").addEventListener("click", function () {

    var nombre = document.getElementById("Nombre").value;
    var username = document.getElementById("username").value;
    var password = document.getElementById("password").value;

    fetch(url, {
        method: 'POST', 
        headers: {'Content-Type': 'application/json',},
        body: JSON.stringify({
            Nombre: nombre,
            Correo: username,
            Password: password,
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
        if (data) {
            // Respuesta de la Api positiva'
            window.location.href = '../login.html';
        } else {
            // Invalid username or password
            alert("Invalid username or password");
        }
    })
});
