
function _Products() {
    var table = $("#Productoes").DataTable({

        responsive: true,

        ajax: {
            url: "/Productoes/_Productos",
            type: "GET",
            dataType: "json"
        },
        columns: [
            { data: "Nombre", "autoWidth": true },
            { data: "IDCategoria", "autoWidth": true },
            { data: "IDProveedor", "autoWidth": true },
            { data: "Precio", "autoWidth": true },
            { data: "Stock", "autoWidth": true },
            { data: "FechaCreado", "autoWidth": true },
            { data: "FechaActualizado", "autoWidth": true }
        ]
    });
}

function myTable() {

}
