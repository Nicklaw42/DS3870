var arrVehicles;
$.getJSON("", function(result){
    arrVehicles = result;
    $.each(result,function(i,car){
        $('#divVehicleContainer').append(buildVehicle(car));

    })

})



function buildVehicle(Vehicle){

    return strCardHTML;
}