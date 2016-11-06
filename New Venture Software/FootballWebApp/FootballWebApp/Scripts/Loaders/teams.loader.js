function LoadTeams() {
    var dataSource = TeamsGridLoader();
    var dataCountries = GridLoader("api/Countries");
    var dataLeagues = GridLoader("api/Leagues");
    var dataCities = GridLoader("api/Cities");

    $("#grid").kendoGrid({
        dataSource: dataSource,
        toolbar: ["create"],
        columns: [{
            field: "Name",
            title: "Name"
        }, {
            field: "NickName",
            title: "Nickname"
        }, {
            field: "CountryId",
            values: dataCountries,
            editor: countriesDropDownEditor, template: "#=Country.Name#",
            title: "Country"
        }, {
            field: "CityId",
            values: dataCities,
            editor: citiesDropDownEditor, template: "#=City.Name#",
            title: "City"
        }, {
            field: "LeagueId",
            values: dataLeagues,
            editor: leaguesDropDownEditor, template: "#=League.Name#",
            title: "League"
        }, {
            command: ["edit", "destroy"], title: "Action", width: "172px"
        }],
        sortable: true,
        selectable: true,
        filterable: true,
        scrollable: true,
        editable: "inline",
        save: function () {
            this.refresh();
        }
    });

    function countriesDropDownEditor(container, options) {
        $('<input required name="' + options.field + '"/>')
            .appendTo(container)
            .kendoDropDownList({
                autoBind: false,
                dataTextField: "Name",
                dataValueField: "Id",
                dataSource: {
                    type: "json",
                    transport: {
                        read: "api/Countries"
                    }
                }
        });
    }

    function leaguesDropDownEditor(container, options) {
        $('<input required name="' + options.field + '"/>')
            .appendTo(container)
            .kendoDropDownList({
                autoBind: false,
                dataTextField: "Name",
                dataValueField: "Id",
                dataSource: {
                    type: "json",
                    transport: {
                        read: "api/Leagues"
                    }
                }
            });
    }

    function citiesDropDownEditor(container, options) {
        $('<input required name="' + options.field + '"/>')
            .appendTo(container)
            .kendoDropDownList({
                autoBind: false,
                dataTextField: "Name",
                dataValueField: "Id",
                dataSource: {
                    type: "json",
                    transport: {
                        read: "api/Cities"
                    }
                }
            });
    }

    PagerLoader(dataSource);
};