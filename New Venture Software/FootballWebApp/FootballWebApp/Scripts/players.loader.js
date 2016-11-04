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
        }, {
            field: "Team.Name",
            title: "Team"
        }, {
            field: "Country.Name",
            title: "Birth Country"
        }, {
            field: "BirthDate",
            title: "Birth Date",
            format: "{0: yyyy-MM-dd}"
        }],
        sortable: true,
        filterable: true,
        editable: true,
        scrollable: true
    });

    PagerLoader(dataSource);
};