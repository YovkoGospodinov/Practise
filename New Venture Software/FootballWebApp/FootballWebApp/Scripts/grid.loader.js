function GridLoader(url) {
	var dataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: url,
                    dataType: "json"
                },
                update: {
                    url: url,
                    dataType: "jsonp"
                },
                destroy: {
                    url: url,
                    dataType: "json"
                },
                create: {
                    url: url,
                    dataType: "json"
                },
                parameterMap: function (options, operation) {
                    if (operation !== "read" && options.models) {
                        return { models: kendo.stringify(options.models) };
                    }
                }
            },
            batch: true,
            pageSize: 5,
            shema: {
                id: "Id"
                ,
                fields: {
                    Id: { editable: false, nullable: true },
                    Name: { validation: { required: true } },
                    TeamId: { type: "number", validation: { required: true, min: 1} }
                }
            }
	});

	return dataSource;
};