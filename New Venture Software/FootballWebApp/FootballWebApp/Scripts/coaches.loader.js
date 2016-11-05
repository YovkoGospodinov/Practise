function LoadCoaches() {
    var dataSource = GridLoader("api/Coaches");

    $("#grid").kendoGrid({
        dataSource: dataSource,
        dataBound: function () {
            var grid = this;
            var trs = this.tbody.find('tr').each(function () {
                var item = grid.dataItem($(this));
            });
        },
        toolbar: ["create"],
        columns: [{
            field: "Name",
            title: "Name"
        }, {
            field: "Team.Name",
            title: "Team"
         
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