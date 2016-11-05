function GridLoader(url) {
	var dataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: url,
                    dataType: "json"
                },
                update: {
                    url: url,
                    type: "Post",
                    dataType: "json"
                }
            },
            pageSize: 5,
            schema: {
                model: {
                    id: "Id"
                }
            }
	});

	return dataSource;
};