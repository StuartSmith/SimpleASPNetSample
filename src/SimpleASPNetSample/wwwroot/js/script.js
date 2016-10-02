

 function generateUUID() {
        var d = new Date().getTime();
        if (window.performance && typeof window.performance.now === "function") {
            d += performance.now(); //use high-precision timer if available
        }
        var uuid = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = (d + Math.random() * 16) % 16 | 0;
            d = Math.floor(d / 16);
            return (c == 'x' ? r : (r & 0x3 | 0x8)).toString(16);
        });
        return uuid;
 }



////__________________________________________________
/// Servo Status Result
///____________________________________________________
var ServoStatus = function (data, status) {
    $("#ServoStatus").html(data);
}

var ServoStatusResult = function (data, status) {
    var url = "/api/servo/statuses?=" + new Date().getTime();
    aClient = new HttpClient();
    aClient.get(url, ServoStatusResultComplete);
}

var ServoStatusResultComplete = function (data, status) {
    $("#ServoChangeStatusResults").html(data);
   
}
////__________________________________________________
/// Ultra Sonic Result
///____________________________________________________
var UltraSonicStatus = function (data, status) {
    $("#UltraSonicStatusResult").html(data);
}


$(document).ready(function () {

    $("#ButtonJiraTest").click(function () {
        var formData = new FormData();

        var fileParts = ["Hello JIRA!"];
        var blob = new Blob(fileParts, { type: 'text/plain' });


        formData.append("file", blob, "file_name.txt");

        $.ajax({
            url: AJS.contextPath() + "/rest/api/2/issue/ISSUE_ID/attachments",
            type: "POST",
            data: formData,
            headers: {
                "X-Atlassian-Token": "nocheck"
            },
            success: function () {
                console.log("success");
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log("error");
            },
            contentType: false,
            processData: false
        });

    });

    

    //____________________________________________________________________________
    //Servo Statuses and Position
    //____________________________________________________________________________

    $("#ButtonServoStatus").click(function () {
        var url = "/api/servo/statuses?=" + new Date().getTime();
        aClient = new HttpClient();
        aClient.get(url, ServoStatus);
    });

    $("#ButtonServoStatus0").click(function () {
        var WebServiceUrl = "/api/servo/statuses";
        var servoData = { "servoStatus": "zeroDegrees", "description": "LaunchServo", "servoGPIO": 13 };
        servoData.servoStatus = "zeroDegrees";
        aClient = new HttpClient();
        aClient.put(WebServiceUrl, servoData, ServoStatusResult);
    });

    $("#ButtonServoStatus90").click(function () {
        var WebServiceUrl = "/api/servo/statuses";
        var servoData = { "servoStatus": "NinetyDegrees", "description": "LaunchServo", "servoGPIO": 13 };
        servoData.servoStatus = "NinetyDegrees";
        aClient = new HttpClient();
        aClient.put(WebServiceUrl, servoData, ServoStatusResult);
    });

    $("#ButtonServoStatus180").click(function () {
        var WebServiceUrl = "/api/servo/statuses";
        var servoData = { "servoStatus": "OneEightyDegrees", "description": "LaunchServo", "servoGPIO": 13 };
        servoData.servoStatus = "OneEightyDegrees";
        aClient = new HttpClient();
        aClient.put(WebServiceUrl, servoData, ServoStatusResult);
    });

    //____________________________________________________________________________
    //Sonic sensor
    //____________________________________________________________________________   

    $("#ButtonUltraSonicStatus").click(function () {
        var url = "/api/UltraSonic/statuses?=" + new Date().getTime();
        aClient = new HttpClient();
        aClient.get(url, UltraSonicStatus);
    });

});

