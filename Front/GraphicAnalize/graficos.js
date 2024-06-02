

document.querySelector("#graphicbutton").addEventListener("click", function () {
    window.location.href="./graficos.html "
  
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

const categorias = JSON.parse(localStorage.getItem("Categorias"));


    console.log(categorias)

    const nombresCategorias = categorias.map(categoria => categoria.nombre);
    console.log("Nombres de las categorías:", nombresCategorias);

    if(categorias){

        // labels.append(category.nombre);    
        let nombres =[]
        let indice;
        // Datos del gráfico
        indice = nombresCategorias.length -1;
        const data = {
            labels: [nombresCategorias[0],nombresCategorias[1]],
            datasets: [{
                label: 'Volumen de gastos',
                data: [12, 19, 3, 5, 2],
                backgroundColor: [
                    'rgba(255, 99, 132, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(255, 206, 86, 0.2)',
                    'rgba(75, 192, 192, 0.2)',
                    'rgba(153, 102, 255, 0.2)'
                ],
                borderColor: [
                    'rgba(255, 99, 132, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(255, 206, 86, 1)',
                    'rgba(75, 192, 192, 1)',
                    'rgba(153, 102, 255, 1)'
                ],
                borderWidth: 1
            }]
        };
        const options = {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        };
        const ctx = document.getElementById('myChart').getContext('2d');
        const myChart = new Chart(ctx, {
            type: 'pie',
            data: data,
            options: options
        });
         // Configuración del gráfico
    
        // Crear el gráfico
   
}

    
   