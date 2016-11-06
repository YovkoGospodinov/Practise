function PagerLoader(dataSource) {
    $("#pager").kendoPager({
        dataSource: dataSource,
        pageSizes: [3, 5, 10, 20]
    });
};