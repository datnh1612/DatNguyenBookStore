/// <reference path="../plugins/angular/angular.js" />

var myApp = angular.module("myModule", []);

myApp.controller("myController", myController);

// declare
function myController($sco) {
    $sco.message = "this is my message from controller";
    // message is just a variable inited by user, not a attribute
}