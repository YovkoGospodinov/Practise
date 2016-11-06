function GridLoader(url) {
	var dataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: url,
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