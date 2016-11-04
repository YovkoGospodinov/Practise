function GridLoader(url) {
	var dataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: url,
                    dataType: "json"
                },
                update: {
                    url: url,
                    dataType: "json"
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
            shema: {
                id: "Id"
            },
            pageSize: 5
	});

	return dataSource;
};