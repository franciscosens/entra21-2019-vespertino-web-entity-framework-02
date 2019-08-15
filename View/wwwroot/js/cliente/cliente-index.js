$(function () {
    $tabelaClientes = $("#tabela-clientes").DataTable({
        ajax: "/cliente/obtertodos",
        serverSide: true,
        columns: [
            { data: "id" },
            { data: "nome" },
            { data: "cpf" },
            {
                render: function (data, type, row) {
                    return "\
            <a href='/cliente/editar?id=" + row.id + "' class='btn btn-primary'>Editar</a>\
            <button data-id='" + row.id + "' class='btn btn-danger botao-apagar'>Apagar</a>";
                }
            }
        ]
    });

    $(".table").on("click", ".botao-apagar", function () {
        $id = $(this).data("id");
        $.ajax({
            url: "/cliente/apagar?id=" + $id,
            method: "get",
            success: function (data) {
                $tabelaClientes.ajax.reload();
            },
            error: function (err) {
                alert("Não foi possível apagar o registro");
            }
        })
    });
});