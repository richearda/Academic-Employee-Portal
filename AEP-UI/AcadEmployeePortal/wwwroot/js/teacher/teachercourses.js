var userDetails = JSON.parse(window.localStorage.getItem('userDetails'));
var teacherId;

$(document).ready(function () {
    if (userDetails == null || userDetails.role != "Teacher") {
        window.location.replace('http://localhost:5001/Unauthorized/ReturnUnauthorizedPage');     
    }
    $("#user-image").attr('src', userDetails.pictureLink);
    $("#username").text(userDetails.name);
    $("#user-role").text(userDetails.role);
    console.log('manage course handler executed');
    //initialize datatable
    getTeacherByPersonId(userDetails.personID);
});


function getTeacherByPersonId(personId) {
    $.ajax({                                        //connect to the API using AJAX
        url: API_URL + 'Teacher/GetTeacherByPersonId',
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json',
        data: { 'personId': personId },
        success: function (data) {
            console.log(data);
            $("#username").text(userDetails.name);
            teacherId = data.teacherId;
            console.log("New Teacher ID: " + teacherId);
            getCourseList();
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

//this function will get the records from the API
function getCourseList() {
    console.log($("#personId").val());
    console.log($("#name").val());
    console.log($("#role").val());
    
    $.ajax({                                        //connect to the API using AJAX
        url: API_URL + 'TeacherCourseSchedule/GetList/teacherSchedules',
        type: 'GET',        
        dataType: 'json',
        contentType: 'application/json',
        data: { 'teacherId' : teacherId },
        success: function (data) {                  //data (in JSON form) contains the list of college records retrieved from the API
            var courseData = data;
            console.log('data: ', courseData);
            //for each college record, convert to datatable set
            var courseSet = [];
            $(courseData).each(function (index, item) {
                var courseRecord = new Array(courseData[index].courseSchedules.edpCode, courseData[index].courseSchedules.course.courseCode,
                    courseData[index].courseSchedules.course.courseDescription, courseData[index].courseSchedules.course.units, courseData[index].courseSchedules.course.noOfHours,
                    courseData[index].courseSchedules.course.courseTypeName,courseData[index].courseSchedules.timeStart, courseData[index].courseSchedules.timeEnd, courseData[index].courseSchedules.day);
                courseSet.push(courseRecord);
            });
            //reinitialize datatable with the data set
           
            $('#tblTeacherCourses').DataTable({
                destroy:true,
                paging: true,
                lengthChange: false,
                searching: true,
                ordering: true,
                info: true,
                autoWidth: false,
                responsive: true,
                columns: [
                   
                    { title: "EDP Code" },
                    { title: "Course Code" },
                    { title: "Course Description" },
                    { title: "Units" },
                    { title: "No of Hours" },
                    { title: "Course Type" },
                    { title: "Time Start" },
                    { title: "Time End" },
                    { title: "Day" }
                ],
                columnDefs: [
                    { className: 'text-center', targets: [0, 3] },      //center align selected columns
                    //{ visible: false, targets: [0] }                    //hide first column
                ],
                data: courseSet,
                dom: "Bfrtip",
                buttons: [
                    { extend: 'colvis', text: '<i class="fa-solid fa-eye"></i>', titleAttr: 'Hide or Show column(s)', className: 'btn-success' },
                    { extend: 'excel', text: '<i class="fa-solid fa-file-excel"></i>', titleAttr: 'Download as Excel', className: 'btn-success' },
                    { extend: 'pdf', text: '<i class="fa-solid fa-file-pdf"></i>', titleAttr: 'Download as PDF', className: 'btn-success' },
                    { extend: 'print', title: "", text: '<i class="fa-solid fa-print"></i>', titleAttr: 'Print Record', className: 'btn-success' },
                ]
            });
            $("#tblTeacherCourses_wrapper > .dt-buttons").appendTo("div.buttons-location").addClass("float-right");
            $(".btn-group > button").removeClass("btn-secondary");
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