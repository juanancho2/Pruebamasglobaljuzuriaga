let baseUrl = "http://localhost:50717/";

$(document).ready(() => {
    $('#btn-accion').click(e => {
        var text = $('#txt-emp').val();
        if (!text.trim() || isNaN(text)) {
            loadEmployees("api/Employees");
        } else {
            loadEmployee("api/Employees/" + parseInt(text));
        }
    });
});

function loadEmployees(url) {
    var tableBody = document.getElementById("table-body");
    $(tableBody).empty();
    $.get(baseUrl + url, function (data) {
        for (const employee of data) {
            var tableRow = createEmployeeRow(employee);
            tableBody.appendChild(tableRow);
        }
    });
}

function loadEmployee(url) {
    var tableBody = document.getElementById("table-body");
    $(tableBody).empty();
    $.get(baseUrl + url, function (data) {
        var tableRow = createEmployeeRow(data);
        tableBody.appendChild(tableRow);
    });
}

function createEmployeeRow(employee) {

    var html = `
        <td>${employee.Id}</td>
        <td>${employee.Name}</td>
        <td>${employee.ContractTypeName}</td>
        <td>${employee.RoleId}</td>
        <td>${employee.RoleName}</td>
        <td>${employee.RoleDescription}</td>
        <td>${employee.HourlySalary}</td>
        <td>${employee.MonthtlySalary}</td>
        <td>${employee.AnnualSalary}</td>
    `;
    var tr = document.createElement("tr");
    tr.innerHTML = html;
    return tr;
}
