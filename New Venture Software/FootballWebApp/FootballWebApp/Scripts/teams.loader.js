function LoadTeams() {
    var dataSource = GridLoader("api/Teams");

    $("#grid").kendoGrid({
        dataSource: dataSource,
        columns: [{
            field: "Name",
            title: "Name"
        }, {
            field: "NickName",
            title: "Nickname"
        }, {
            field: "Country.Name",
            title: "Country"
        }, {
            field: "League.Name",
            title: "League"
        }],
        sortable: true,
        filterable: true,
        editable: true,
        scrollable: true
    });

    PagerLoader(dataSource);
};