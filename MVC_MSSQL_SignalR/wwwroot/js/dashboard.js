"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/sqlServerHub").build();

$(function () {
    connection.start().then(function () {
        alert('Connected to dashboardHub');
        InvokeTestRecord();
    }).catch(function (err) {
        return console.error(err.toString());
    });
});

// TestRecord
function InvokeTestRecord() {
    connection.invoke("ReceiveSQLServerChange").catch(function (err) {
        return console.error(err.toString());
    });
}

connection.on("GetLastNewTestRecord", function (testRecord) {
    console.log('GetLastNewTestRecord', testRecord)
    var tr;
    tr = $('<tr/>');
    tr.append(`<td>${testRecord.id}</td>`);
    tr.append(`<td>${testRecord.recordTime}</td>`);
    tr.append(`<td>${testRecord.barcode}</td>`);
    $('#tblTestRecord').append(tr);
});