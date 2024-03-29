$.getJSON("https://www.swollenhippo.com/getEmployeesByAPIKey.php?APIKey=Mickey2021!", function(result){
    console.log(result);
    arrEmployees = result;
    buildEmployeeCard();
    $.each(result,function(i,person){
        $('#txtEmail').val(person.Email);
    })
})




function buildEmployeeCard (){
    $.each(arrEmployees, function(i,person){
        let strHTML = '<div class="card mt-4 ml-2 col-2">';
        strHTML += '<h3 class="text-center"><a href="mailto:' + person.Email + '">' + person.FirstName + ' ' + person.LastName + '</a></h3>';
        strHTML += '<h4 class="text-center">' + person.Postion +'</h4>';
        strHTML += '<h4 class="mt-3">Profile Details</h4>';
        strHTML += '<p>Hire Date: ' + person.HireDate + '</p>';
        strHTML += '<p class="txtHourlyRate" data-rate="' + person.HourlyRate + '">Hourly Rate: ' + person.HourlyRate + '</p>';
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
        $('#tblEmployees tbody').append('<tr><td>' + person.FirstName + '</td><td>' + person.LastName + '</td></tr>');
    });
        $('#tblEmployees').DataTable();
    }

    $(document).on('click','.btnCalculatePay',function() {
        let decHours = $(this).closest('.card').find('.txtHours').val();
        let decRate = $(this).closest('.card').find('.txtHourlyRate').val().split(': ')[1];

        $(this).closest('.card').find('.txtTotalPay').val(decHours * decRate);
    })

