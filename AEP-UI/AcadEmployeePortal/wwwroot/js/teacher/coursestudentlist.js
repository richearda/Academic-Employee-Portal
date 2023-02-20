var userDetails = JSON.parse(window.localStorage.getItem('userDetails'))
var studentMasterlistTable;
var unenrolledStudentListTable;
var selectedCourse;

var teacherId;

var coursesList = $(".course-select");
$(document).ready(function () {
    //Return to login page if user details is empty.
    if (userDetails == null || userDetails.role != "Teacher") {
        window.location.replace('http://localhost:5001/Unauthorized/ReturnUnauthorizedPage');     
    }
    $("#user-image").attr('src', userDetails.pictureLink);
    $("#username").text(userDetails.name);
    $("#user-role").text(userDetails.role);
    console.log('document is ready...');
    console.log("Person ID: " + userDetails.personID);
    console.log("Details: " + userDetails.name);
    getTeacherByPersonId(userDetails.personID);
    
    displayCourseMasterList();
     
});

function printRecord() {
    $(".print-record").on('click', function () {
        $("#mclogo").attr("src", "~/img/avatar.png");
        $("#mcclogo").attr("src", "~/img/avatar5.png");
        $("table #tblCourseStudentList")
         .prepend($("printheading").print());      
    });
    
}

function getTeacherByPersonId(personId)
{
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
            populateTeacherCourseDropdown();
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



function openUnenrolledTable(studentIds) {
    $("#openUnenrolledStudentModal").click(function () {
        console.log("Course Sched ID: " + $(".course-select").val());
        openUnenrolledStudentTable(studentIds);
    });
    console.log("Student IDs from openUnenrolledTable method: " + studentIds);
}

function populateTeacherCourseDropdown() {
    console.log("Populate Course: " + teacherId);
    $.ajax({                                        //connect to the API using AJAX
        url: API_URL + 'TeacherCourseSchedule/GetList/teacherSchedules',
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json',
        data: { 'teacherId': teacherId },
        success: function (data) {
            //data (in JSON form) contains the list of college records retrieved from the API
            $(data).each(function (index, item) {
                var courseData = data;
                console.log('data: ', courseData);
                $(".course-select").append($('<option/>', { value: courseData[index].courseScheduleId, text: courseData[index].courseSchedules.course.courseDescription + ' ' + courseData[index].courseSchedules.day + ' ' + courseData[index].courseSchedules.timeStart + " " + courseData[index].courseSchedules.midDayTimeStart + ' - ' + courseData[index].courseSchedules.timeEnd + " " + courseData[index].courseSchedules.midDayTimeEnd}));
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


function reloadMasterList() {
    if (!$(".course-select").children('option:first-child').is(':selected')) {
        var currentSelected = $(".course-select").val();
        $.ajax({                                        //connect to the API using AJAX
            url: API_URL + 'CourseSchedule/GetList/scheduleMasterList',
            type: 'GET',
            dataType: 'json',
            contentType: 'application/json',
            data: { 'teacherId': teacherId, 'courseScheduleId': currentSelected },
            success: function (data) {                  //data (in JSON form) contains the list of college records retrieved from the API                     
                var students = data;
                console.log('data: ', students);
                var studentList = [];
                
                //viewStudentInfo(students);
                $(students).each(function (index, item) {

                    console.log("Student IDs: " + students[index].student.studentID);
                    //var editAction = '<a href="#" onclick="openCollegeModal(' + collegeData[index].collegeID + ',\'' + collegeData[index].collegeName + '\',\'' + collegeData[index].collegeCode + '\')" data-toggle="tooltip" data-placement="top" title="Edit"><i class="fa fa-edit fa-icon-link"></i></a>';                                             
                    studentIds.push(students[index].student.studentID)
                    var viewDetailsbtn = '<a class="viewDetailsMasterlist" onclick="viewStudentInfo(' + students[index].student.studentID + ')" href="#" title="View Student Details"><i class="fa fa-solid fa-info-circle mr-1"></i></a>';

                    var removeStudentbtn = '<a class="removeStudent" onclick="AddOrRemoveStudent(\'Remove\',\'' + students[index].student.studentID + '\',\'' + selectedCourse + '\')" href="#" title="Remove Student"><i class="fa-solid fa-user-xmark text-danger"></i></a>';

                    var studentRecord = new Array(students[index].student.studentNo, students[index].student.lrnNo, students[index].student.person.personName, students[index].student.person.gender, students[index].student.yearLevel, students[index].student.program.programCode, students[index].student.majorName, viewDetailsbtn + removeStudentbtn);
                    studentList.push(studentRecord);
                });


                studentMasterlistTable = $('#tblCourseStudentList').DataTable({

                    destroy: true,
                    paging: true,
                    lengthChange: false,
                    searching: true,
                    ordering: true,
                    info: true,
                    autoWidth: false,
                    responsive: true,
                    columns: [
                        { title: "Student No", defaultContent: "" },
                        { title: "LRN No", defaultContent: "" },
                        { title: "Name", defaultContent: "" },
                        { title: "Gender", defaultContent: "" },
                        { title: "Year Level", defaultContent: "" },
                        { title: "Program", defaultContent: "" },
                        { title: "Major", defaultContent: "" },
                        { title: "Action", orderable: false }
                       
                    ],
                    columnDefs: [
                        { className: 'text-center', targets: [0, 5] }  //center align selected columns
                        //{ visible: false, targets: [1, 7, 8, 9, 10, 11, 12, 13] }
                    ],
                    data: studentList,
                    dom: "Bfrtip",
                    buttons: [
                        { extend: 'colvis', text: '<i class="fa-solid fa-eye"></i>', titleAttr: 'Hide or Show column(s)', className: 'btn-success' },
                        { extend: 'excel', text: '<i class="fa-solid fa-file-excel"></i>', titleAttr: 'Download as Excel', className: 'btn-success' },
                        { extend: 'pdf', text: '<i class="fa-solid fa-file-pdf"></i>', titleAttr: 'Download as PDF', className: 'btn-success' },
                        {
                            extend: 'print', title: "", text: '<i class="fa-solid fa-print"></i>', titleAttr: 'Print Record', className: 'btn-success',

                            customize: function (win) {
                                $(win.document.body).prepend($("#printheading"));
                            }
                        },
                    ]


                });
                $("#tblCourseStudentList_wrapper > .dt-buttons").appendTo("div.buttons-location").addClass("float-right");
                $(".btn-group > button").removeClass("btn-secondary");
                openUnenrolledTable(studentIds);
               
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
}

var studentIds = [];
//this function will get the college records from the API
function displayCourseMasterList() {  
  
    $(".course-select").change(function () {
        studentIds = [];
        selectedCourse = $(this).val();
        console.log("this is the value: " + selectedCourse);
        console.log($(this).val());
        console.log("Teacher Id: " + teacherId);
        reloadMasterList();             
    });
}

function openStudentProfileModal() {
    console.log("Opening modal.");
    $('#studentProfileModal').modal({
        show: true,
        backdrop: 'static',
        keyboard: false
    });
    console.log("modal is open");
}

function displayUnenrolledStudents()
{
    var selectedCourseId = $(".course-select").val();
    if (!$(".course-select").children('option:first-child').is(':selected')) {
        $.ajax({                                 //connect to the API using AJAX           
            url: API_URL + 'CourseSchedule/GetList/studentsnotinlist',
            type: 'GET',
            dataType: 'json',
            traditional: true,
            //contentType: 'application/json',
            data: { 'studentId': studentIds },
            success: function (data) {                  //data (in JSON form) contains the list of college records retrieved from the API                     
                console.log(data);
                var students = data;
                var studentList = [];
                console.log(students);

                $(students).each(function (index, item) {                  
                    var viewDetailsbtn = '<a class="viewDetails" onclick="viewStudentInfo(' + students[index].studentID + ')" href="#" title="View Student Details"><i class="fa fa-solid fa-info-circle mr-1"></i></a>';
                    var addStudentbtn = '<a class="addStudent" onclick="AddOrRemoveStudent(\'Add\',\'' + students[index].studentID + '\',\'' + selectedCourseId + '\')" href="#" title="Add Student"><i class="fa-solid fa-user-plus text-success"></i></i></a>';
                    //var addStudentbtn = '<a class="removeStudent" onclick="addStudent(' + students[index].student.studentId + ',\'' + selectedCourseId + '\',\'' + teacherId + '\')" href="#" title="Remove Student"><i class="fa - solid fa - plus"></i></a>';
                    var studentRecord = new Array(students[index].studentNo, students[index].lrnNo, students[index].person.personName, students[index].person.gender, students[index].programCode, students[index].majorName,
                        students[index].yearLevel, moment(students[index].person.birthdate).format('L'), moment().diff(moment(students[index].person.birthdate).format('L'),"years"), students[index].person.civilStatus, students[index].person.citizenship,
                        students[index].person.mobileNo, students[index].person.telephoneNo, students[index].person.email, viewDetailsbtn + addStudentbtn);
                    studentList.push(studentRecord);
                });
                unenrolledStudentListTable = $('#tblUnenrolledStudent').DataTable({
                    destroy: true,
                    paging: true,
                    lengthChange: false,
                    searching: true,
                    ordering: true,
                    info: true,
                    autoWidth: false,
                    responsive: true,
                    columns: [
                        { title: "Student No", defaultContent: "" },
                        { title: "LRN No", defaultContent: "" },
                        { title: "Name", defaultContent: "" },
                        { title: "Gender", defaultContent: "" },
                        { title: "Program", defaultContent: "" },
                        { title: "Major", defaultContent: "" },
                        { title: "Year Level", defaultContent: "" },
                        { title: "Birthdate", defaultContent: "" },
                        { title: "Age", defaultContent: "" },
                        { title: "Civil Status", defaultContent: "" },
                        { title: "Citizenship", defaultContent: "" },
                        { title: "Mobile No", defaultContent: "" },
                        { title: "Telephone No", defaultContent: "" },
                        { title: "Email", defaultContent: "" },
                        { title: "", orderable: false, },

                    ],
                    columnDefs: [
                        { className: 'text-center', targets: [0, 6] },  //center align selected columns
                        { visible: false, targets: [1, 7, 8, 9, 10, 11, 12, 13] }
                    ],
                    data: studentList

                });
                console.log("Im inside displayUnenrolledStudents method success.");
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
}

function openUnenrolledStudentTable(studentIds) {
    console.log("openUnenrolledStudentTable method executed");
    console.log("Unenrolled student IDs: " + studentIds);
    //var teacherId = 2;
    
        console.log("Array: " + studentIds);
    displayUnenrolledStudents();

    if (!$('#unenrolledStudentModal').is(':visible')) {
        $('#unenrolledStudentModal').modal({         //show  modal
            show: true,
            backdrop: 'static',
            keyboard: false
        });
    }
       
        $('#modalTitle').text('Students not in the subject')
        console.log("Modal is open.");
}


//View student info
function viewStudentInfo(studentId) {

    $.ajax({                                        //connect to the API using AJAX
        url: API_URL + 'Student/GetStudentInfo',
        type: 'GET',
        dataType: 'json',
        //contentType: 'application/json',
        data: { 'studentId': studentId },
        success: function (data) {                  //data (in JSON form) contains the list of college records retrieved from the API                     
            var student = data;
            console.log('data: ', student);
            console.log("Picture Link: " + student.person.pictureLink);
            console.log("Name:" + student.person.personName);
            

            $("#fullName").text(student.person.personName);
            $("#studentNumber").text(student.studentNo);
            $("#program").text(student.program.programCode);
            $("#major").text(student.majorName);
            $("#yearLevel").text(student.yearLevel);
            $("#gender").text(student.person.gender);
            $("#civilStatus").text(student.person.civilStatus);
            $("#nationality").text(student.person.nationality);
            $("#birthdate").text(moment(student.person.birthdate).format("l"));
            $("#age").text(moment().diff(moment(student.person.birthdate).format("l"),"years"));
            $("#telephoneNumber").text(student.person.telephoneNo);
            $("#mobileNumber").text(student.person.mobileNo);
            $("#email").text(student.person.emailAddress);
            $("#houseno").text(student.person.address.houseBlkLotNo);
            $("#streetname").text(student.person.address.street);
            $("#barangay").text(student.person.address.barangay);
            $("#municipality").text(student.person.address.cityMunicipality);
            $("#province").text(student.person.address.province);
            $("#teacher-student-image").attr("src", student.person.pictureLink);
        }
    });

    $('#studentDetails').modal({         //show  modal
        show: true,
        backdrop: 'static',
        keyboard: false
    });
    console.log("Modal student details. is open.")
}



//AddRemove student
//Extra id is shown in api
function AddOrRemoveStudent(operation, studId, courseSchedId) {
    console.log("Im In!");
    console.log(studId, courseSchedId);
    if (operation == 'Add')
    {
        $.ajax({                                        //connect to the API using AJAX
            url: API_URL + 'StudentCourseSchedule/Add/studentschedule' + '?' + $.param({ 'studentId': studId, 'courseScheduleId': courseSchedId }),
            type: 'POST',
            //dataType: 'json',
            contentType: 'application/json',
            //data: { 'studentId': studId, 'courseScheduleId': courseSchedId },
            success: function (data) {                  //data (in JSON form) contains the list of college records retrieved from the API                     
                reloadMasterList();
                console.log('Masterlist student table refreshed!');
                displayUnenrolledStudents();
                console.log('Unenrolled student table refreshed!');
                Swal.fire(
                    'Student Added!',
                    'The student has been successfully added',
                    'success'
                )                                                           
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
    else if(operation == 'Remove') {
        Swal.fire({                                                 //Sweat Alert Confirmation Modal
            title: 'Do you really want to remove the student?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Remove Student'
        }).then((result) => {
            if (result.isConfirmed) {
                console.log("Student ID:" + studId);
                console.log("Course Sched ID: " + courseSchedId);
                
                $.ajax({                                        //connect to the API using AJAX
                    url: API_URL + 'CourseSchedule/RemoveStudent' + '?' + $.param({ 'studentId': studId, 'courseScheduleId': courseSchedId }),
                    type: 'DELETE',
                    dataType: 'json',
                    //contentType: 'application/json',
                    traditional:true,
                    //data: {'studentId':studId, 'courseScheduleId':courseSchedId},
                    success: function (data) {                  //data (in JSON form) contains the list of college records retrieved from the API                     
                        console.log(data);
                        Swal.fire(
                            'Removed!',
                            'The student has been removed successfully.',
                            'success'
                        )                       
                        reloadMasterList();                     
                        console.log("success");

                    },
                    error: function (error) {
                        console.log('Error: ', error);
                        Toast.fire({
                            icon: 'error',
                            title: 'Could not connect to the server!'
                        });
                        console.log("Error");
                    }
                });
                
               
            }
        })
    }              
}
