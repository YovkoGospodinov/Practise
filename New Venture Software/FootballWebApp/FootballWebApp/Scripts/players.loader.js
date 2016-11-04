function LoadPlayers() {
    var dataSource = GridLoader("api/Players");

    $("#grid").kendoGrid({
        dataSource: dataSource,
        columns: [{
            field: "Name",
            title: "Name"
        }, {
            field: "Position",
            title: "Position"
        },{
            field: "Team.Name",
            title: "Team"
        }, {
            field: "Country.Name",
            title: "Birth Country"
        }, {
            field: "BirthDate",
            title: "Birth Date",
            template: "#= kendo.toString(kendo.parseDate(BirthDate, 'yyyy-MM-dd'), 'dd/MM/yyyy') #"
        }],
        sortable: true,
        filterable: true,
        editable: true,
        scrollable: true
    });

    PagerLoader(dataSource);
};