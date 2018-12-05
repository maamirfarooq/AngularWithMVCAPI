<!DOCTYPE html>
<html>
<head>
    <title></title>
	<meta charset="utf-8" />
</head>
<body>
 <script src="Scripts/jquery.min.js" type="text/javascript"></script>
        <script src="~/Scripts/jquery-3.3.1.min.js" type="text/javascript"></script>
        <script src="Scripts/highcharts.js" type="text/javascript"></script>
        <script src="~/Scripts/highcharts-custom.src.js"></script>
        <script type="text/javascript" src="/~Scripts/json2.min.js"></script>
        <script type="text/javascript">
        $(document).ready(function () {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Services/HighchartService.asmx/StudentAnalysis",
                data: "{}",
                dataType: "json",
                success: function (Result) {
                    Result = Result.d;
                    var uniqueCat = [];
                    var uniqueProgName = [];
                    $.map(Result, function (ele) {
                        if (uniqueCat.indexOf(ele.CatgType) == -1)
                            uniqueCat.push(ele.CatgType);
                        if (uniqueProgName.indexOf(ele.ProgName) == -1)
                            uniqueProgName.push(ele.ProgName);
                    });
                    var seriesData = [];
                    $.each(uniqueProgName, function () {
                        var series = {};
                        var progName = $(this)[0];
                        series.name = progName;
                        var s = $.grep(Result, function (e) {
                            return e.ProgName == progName;
                        });
                        series.data = $.map(s, function (e) { return e.totalStudents });
                        seriesData.push(series);
                    });
                    DreawChart(uniqueCat, seriesData);
                },
                error: function (Result) {
                    alert("Error");
                }
            });
        });

        function DreawChart(series, seriesData) {
            $('#container').highcharts({
                chart: {
                    type: 'bar',
                    renderTo: 'container'
                },
                title: {
                    text: 'Studentinfo'
                }, xAxis: {
                    categories: eval(series)
                },
                yAxis: {
                    title: {
                        text: 'Figures'
                    }
                },
                plotOptions: {
                    column: {
                        pointPadding: 0.2,
                        borderWidth: 0
                    }
                },
                series: JSON.parse(JSON.stringify(seriesData))
            });
        }
        </script>
    </div>
</body>
</html>
