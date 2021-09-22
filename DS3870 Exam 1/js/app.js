var arrAgent;
$.getJSON("https://www.swollenhippo.com/getProfileDetailsByAPIKey?APIKey=DuffManSays,Phrasing!" , function(result){
    arrAgent = result;
    console.log(result);
    buildAgentCard();
})


function buildAgentCard(){
    $.each(arrAgent, function(i,agent){
        let strHTML = '<div class="card row text-center">';
         strHTML += '<div class="card row text-center">';
         strHTML += '<div class="row">';
         strHTML += '<div id="divProfile">';
         strHTML += '<img src="css/images/profile.png"></img>';
         strHTML += '</div>';
         strHTML += '<div id="divAgentInfo" class="column offset-1">';
         strHTML += '<h2>'+ agent.FirstName +' '+ agent.LastName +'</h2>';
         strHTML += '<h3>CodeName: '+ agent.CodeName +'</h3>';
         strHTML += '<h3>Billing Agency: '+ agent.Agency + '</h3>';
         strHTML += '<h3>Position: '+ agent.Job +'</h3>';
         strHTML += '<h3>HireDate: '+ agent.HireDate +'</h3>';
         strHTML += '</div>';
         strHTML += '</div>';
         strHTML += '<button >Toggle Contact Details</button>';
        $('#divAgent').append(strHTML);
    })
}

