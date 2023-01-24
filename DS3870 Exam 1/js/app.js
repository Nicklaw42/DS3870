var arrAgent;
$.getJSON("https://www.swollenhippo.com/getProfileDetailsByAPIKey?APIKey=DuffManSays,Phrasing!" , function(result){
    arrAgent = result;
    buildAgentCard();

})

function buildAgentCard(){
    $.each(arrAgent, function(i,agent){
        let strHTML = '<div id="divAgentInfo" class="card row">';
         strHTML += '<div class="row">';
         strHTML += '<div id="divProfile">';
         strHTML += '<img src="'+ agent.Image +'" style="border-radius: 50%;" class="mt-3"></img>';
         strHTML += '</div>';
         strHTML += '<div id="divAgentInfo" class="column offset-4">';
         strHTML += '<div class="mb-3">'
         strHTML += '<h2 class="text-info">'+ agent.FirstName +' '+ agent.LastName +'</h2>';
         strHTML += '<h4>CodeName: '+ agent.CodeName +'</h4>';
         strHTML += '</div>'
         strHTML += '<h4>Billing Agency: '+ agent.Agency + '</h4>';
         strHTML += '<h4>Position: '+ agent.Job +'</h4>';
         strHTML += '<h4>HireDate: '+ agent.HireDate +'</h4>';
         strHTML += '</div>';
         strHTML += '</div>';
         strHTML += '<button id="btnToggleContactDetails" type="button" class="btn-primary mb-3 btn btn-large">Toggle Contact Details</button>';
         
        let strHTML2 =  '<div class="card bg-secondary">';
            strHTML2 += '<div class="offset-1">';
            strHTML2 += '<h4> Email: <a class="text-white"> '+ agent.Email + '</a></h4>';
            strHTML2 += '<h4> Phone: <a class="text-white">  '+ agent.Phone + '</a></h4>';
            strHTML2 += '<div class="mt-3 mb-3">';
            strHTML2 += '<h4> Street Address: '+ agent.Street1 +'</h4>';
            strHTML2 += '<h4> City: '+ agent.City + '</h4>';
            strHTML2 += '<h4> State: '+ agent.State + '</h4>';
            strHTML2 += '<h4> Zip Code: '+ agent.ZIP + '</h4>';
            strHTML2 += '</div>';
            strHTML2 += '<h4> Emergency Contact: '+ agent.EContact + '</h4>';
            strHTML2 += '<h4> Phone: <a class="text-white"> '+ agent.EContactNumber + '</a></h4>';
            strHTML2 += '</div>';
            strHTML2 += '</div>';
        $('#divAgent').append(strHTML);
        $('#divAgentContactDetails').append(strHTML2);
    })
}

var arrPayStubs;
$.getJSON("https://www.swollenhippo.com/getPayStubsByAPIKey.php?APIKey=DuffManSays,Phrasing!" , function(result){
    arrPayStubs=result;
    calculateTotalPay();
    populatePayStubs();
    
})

function calculateTotalPay(decHours, decRate, decSales, decCommissionRate){
    let decTotalPay= (decHours * decRate) + (decSales * decCommissionRate);

    return Math.round (decTotalPay);
}


function populatePayStubs (){
    $.each(arrPayStubs ,function(i,stat){
        $('#tblPayStubs tbody').append('<tr><td>'+ stat.Month +'</td><td>'+ stat.Year +'</td><td>'+ stat.Sales +'</td><td>'+ stat.Hours +'</td><td>'+ stat.Rate +'</td><td>'+ stat.CommissionRate +'</td><td>'+ calculateTotalPay(stat.Hours, stat.Rate, stat.Sales, stat.CommissionRate) +'</td></tr>');
    })
    $('#tblPayStubs').DataTable();
}

$(document).on('click','#btnToggleContactDetails', function(){
    $('#divAgentContactDetails').slideToggle();
})

