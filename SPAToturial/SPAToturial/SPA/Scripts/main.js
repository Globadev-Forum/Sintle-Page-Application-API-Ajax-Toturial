$(document).ready(function () {
    $(".api-get-all").click(getAll);
    $(".api-get-id").click(GetById);
    $(".api-add").click(Add);
    $(".api-edit").click(Edit);
    $(".api-delete").click(Delete);

});

function getAll() {
    $.ajax({
        url: '/api/Students',
        type: 'GET',
        dataType: 'json', // type of response data
        timeout: 500,     // timeout milliseconds
        success: function (data, status, xhr) {   // success callback function
            var str = JSON.stringify(data, null, 2);
            $('.api-results').empty().append(str);
        },
        error: function (jqXhr, textStatus, errorMessage) { // error callback 
            alert("Error:" + errorMessage);
        }
    });
    //----------------------
    $.ajax({
        url: '/api/Students',
        type: 'GET',
        dataType: 'json', // type of response data
        timeout: 500,     // timeout milliseconds       
    }).then(function (data, status, jqXhr) {
        var str = JSON.stringify(data, null, 2);
        $('.api-results').empty().append(str);
    }
    ).catch(function (jqXhr, textStatus, errorMessage) {
        $('p').append('Error: ' + errorMessage);
    });     
    ////----------------------
    $.get('/api/Students')
     .then(function (data, status, jqXhr) {

        var str = JSON.stringify(data, null, 2);
        $('.api-results').empty().append(str);

    }).catch(function (jqXhr, textStatus, errorMessage) {

        $('p').append('Error: ' + errorMessage);

    });  
}

function GetById() {

    var StudentId = $("#inputId").val();

    $.get(`/api/Students/${StudentId}`)
    .then(function (data, status, jqXhr) {

        var str = JSON.stringify(data, null, 2);
        $('.api-results').empty().append(str);

    }).catch(function (jqXhr, textStatus, errorMessage) {

        $('p').append('Error: ' + errorMessage);

    });  
    
}

function Add() {
    var data = {
        StudentName: $("#inputName").val(),
        Age: $("#inputAge").val()
    };

    $.post(`/api/Students`, data)
        .then(function (data, status, jqXhr) {

            var str = JSON.stringify(data, null, 2);
            $('.api-results').empty().append(str);

        }).catch(function (jqXhr, textStatus, errorMessage) {

            $('p').append('Error: ' + errorMessage);

    });  
}

function Edit() {
    var data = {
        StudentId: $("#inputId").val(),
        StudentName: $("#inputName").val(),
        Age: $("#inputAge").val()
    };
    $.ajax({
        url: '/api/Students',
        type: 'PUT',
        data: data,
        dataType: 'json', // type of response data      
    }).then(function (data, status, jqXhr) {
        var str = JSON.stringify(data, null, 2);
        $('.api-results').empty().append(str);
    }
    ).catch(function (jqXhr, textStatus, errorMessage) {
        $('p').append('Error: ' + errorMessage);
    }); 
 
}

function Delete() {
    var StudentId = $("#inputId").val();
    $.ajax({
        url: `/api/Students/${StudentId}`,
        type: 'DELETE',
        dataType: 'json', // type of response data      
    }).then(function (data, status, jqXhr) {
        var str = JSON.stringify(data, null, 2);
        $('.api-results').empty().append(str);
    }
    ).catch(function (jqXhr, textStatus, errorMessage) {
        $('p').append('Error: ' + errorMessage);
    }); 
}
