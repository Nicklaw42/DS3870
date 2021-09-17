$.getJSON("https://www.swollenhippo.com/getStaffByAPIKey.php?APIKey=DuffManSays,Phrasing!", function(result){
        console.log(result);
        arrEmployee = result;
        buildEmployeeCard();
       
})

function buildEmployeeCard (){
    $.each(arrEmployee, function(i,person){
        let strHTML = '<div class="card mt-4 ml-2 col-2">';
        strHTML += '<h3 class="text-center"><a href="mailto:' + person.Email + '">' + person.FirstName + ' ' + person.LastName + '</a></h3>';
        strHTML += '<h4 class="text-center">' + person.Title +'</h4>';
        strHTML += '<h4 class="mt-3">Profile Details</h4>';
        strHTML += '<p>Home Phone: ' + person.HomePhone + ' </p>';
        strHTML += '<p>State: ' + person.State + ' </p>';
        strHTML += '<p>City: ' + person.City + ' </p>';
        strHTML += '<p>Street Address: ' + person.StreetAddress1 + ' </p>';
        strHTML += '<h4 class="mt-3">Pay Detils</h4>';
        strHTML += '<p class="txtHourlyRate" data-rate="' + person.HourlyWage + '">Hourly Wage: ' + person.HourlyWage + '</p>';
        strHTML += '<h4 class="mt-3">Pay Calculations</h4>';
        strHTML += '<div class="form-group mb-0">';
        strHTML += '<label class="mr-2">Hours Worked</label>';
        strHTML += '<input class="txtHours">';
        strHTML += '</div>';
        strHTML += '<div class="form-group">';
        strHTML += '<label class="mr-2">Total Pay</label>';
        strHTML += '<input class="txtTotalPay" disabled>';
        strHTML += '<button class="btn btn-primary btn-block btnCalculatePay">Calculate Pay</button>'
        strHTML += '</div>';
        strHTML += '</div>';
        $('.divEmployees').append(strHTML);
    })
}