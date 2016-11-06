function PlayersGridLoader() {
    var dataSource = new kendo.data.DataSource({
        transport: {
            read: {
                url: "/api/Players",
                dataType: "json"
            },
            update: {
                url: "/api/Players",
                type: "Post",
                dataType: "json"
            },
            destroy: {
                url: "/api/Players",
                type: "DELETE",
                dataType: "json"
            }
        },
        pageSize: 5,
        schema: {
            model: {
                id: "Id",
                fields: {
                    Id: { editable: false, nullable: false },
                    Name: { validation: { required: true } },
                    Position: { validation: { required: true } },
                    Country: { defaultValue: { CountryId: 1, CategoryName: "England" } },
                    BirthDate :{ type: "date"}
                }
            }
        }
    });

    return dataSource;
};