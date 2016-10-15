////__________________________________________________
/// Ultra Sonic Result
///____________________________________________________
var UltraSonicStatus = function (data, status) {
    $("#UltraSonicStatusResult").html(data);
}



var UltraSonicStartStatus = function (data, status) { 
    $("#UltraSonicStartStatusResult").html(data);
}


var UltraSonicStatusLastRun = function (data, status) {  
    $("#UltraSonicLatestRunResult").html(data);
}

var UltraSonicRemovalResult = function (data, status) {
   
    $("#UltraSonicRemovalResult").html(data);
}



$(document).ready(function () {

    //____________________________________________________________________________
    //Sonic sensor
    //____________________________________________________________________________   

    $("#ButtonUltraSonicStatus").click(function () {
        var url = "/api/ultrasonic/UltraSonicRuns?=" + new Date().getTime();
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
    

    $("#ButtonRemoveUltraSonicsRun").click(function () {
      
        var url = "/api/ultrasonic/RemoveUltraSonicRuns";
        aClient = new HttpClient();
        aClient.delete(url, UltraSonicRemovalResult);
    });

});