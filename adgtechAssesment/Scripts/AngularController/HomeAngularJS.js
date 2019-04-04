var app = angular.module("HomeApp", [])

app.controller("HomeController", function ($scope, $http) {

    $http.get("/Home/get_record").then(function (d) {
        $scope.record = d.data;
    }, function (error) {
        alert('failed');
    });

    $scope.getForUpdate = function (Incident) {
        $scope.updateIncident_No = Incide.Incident_No;
        $scope.updateIncident_Desc = Incide.Incident_Desc;
        $scope.updateIncident_Priority = Incide.Incident_Priority;
    }

    $scope.update = function () {
        var Incident = {
            Incident_No: $scope.updateIncident_No,
            Incident_Desc: $scope.updateIncidnet_Desc,
            Incident_Priority: $scope.UpdateIncident_Priority,
        };
        $http({
            method: 'POST',
            url: 'home/update_record',
            data: Incident
        }).then(function (d) {
            if (d.data == 'failed') {
                alert('failed');
            }
        })
    }

    $scope.deleterecord = function (id) {
        $http.get('home/delete_record?id=+' + id).then(function (d) {
            alert(d.data);
        }, function (error) {
            alert('failed');
        });
    }

        $scope.showname = function (name1) {
            $scope.name2 = name1;
        }
});