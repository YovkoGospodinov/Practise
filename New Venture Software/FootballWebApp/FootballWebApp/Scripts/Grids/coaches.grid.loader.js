function CoachesGridLoader() {
    var dataSource = new kendo.data.DataSource({
        transport: {
            read: {
                url: "/api/Coaches",
                dataType: "json"
            },
            update: {
                url: "/api/Coaches",
                type: "Post",
                dataType: "json"
            },
            destroy: {
                url: "/api/Coaches",
                type: "DELETE",
                dataType: "json"
            },
            create: {
                url: "/api/Coaches",
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
                    Team: { validation: { required: true } },
                    TeamId: { validation: { required: true } }
                }
            }
        }
    });
    
    return dataSource;
};