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
            field: "TeamId",
            title: "Current Team"
        }, {
            field: "CountryId",
            title: "Birth Country"
        }, {
            field: "BirthDate",
            title: "Birth Date",
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