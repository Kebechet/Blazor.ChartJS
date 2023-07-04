﻿if (!window.chartPrison) {
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

window.updateChart = (chartId, data, animationString) => {
    var chart = window.getChart(chartId);
    chart.data = data;
    chart.update(animationString);
};

window.destroyChart = (chartId) => {
    var chart = window.getChart(chartId);
    var chartIndex = chartPrison.indexOf(chart);
    chartPrison.splice(chartIndex, 1);
    chart.destroy();
};