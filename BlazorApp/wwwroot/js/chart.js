google.charts.load('current', { 'packages': ['corechart'] });
google.charts.setOnLoadCallback(drawTrendlines);

function drawTrendlines(candles) {
    var data = google.visualization.arrayToDataTable(formatChartSeries(candles.t, candles.c));

    var options = {
        title: 'Company Performance',
        curveType: 'function',
        legend: { position: 'bottom' },
        hAxis: {
            title: 'Time'
        },
        vAxis: {
            title: 'Price'
        },
    };

    var chart = new google.visualization.LineChart(document.getElementById('chart_div'));

    chart.draw(data, options);
}

function formatChartSeries(yArr, xArr) {
    let test = [['Time', 'Stock Price']];
    for (let i = 0; i < yArr.length; i++) {
        test.push([jsDate(yArr[i]), xArr[i]]);
    }
    return test;
}

function jsDate(unix_timestamp) {
    var date = new Date(unix_timestamp * 1000);
    //var hours = date.getHours();
    //var minutes = "0" + date.getMinutes();
    //var seconds = "0" + date.getSeconds();
    //var formattedTime = hours + ':' + minutes.substr(-2) + ':' + seconds.substr(-2);
    //console.log('formattedTime', date);
    return date;
}