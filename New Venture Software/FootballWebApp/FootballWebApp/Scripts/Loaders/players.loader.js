function LoadPlayers() {
    var dataSource = PlayersGridLoader();
    var teamsData = GridLoader("api/Teams");
    var dataCountries = GridLoader("api/Countries");

    $("#grid").kendoGrid({
        dataSource: dataSource,
        toolbar: ["create"],
        columns: [{
            field: "Name",
            title: "Name",
            width: "250px"
        }, {
            field: "Position",
            title: "Position",
            width: "110px"
        }, {
            field: "Team1",
            values: teamsData,
            editor: teamsDropDownEditor, template: "#=Team1.Name#",
            title: "Current Team"
        }, {
            field: "Team",
            values: teamsData,
            editor: teamsDropDownEditor, template: "#=Team.Name#",
            title: "Previous Team"
        }, {
            field: "CountryId",
            values: dataCountries,
            editor: countriesDropDownEditor, template: "#=Country.Name#",
            title: "Birth Country"
        }, {
            field: "BirthDate",
            title: "Birth Date",
            template:'#= kendo.toString(BirthDate, "dd/MM/yyyy") #'
        },
        {
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

    function teamsDropDownEditor(container, options) {
        $('<input required name="' + options.field + '"/>')
            .appendTo(container)
            .kendoDropDownList({
                autoBind: false,
                dataTextField: "Name",
                dataValueField: "Id",
                dataSource: {
                    type: "json",
                    transport: {
                        read: "/api/Teams"
                    }
                }
        });
    }

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

    PagerLoader(dataSource);
};