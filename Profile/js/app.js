$.getJSON("https://www.swollenhippo.com/getStaffByAPIKey.php?APIKey=DuffManSays,Phrasing!&Codename=Duchess", function (result){
    console.log(result);
    arrProfileData = result;
    fullProfile(arrProfileData[0]);
    
})

function fullProfile (Employee){
    $('#txtEmployeeName').text(Employee.Firstname + '' + Employee.LastName); 
}