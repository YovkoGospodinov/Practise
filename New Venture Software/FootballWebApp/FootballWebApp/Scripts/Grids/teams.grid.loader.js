function TeamsGridLoader() {
    var dataSource = new kendo.data.DataSource({
        transport: {
            read: {
                url: "/api/Teams",
                dataType: "json"
            },
            update: {
                url: "/api/Teams",
                type: "Post",
                dataType: "json"
            },
            destroy: {
                url: "/api/Teams",
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
                    NickName: { validation: { required: true } },
                    Country: { defaultValue: { CountryId: 1, CategoryName: "England" } },
                    League: { defaultValue: { LeagueId: 1, CategoryName: "Premier League" } }
                }
            }
        }
    });

    return dataSource;
};