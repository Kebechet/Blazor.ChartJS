export function beforeStart(options, extensions) {
    console.log("Injecting Chart.js");

    var element = document.createElement('script');
    element.src = "_content/Kebechet.Blazor.ChartJS/Chart.js";
    element.async = true;
    document.body.appendChild(element);

    var element2 = document.createElement('script');
    element2.src = "_content/Kebechet.Blazor.ChartJS/ChartInterop.js";
    element2.async = true;
    document.body.appendChild(element2);
}
