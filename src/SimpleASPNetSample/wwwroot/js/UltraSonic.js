////__________________________________________________
/// Ultra Sonic Result
///____________________________________________________
var UltraSonicStatus = function (data, status) {
    $("#UltraSonicStatusResult").html(data);
}

var UltraSonicStatusLastRun = function (data, status) {  
    $("#UltraSonicLatestRunResult").html(data);
}

$(document).ready(function () {

    //____________________________________________________________________________
    //Sonic sensor
    //____________________________________________________________________________   

    $("#ButtonUltraSonicStatus").click(function () {
        var url = "/api/ultrasonic/statuses?=" + new Date().getTime();
        aClient = new HttpClient();
        aClient.get(url, UltraSonicStatus);
    });

    $("#ButtonUltraSonicStartRun").click(function () {
        
        var WebServiceUrl = "/api/ultrasonic/startrun";
        var RunData = { "TimeInSecondsToRunSensor": 3 };        
        aClient = new HttpClient();
        aClient.put(WebServiceUrl, RunData, UltraSonicStartStatus);
    });

    $("#ButtonUltraSonicLastRun").click(function () {       
        var url = "/api/ultrasonic/lastrun?=" + new Date().getTime();
        aClient = new HttpClient();
        aClient.get(url, UltraSonicStatusLastRun);
    });

});