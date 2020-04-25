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
                if ($('#selectedYear').text() == 'All')
                    $('#selectedYear').text('');
                var uri = 'api/' + $('#selectedYear').text()+'/drivers/';
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

    $('.dropdown-menu a').click(function () {
        $('#selectedYear').text($(this).text());
    });
});