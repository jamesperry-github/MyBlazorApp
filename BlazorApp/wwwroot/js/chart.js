////// DOCUMENTATION: https://developers.google.com/chart/interactive/docs/gallery/linechart
//// Load the Visualization API and the corechart package.
google.charts.load('current', { 'packages': ['corechart'] });
//// Set a callback to run when the Google Visualization API is loaded.
google.charts.setOnLoadCallback(drawChart);
//// Callback that creates and populates a data table,
//// instantiates the pie chart, passes in the data and
//// draws it.
function drawChart(timeSeries, duration) {
    console.log("DURATION", duration);
    console.log("timeSeries", timeSeries);
    //storeSessionData(timeSeries);
    // define data table
    var dataTable = new google.visualization.DataTable();
    // column data
    dataTable.addColumn('string', 'Month');
    dataTable.addColumn('number', 'close1');
    dataTable.addColumn('number', 'close2');
    dataTable.addColumn('number', 'close3');
    dataTable.addColumn('number', 'close4');
    dataTable.addColumn({ type: 'string', role: 'tooltip' });
    // row data
    dataTable.addRows(formatChartSeries(timeSeries, duration));
    //
    let createTitle = () => {
        let time = '';
        switch (duration) {
            case "Day": //convertTZ
                time = `${new Date(timeSeries[timeSeries.length - 1].date)}`.split(" ");
                time = `${time[0]} ${time[1]} ${time[2]} ${time[3]}`;
                return `${duration} of ${time} (US/Eastern) (1 min)`;
            case "Week":
                //let time1 = `${new Date(timeSeries[0].date)}`.split(" ");
                //let time2 = `${new Date(timeSeries[timeSeries.length - 1].date)}`.split(" ");
                //return `${duration} of ${time1[0]} - ${time2[0]}`;
                time = `${new Date(timeSeries[timeSeries.length - 1].date)}`.split(" ");
                time = `${time[0]} ${time[1]} ${time[2]} ${time[3]}`;
                return `${duration} of ${time} (US/Eastern)`;
            case "Month":
                //return `${duration} of ${Intl.DateTimeFormat('en', { month: 'long' }).format(new Date('1'))}`;
                //time = `${Intl.DateTimeFormat('en', { month: 'long' }).format(new Date('1'))}`;
                //return `${duration} of ${time}`;
                time = `${new Date(timeSeries[timeSeries.length - 1].date)}`.split(" ");
                time = `${time[0]} ${time[1]} ${time[2]} ${time[3]}`;
                return `${duration} of ${time} (US/Eastern)`;
            case "Year":
                //time = `${new Date(timeSeries[timeSeries.length - 1].date)}`.split(" ");
                //return `${duration} of ${time[3]}`;
                time = `${new Date(timeSeries[timeSeries.length - 1].date)}`.split(" ");
                time = `${time[0]} ${time[1]} ${time[2]} ${time[3]}`;
                return `${duration} of ${time} (US/Eastern)`;
            default:
                return;
        }
    }
    var options = {
        legend: 'none',
        bar: { groupWidth: '100%' }, // Remove space between bars.
        candlestick: {
            fallingColor: { strokeWidth: 0, fill: '#a52714' }, // red
            risingColor: { strokeWidth: 0, fill: '#0f9d58' }   // green
        },
        title: createTitle(),
        hAxis: {
            title: 'Time',
            textPosition: 'none',
        },
        vAxis: {
            title: 'Price'
        },
    };

    var chart = new google.visualization.CandlestickChart(document.getElementById('chart_div'));
    chart.draw(dataTable, options);
}

function formatChartSeries(data, duration) {

    let row = (index, value) => data[index][value];
    let rows = [];
    for (var i = 0; i < data.length; i++) {
        rows.push([
            row(i, "date"),
            row(i, "open"),
            row(i, "open"),
            row(i, "close"),
            row(i, "close"),
            `Date: ${formatDateLabel(row(i, "date"))}\nOpen: ${row(i, "open")}\nClose: ${row(i, "close")}`,
            //duration && duration == "Day" ?
            //    // daily using 5 min timestamps
            //    `Time: ${formatDateLabel(row(i, "date"))}\nOpen: ${row(i, "open")}\nClose: ${row(i, "close")}` :
            //    // other using datetimes
            //    `Date: ${row(i, "date")}\nOpen: ${row(i, "open")}\nClose: ${row(i, "close")}`
        ]);
    }
    return rows;
}

function formatDateLabel(date) {
    //2022 - 10 - 14T09: 55: 00
    str = date.split("T");
    return str[0] + " " + str[1];
}