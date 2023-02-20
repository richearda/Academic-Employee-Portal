var userDetails = JSON.parse(window.localStorage.getItem('userDetails'));
var loginFormValidator;

$(document).ready(function () {  
    //Checks if userDetails is not null.
    if (userDetails !== null) {       
        persistUserLogin(userDetails);
    }
    console.log('login handler executed');
    $('[data-toggle="tooltip"]').tooltip();             //enable bootstrap tooltip
    //initialize form validator
    $.validator.setDefaults({
        submitHandler: function () {
            submitCredentials();
        }
    });
    loginFormValidator = $('#loginForm').validate({
        rules: {
            username: {
                required: true
            },
            password: {
                required: true
            }
        },
        messages: {
            username: {
                required: "Please provide your username"
            },
            password: {
                required: "Please provide your password"
            }
        },
        errorElement: 'span',
        errorPlacement: function (error, element) {
            error.addClass('invalid-feedback');
            element.closest('.input-group').append(error);
        },
        highlight: function (element, errorClass, validClass) {
            $(element).addClass('is-invalid');
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).removeClass('is-invalid');
        }
    });       
});

function submitCredentials() {
    console.log('login credentials submitted');
   
    var loginData = {
        username: $('#loginUsername').val().trim(),
        password: $('#loginPassword').val().trim()
    };
    console.log('login datas: ', loginData);  
    console.log("end...");   
}
function AuthenticateUser(username, password) {
    console.log("authenticated...");
    $.ajax({                                        //connect to the API using AJAX
        url: API_URL + 'Authentication/Login',
        type: 'POST',
        dataType: 'json',
        data: JSON.stringify({ "username": username, "password": password }),
        contentType: 'application/json',
        success: function (result) {
            var data = result;
            console.log(result.role);
            console.log("Data: " + JSON.stringify(data));
            if (result.role == "Teacher") {              
                window.location.replace('Teacher/TeacherCourseList');                
                window.localStorage.setItem('userDetails', JSON.stringify(result));
                Toast.fire({
                    icon: 'info',
                    title: 'Login Successfull!'
                });
            }
            else if (result.role == "Dean") {
               
                window.location.replace('Dean/ViewCourseList');
              
                window.localStorage.setItem('userDetails', JSON.stringify(result));
                Toast.fire({
                    icon: 'info',
                    title: 'Login Successfull!'
                });
            }
            else if (result.role == "SchoolAdmin") {
                
                window.location.replace('SchoolAdmin/ManageCalendar');              
                window.localStorage.setItem('userDetails', JSON.stringify(result));
                Toast.fire({
                    icon: 'info',
                    title: 'Login Successfull!'
                });
            }              
        },
        error: function (error) {
            console.log('Error: ', error);
            Toast.fire({
                icon: 'error',
                title: 'Could not connect to the server!'
            });
        }
    });
}
function clearModalForm() {
    if (collegeFormValidator != null) {
        collegeFormValidator.resetForm();
        if ($("input").hasClass("is-invalid"))
            $("input").removeClass("is-invalid");
        console.log("form cleared");
    }
}

//Redirect the user if userDetails is not empty or the user is not log out.
function persistUserLogin(userDetails)
{
   
    console.log("Details: " + userDetails);
    console.log("Role: " + userDetails.role);
    if (userDetails.role == 'Teacher') {
        alert('User is currently logged in, please log out to continue');
        window.location.replace('Teacher/TeacherCourseList');
    }
    else if (userDetails.role == 'SchoolAdmin') {
        alert('User is currently logged in, please log out to continue');
        window.location.replace('SchoolAdmin/ManageCalendar'); 
    }
    else if (result.role == "Dean") {
        alert('User is currently logged in, please log out to continue');
        window.location.replace('Dean/ViewCourseList');
    }
}