"use strict"

$(document).ready(function () {
    var app = new Vue({
        el: '#wrapper',
        data: function () {
            return {
                drivers: [],
            }
        },
        methods: {
            sas: function () {
                var uri = 'api/2019/drivers/';
                var myData;
                $.getJSON(uri)
                    .done((data) => {
                        //console.log("Drivers", myData)
                        this.drivers = data;
                        console.log(this.drivers)
                    });
            }
        },
    });
});