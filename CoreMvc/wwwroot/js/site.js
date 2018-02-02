function onComplete()
{
    alert("Salvo!");
};

function abrirJanelaDiario(data, partial)
{
    $("#janelaDiario .janela .painelTitulo .titulo").append(" - " + data);
    $("#janelaDiario .janela .diario").append(partial);    
    $("#janelaDiario").show();
}

function fecharJanelaDiario()
{
    $("#janelaDiario").hide();
}

$(document).ready(function() {

    $('#janelaDiario .fechar').on('click', function () {
        fecharJanelaDiario();
    });

    if ($("#calendario2") != null)
    {
        $('#calendario2').fullCalendar({
            // put your options and callbacks here
            locale: "pt-br",
            validRange: {
                start: '2018-02-01',
                end: '2018-05-25'
            },
            dayClick: function() {
                var moment = $('#calendario2').fullCalendar('getDate');
                
                $.ajax("/AtividadesRealizadas/Diario")
                .done(function (partial) {                    
                    abrirJanelaDiario(moment.format(), partial);
                })
                .fail(function () {
                    alert("Falha!");
                });
                //alert("The current date of the calendar is " + moment.format());
            }
            
        })
    }
});

