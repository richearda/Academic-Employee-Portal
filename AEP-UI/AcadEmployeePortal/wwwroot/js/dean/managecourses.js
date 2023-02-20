//const { error } = require("jquery");
var userDetails = JSON.parse(window.localStorage.getItem('userDetails'));
var collegeName;


$(document).ready(function () {
    if (userDetails == null || userDetails.role != "Dean") {
        window.location.replace('http://localhost:5001/Unauthorized/ReturnUnauthorizedPage');      
    }
    $("#user-image").attr('src', userDetails.pictureLink);
    $("#username").text(userDetails.name);
    $("#user-role").text(userDetails.role);
    console.log('manage course handler executed');
    console.log("PersonID: " + userDetails.personID);
    getDeanByPersonId(userDetails.personID);
   
    getCourseList();


});

function getDeanByPersonId(personId)
{
    $.ajax({                                        //connect to the API using AJAX
        url: API_URL + 'Dean/GetDeanByPersonId',
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json',
        data: { 'personId': personId },
        success: function (data) {
            console.log("Data from getDeanByPersonId: " + JSON.stringify(data));
            $("#username").text(userDetails.name);
            collegeName = data.college.collegeName;
            console.log("College Name: " + collegeName);
            getCollegeDepartments(collegeName);
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


function getCollegeDepartments(colName)
{
    $.ajax({                                        //connect to the API using AJAX
        url: API_URL + 'College/GetList/Departments',
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json',
        data: { 'collegeName': colName },
        success: function (data) {
            var departments = data;
            var departmentsId = [];
            $(departments).each(function (index, item) {
                departmentsId.push(departments[index].department.departmentId);
                console.log("Department IDS: " + departments[index].department.departmentId);
                var departmentIdList = new Array(departments[index].department.departmentId);
                
            });
            console.log("Departments: " + JSON.stringify(data));
            console.log("IDS: " + departmentsId);
            getCourseListByDepartment(departmentsId);
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

function getCourseListByDepartment(departmentId)
{
    console.log("DEPT ID: " +departmentId);
    $.ajax({                                        //connect to the API using AJAX
        url: API_URL + "CourseSchedule/GetList/DepartmentCourses", /*+ '?' + $.param({ 'departmentId': departmentId })*/
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json',
        data: { 'departmentId': departmentId },
        success: function (data) {
            console.log("Course List " + JSON.stringify(data));
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


//this function will get the courses records from the API
function getCourseList() {
    
    $.ajax({                                        //connect to the API using AJAX
        url: API_URL + 'Course/GetList',
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {                  //data (in JSON form) contains the list of college records retrieved from the API
            var courseData = data;
            console.log('data: ', courseData);
            //for each college record, convert to datatable set
            var courseSet = [];
            
            $(courseData).each(function (index, item) {

                console.log("Scheds: " + JSON.stringify(courseData[index].schedules));              
                    var courseRecord = new Array(courseData[index].courseCode,
                        courseData[index].courseDescription, courseData[index].units, courseData[index].noOfHours, courseData[index].courseTypeName,
                        courseData[index].schedule.timeStart, courseData[index].schedule.timeEnd, courseData[index].schedule.day);
                    courseSet.push(courseRecord);          
            });
                 
            //reinitialize datatable with the data set
            $('#tblCourseList').DataTable({
                destroy: true,
                paging: true,
                lengthChange: false,
                searching: true,
                ordering: true,
                info: true,
                autoWidth: false,
                responsive: true,
                columns: [
                    
                    { title: "Course Code", defaultContent: "" },
                    { title: "Course Description", defaultContent: "" },
                    { title: "Units", defaultContent: "" },
                    { title: "No of Hours", defaultContent: "" },
                    { title: "Course Type", defaultContent: "" },
                    { title: "Time Start", defaultContent: "" },
                    { title: "Time End", defaultContent: "" },
                    { title: "Day", defaultContent: "" },
                    //{ title: "", orderable: false }
                ],
                columnDefs: [
                    { className: 'text-center', targets: [0, 7] }  //center align selected columns                   
                ],
                data: courseSet
            });
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

function openCourseModal() {
    $('#courseModal').modal({
        show: true,
        backdrop: 'static',
        keyboard: false
    });
}


