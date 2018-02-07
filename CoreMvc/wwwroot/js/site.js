function onComplete()
{
    alert("Salvo!");
};

function incrementarTotal(event) {
    var elementoQuantidade = $(event.target);
    var elementoTR = elementoQuantidade.closest('tr');
    var quantidade = elementoQuantidade.val();
    var pontos = parseFloat(elementoTR.find('.incPontos').text().replace(',','.').replace(' ',''));
    
    var total = quantidade * pontos;
    elementoTR.find('.incTotal').text(total.toLocaleString('pt'));
}

function abrirJanelaDiario(data, partial)
{
    $("#janelaDiario .janela .painelTitulo .data").text(data.format("L"));
    $("#janelaDiario .janela .diario").append(partial);    
    $("#janelaDiario").show();
    $('body').css('overflow', 'hidden');

    $(".incQuantidade").on("keyup keydown change", function (event)
    {
        incrementarTotal(event);
    });
}

function fecharJanelaDiario()
{
    $("#janelaDiario").hide();
    $('body').css('overflow', 'auto');
}

function carregarCalendario()
{
    $('#calendario2').fullCalendar({
        // put your options and callbacks here
        locale: "pt-br",
        validRange:
        {
            start: '2018-02-01',
            end: '2018-05-25'
        },
        dayClick: function(date, jsEvent, view)
        {
            $.ajax("/AtividadesRealizadas/Diario")
            .done(function (partial) {
                abrirJanelaDiario(date, partial);
            })
            .fail(function () {
                alert("Falha!");
            });            
        }            
    });
}

$(document).ready(function()
{
    $('#janelaDiario .fechar').on('click', function ()
    {
        fecharJanelaDiario();
    });

    if ($("#calendario2") != null)
    {
        carregarCalendario();
    }
});

