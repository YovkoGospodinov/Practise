function LoadCoaches() {
    var dataSource = GridLoader("api/Coaches");

    $("#grid").kendoGrid({
        dataSource: dataSource,
        columns: [{
            field: "Name",
            title: "Name"
        }, {
            field: "Team.Name",
            title: "Team"
         
        }],
        sortable: true,
        filterable: true,
        editable: true,
        scrollable: true
    });

    PagerLoader(dataSource);
};