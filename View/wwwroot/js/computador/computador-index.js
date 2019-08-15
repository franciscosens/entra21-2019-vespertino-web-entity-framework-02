$(function () {
    $tabelaComputadores = $("#computador-index").DataTable({
        ajax: "/computador/obtertodos",
        serverSide: true,
        columns: [
            { data: "id" },
            { data: "categoria.nome" },
            { data: "nome" },
            { data: "preco" },
            {
                render: function (type, data, row) {
                    return "\
        <a href='/computador/editar?id=" + row.id + "' class='btn btn-primary'>Editar</a>\
        <button data-id='" + row.id + "' class='btn btn-danger botao-apagar'>Apagar</a>";
                }
            }
        ]
    });

    $(".table").on("click", ".botao-apagar", function () {
        $id = $(this).data("id");
        $.ajax({
            url: "/computador/apagar?id=" + $id,
            method: "get",
            success: function (data) {
                $tabelaComputadores.ajax.reload();
            },
            error: function (err) {
                alert("Não foi possível apagar o registro");
            }
        })
    });
});