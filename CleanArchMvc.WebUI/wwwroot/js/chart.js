﻿/* chart.js chart examples */

// chart colors
var colors = ['#007bff', '#28a745', '#333333', '#c3e6cb', '#dc3545', '#6c757d'];


$.ajax({
    url: "Home/GetInformacoesDespesas",
    type: "GET",
    contentType: "application/json",
    success: function (resultado) {
        // Lida com a resposta do servidor (resultado)

        console.log(resultado.products);

        /* 3 donut charts */
        var donutOptions = {
            cutoutPercentage: 85,
            legend: { position: 'bottom', padding: 5, labels: { pointStyle: 'circle', usePointStyle: true } }
        };

        // donut 1 Vamos usar esse aqui
        var chDonutData1 = {
            labels: ['Bootstrap', 'Popper', 'Other'],
            datasets: [
                {
                    backgroundColor: colors.slice(0, 3),
                    borderWidth: 0,
                    data: [74, 11, 40]
                }
            ]
        };

        var chDonut1 = document.getElementById("chDonut1");
        if (chDonut1) {
            new Chart(chDonut1, {
                type: 'pie',
                data: chDonutData1,
                options: donutOptions
            });
        }
    },
    error: function (erro) {
        // Lida com erros (se houver)
        console.error(erro);
    }
});





