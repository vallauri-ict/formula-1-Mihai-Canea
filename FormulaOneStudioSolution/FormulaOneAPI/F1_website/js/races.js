"use strict"

var table, card;

$(document).ready(function () {
    var app = new Vue({
        el: '#wrapper',
        data: function () {
            return {
                races: [],
            }
        },
        methods: {
            ShowRaces: function () {
                var uri = '../api/races';
                var myData;
                $.getJSON(uri)
                    .done((data) => {
                        this.races = data;
                        console.log(data)
                    });
            }
        },
    });

    app.ShowRaces();
});