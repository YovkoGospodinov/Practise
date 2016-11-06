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
            },
            create: {
                url: "/api/Teams",
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
                    NickName: { validation: { required: true } },
                    Country: { validation: { required: true } },
                    City: { validation: { required: true } },
                    League: { validation: { required: true } },
                    CountryId: { validation: { required: true } },
                    CityId: { validation: { required: true } },
                    LeagueId: { validation: { required: true } }
                }
            }
        }
    });

    return dataSource;
};