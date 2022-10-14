//// DOCUMENTATION: https://developers.google.com/chart/interactive/docs/gallery/linechart
// Load the Visualization API and the corechart package.
google.charts.load('current', { 'packages': ['corechart'] });
// Set a callback to run when the Google Visualization API is loaded.
google.charts.setOnLoadCallback(drawTrendlines);
// Callback that creates and populates a data table,
// instantiates the pie chart, passes in the data and
// draws it.
function drawTrendlines(candles = null) {
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
// function to convert unix timestamps to DateTime
function jsDate(unix_timestamp) {
    return new Date(unix_timestamp * 1000);
}