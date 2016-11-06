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
            }
        },
        pageSize: 5,
        schema: {
            model: {
                id: "Id",
                fields: {
                    Id: { editable: false, nullable: false },
                    Name: { validation: { required: true } },
                    Team: { defaultValue: { TeamId: 1, CategoryName: "Arsenal F.C." } }
                }
            }
        }
    });
    
    return dataSource;
};