var currentTab = 0;
document.addEventListener("DOMContentLoaded", function (event) {


    showTab(currentTab);

});

function showTab(n) {
    var x = document.getElementsByClassName("tab");
    //console.log(x);
    //debugger
    //if (n < 2)
    //{
    if (x[n] !== undefined) {
        x[n].style.display = "block";
    }
    //}

    if (n == 0) {
        //       document.getElementById("prevBtn").style.display = "none";
    } else {
        document.getElementById("nextBtn").innerHTML = 'Log In';
    }

    if (n == (x.length - 1)) {
        document.getElementById("nextBtn").innerHTML = "Submit";
    }
    else if (n == (x.length - 2)) {
      
        document.getElementById("nextBtn").innerHTML = 'Log In';

    }
    else {
        //document.getElementById("nextBtn").innerHTML = 'Redirecting ...';
        document.getElementById("nextBtn").innerHTML = 'Redirecting';

        var dots = 0;
        var dotInterval = setInterval(function () {
            if (dots < 3) {
                document.getElementById("nextBtn").innerHTML += '.';
                dots++;
            } else {
                document.getElementById("nextBtn").innerHTML = 'Redirecting';
                dots = 0;
            }
        }, 400);

        document.getElementById("nextBtn").setAttribute("disabled", "disabled");


    }
    fixStepIndicator(n)
}

setTimeout(function () {
    document.getElementById("email").addEventListener("keyup", function (event) {
        event.preventDefault();
        if (event.keyCode === 13) {
            nextPrev(event, 1);
        }
    });
},1000)

document.getElementById("password").addEventListener("keyup", function (event) {
    event.preventDefault();
    if (event.keyCode === 13) {
        nextPrev(event, 1);
    }
});


function nextPrev(event, n) {
    var x = document.getElementsByClassName("tab");
    var emailError = document.getElementById("email-error");
    var emailInput = document.getElementById("email");
    var passwordInput = document.getElementById("password");
    var ReturnUrl = document.getElementById("ReturnUrl");

    if (emailError == null && emailInput.value != "") {
        //debugger
        if (x[currentTab] !== undefined) {
            x[currentTab].style.display = 'none';

        }
        currentTab = currentTab + n;

    }

    if (currentTab == x.length) {

        if (passwordInput.value != "") {

            
            $.post(summitURL, { Email: emailInput.value, Password: passwordInput.value, ReturnUrl: ReturnUrl.value })
                .done(function (response) {
                    //alert("Data Loaded: " + response.Url);
                    window.location = response.Url;
                    //window.open(response.Url)


                });



            //success: function (response) {
            //    //alert(response.Url);
            //    window.open(response.Url, '_blank')
            //},


        } else {
            //alert('test');
            currentTab--;
        }


    }
    showTab(currentTab);
}

//$(document).on("keyup", "#EmailInput", function (e) {
//    e.preventDefault();
//    if (e.originalEvent.code == 'Enter') {
//        alert('as')
//    }
//    console.log(e.originalEvent.code);
//    //alert('ee');
//})

function fixStepIndicator(n) {
    var i, x = document.getElementsByClassName("step");
    for (i = 0; i < x.length; i++) {
        x[i].className = x[i].className.replace(" active", "");
    }
    if (x[n] !== undefined) {
        x[n].className += " active";
    }

}

$("#email").keyup(function () {
    var textNodes = $('label[for="sendCopy"]').contents().filter(function () {
        return this.nodeType == 3;
    });
    textNodes[textNodes.length - 1].nodeValue = $(this).val();
});
