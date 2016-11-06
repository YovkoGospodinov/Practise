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
            },
            create: {
                url: "/api/Players",
                type: "Post",
                dataType: "json"
            }
        },
        pageSize: 5,
        schema: {
            model: {
                id: "Id",
                fields: {
                    Id: { editable: false, nullable: true },
                    Name: { validation: { required: true } },
                    Position: { validation: { required: true } },
                    Team1: { validation: { required: true } },
                    Team1Id: { validation: { required: true } },
                    Country: { validation: { required: true } },
                    CountryId: { validation: { required: true } },
                    BirthDate: { type: "date" },
                    MonthlyWage: { editable: true, nullable: true },
                    PreviousTeadmId: { editable: true, nullable: true }
                }
            }
        }
    });

    return dataSource;
};