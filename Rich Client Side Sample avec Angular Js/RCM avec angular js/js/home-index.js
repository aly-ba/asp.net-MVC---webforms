//home-index-js
function homeIndexController($scope, $http) {
    $scope.dataCount=0;
    $scope.data = [];
    $scope.EstOccuppe = true;

    $http.get("api/v1/questions?inclusReponses=true")
         .then(function (result) {
             //Successful 
             // $scope.data = result.data;
             //je pref  cette methode
             angular.copy(result.data, $scope.data);
             $scope.dataCount = result.data.length;
         },
        function () {
            //Error
            alert("Erreur de chargement des Questions")

        })

        .then(function () {
            $scope.EstOccuppe = false;
        });
}
