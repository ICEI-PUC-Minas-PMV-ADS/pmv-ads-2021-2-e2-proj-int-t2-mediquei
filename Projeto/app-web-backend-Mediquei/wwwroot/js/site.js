// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $("#signup-form").submit(function () {
        var nm1 = $("#name1").val();
        var ps1 = $("#pass1").val();
        localStorage.setItem("n1", nm1);
        localStorage.setItem("p1", ps1);

    });

    $("#login-form").submit(function (event) {
        event.preventDefault()
        var enteredName = $("#name2").val();
        var enteredPass = $("#pass2").val();

        var storedName = localStorage.getItem("n1");
        var storedPass = localStorage.getItem("p1");

        if (enteredName == storedName && enteredPass == storedPass) {
            alert("Logado com sucesso");
            window.location.href = "/homelogin.html";
        }
        else {
            alert("Dados não encontrados");
        }

    });

});