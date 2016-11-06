function LoadCoaches() {
    var dataSource = CoachesGridLoader();
    var teamsData = GridLoader("api/Teams");

    $("#grid").kendoGrid({
        dataSource: dataSource,
        toolbar: ["create"],
        columns: [{
            field: "Name",
            title: "Name"
        }, {
            field: "TeamId",
            values: teamsData,
            editor: teamsDropDownEditor, template: "#=Team.Name#",
            title: "Team"
        }, {
            command: ["edit", "destroy"], title: "", width: "172px"
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

    PagerLoader(dataSource);
};