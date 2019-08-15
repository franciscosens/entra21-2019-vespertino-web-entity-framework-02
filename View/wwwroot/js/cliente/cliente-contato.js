$(function () {

    $idContatoAlterar = -1;

    $tabelaContatos = $("#tabela-contatos").DataTable({
        ajax: "/contato/obtertodos?idCliente=" + $idCliente,
        serverSide: true,
        columns: [
            { data: "id" },
            { data: "tipo" },
            { data: "valor" },
            {
                render: function (data, type, row) {
                    return "\
            <button class='btn btn-primary botao-editar' data-id='" + row.id + "'>Editar</button>\
            <button class='btn btn-danger botao-apagar' data-id='" + row.id + "'>Apagar</button>";
                }
            }
        ]
    });

    $("#modal-contato-salvar").on("click", function () {
        $tipo = $("#modal-contato-tipo").val();
        $valor = $("#modal-contato-valor").val();

        if ($idContatoAlterar == -1) {
            inserir($tipo, $valor);
        } else {
            editar($tipo, $valor);
        }
        
    });

    function inserir($tipo, $valor) {
        $.ajax({
            url: "/contato/inserir",
            method: "post",
            data: {
                idCliente: $idCliente,
                tipo: $tipo,
                valor: $valor
            },
            success: function (data) {
                $("#modal-contato").modal("hide");
                $tabelaContatos.ajax.reload();
            },
            error: function (err) {
                alert("Não foi possível inserir o contato");
            }
        })
    }

    function editar($tipo, $valor) {
        $.ajax({
            url: "/contato/editar",
            method: "post",
            data: {
                idCliente: $idCliente,
                id: $idContatoAlterar,
                tipo: $tipo,
                valor: $valor
            },
            success: function (data) {
                $("#modal-contato").modal("hide");
                $tabelaContatos.ajax.reload();
                $idContatoAlterar = -1;
            },
            error: function (err) {
                alert("Não foi possível alterar o contato");
            }
        })
    }

    $(".table").on("click", ".botao-editar", function () {
        $idContatoAlterar = $(this).data("id");
        $.ajax({
            url: "/contato/obterpeloid?id=" + $idContatoAlterar,
            method: "get",
            success: function (data) {
                $("#modal-contato-tipo").val(data.tipo);
                $("#modal-contato-valor").val(data.valor);
                $("#modal-contato").modal("show");
                $("#modal-contato-tipo").focus();
            },
            error: function (err) {
                alert("Não foi possível buscar o registro");
            }
        });
    });


    $(".table").on("click", ".botao-apagar", function () {
        $id = $(this).data("id");
        $.ajax({
            url: "/contato/apagar?id=" + $id,
            method: "get",
            success: function (data) {
                $tabelaContatos.ajax.reload();
            },
            error: function (err) {
                alert("Não foi possível apagar o registro");
            }
        });
    });



});