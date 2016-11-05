function LoadTeams() {
    var dataSource = GridLoader("api/Teams");

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
            field: "Country.Name",
            title: "Country"
        }, {
            field: "League.Name",
            title: "League"
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