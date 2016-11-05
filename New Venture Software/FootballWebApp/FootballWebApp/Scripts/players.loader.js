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
            width: "95px"
        }, {
            field: "Team1.Name",
            title: "Current Team",
        }, {
            field: "Team.Name",
            title: "Previous Team",
        }, {
            field: "Country.Name",
            title: "Birth Country",
            width: "130px"
        }, {
            field: "BirthDate",
            title: "Birth Date",
            template: "#= kendo.toString(kendo.parseDate(BirthDate, 'yyyy-MM-dd'), 'dd/MM/yyyy') #",
            width: "120px"
        }, {
            command: ["edit", "destroy"], title: "", width: "172px"
        }],
        sortable: true,
        filterable: true,
        scrollable: true,
        editable: "inline"
    });

    PagerLoader(dataSource);
};