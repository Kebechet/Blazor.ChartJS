if (!window.chartPrison) {
    window.chartPrison = [];
}

window.createChart = (chartId, data) => {
    var ctx = document.getElementById(chartId).getContext('2d');
    var chart = new Chart(ctx, data);
    window.chartPrison.push(chart);
};

window.getChart = (chartId) => {
    return window.chartPrison.find(c => c.canvas.id === chartId);
};

window.updateChart = (chartId, data, options, animationString) => {
    var chart = window.getChart(chartId);
    chart.data = data;
    chart.options = options;
    chart.update(animationString);
};

window.updateChartData = (chartId, data, animationString) => {
    var chart = window.getChart(chartId);
    chart.data = data;
    chart.update(animationString);
};

window.updateChartOptions = (chartId, optionsData, animationString) => {
    var chart = window.getChart(chartId);
    chart.options = optionsData;
    chart.update(animationString);
};

window.clearChartData = (chartId) => {
    var chart = window.getChart(chartId);
    chart.data.labels.length = 0;
    chart.data.datasets.length = 0;
    chart.update("none");
};

window.destroyChart = (chartId) => {
    var chart = window.getChart(chartId);
    var chartIndex = chartPrison.indexOf(chart);
    chartPrison.splice(chartIndex, 1);
    chart.destroy();
};
