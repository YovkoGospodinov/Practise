function LoadPlayers() {
    var dataSource = GridLoader("api/Players");

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
            field: "Team1.Name",
            title: "Current Team"
        }, {
            field: "Country.Name",
            title: "Birth Country"
        }, {
            field: "BirthDate",
            title: "Birth Date",
            template: "#= kendo.toString(kendo.parseDate(BirthDate, 'yyyy-MM-dd'), 'dd/MM/yyyy') #"
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

    PagerLoader(dataSource);
};