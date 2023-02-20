//const { clear } = require("toastr");

var userDetails = JSON.parse(window.localStorage.getItem('userDetails'));


$(document).ready(function () {
    if (userDetails == null || userDetails.role != "Dean") {
        window.location.replace('http://localhost:5001/Unauthorized/ReturnUnauthorizedPage');     
    }
    console.log(userDetails);
    getTeacherList();
    $('#teacherDetails').on('hidden.bs.modal','.modal', function (e) {
        $(this).removeData();
    });
    $("#user-image").attr('src', userDetails.pictureLink);
    $("#username").text(userDetails.name);
    $("#user-role").text(userDetails.role);
});


function getTeacherList() {
    var college = "School of Technology";
    $.ajax({                                        //connect to the API using AJAX
        url: API_URL + 'Teacher/GetList/teacherByCollege',
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json',
        data: { 'collegeName': college },
        success: function (data) {                  //data (in JSON form) contains the list of college records retrieved from the API                     
            var teachers = data;
            console.log('data: ', teachers);
            var teacherList = [];
            

            $(teachers).each(function (index, item) {
                             
                var viewDetailsbtn = '<a class="viewDetails" onclick="viewTeacherInfo(' + teachers[index].teacherId + ')" href="#" title="View Teacher Details"><i class="fa fa-solid fa-info-circle"></i></a>';             
                var teacherRecords = new Array(teachers[index].person.personName, teachers[index].person.gender, teachers[index].person.civilStatus, teachers[index].person.citizenship, moment(teachers[index].person.birthdate).format("l"), moment().diff(moment(teachers[index].person.birthdate).format("l"),"years"), teachers[index].college.collegeName, viewDetailsbtn);

                teacherList.push(teacherRecords);
                console.log(teacherRecords);
            });

            $('#tblTeachers').DataTable({
                destroy: true,
                paging: true,
                lengthChange: false,
                searching: true,
                ordering: true,
                info: true,
                autoWidth: false,
                responsive: true,
                columns: [
                    { title: "Name", defaultContent: "" },
                    { title: "Gender", defaultContent: "" },
                    { title: "Civil Status", defaultContent: "" },
                    { title: "Citizenship", defaultContent: "" },
                    { title: "Birthdate", defaultContent: "" },
                    { title: "Age", defaultContent: "" },
                    { title: "College", defaultContent: "" },                 
                    { title: "", orderable: false }
                ],
                columnDefs: [
                    { className: 'text-center', targets: [0, 6] }  //center align selected columns
                    //{ visible: false, targets: [1, 7, 8, 9, 10, 11, 12, 13] }
                ],
                data: teacherList,
                dom: "Bfrtip",
                buttons: [
                    { extend: 'colvis', text: '<i class="fa-solid fa-eye"></i>', titleAttr: 'Hide or Show column(s)', className: 'btn-success' },
                    { extend: 'excel', text: '<i class="fa-solid fa-file-excel"></i>', titleAttr: 'Download as Excel', className: 'btn-success' },
                    { extend: 'pdf', text: '<i class="fa-solid fa-file-pdf"></i>', titleAttr: 'Download as PDF', className: 'btn-success' },
                    { extend: 'print', title: "", text: '<i class="fa-solid fa-print"></i>', titleAttr: 'Print Record', className: 'btn-success' },
                ]
            });
            $("#tblTeachers_wrapper > .dt-buttons").appendTo("div.buttons-location").addClass("float-right");
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

function viewTeacherInfo(teacherId) {
    console.log(teacherId);
  
    $.ajax({                                        //connect to the API using AJAX
        url: API_URL + 'Teacher/GetDetails',
        type: 'GET',
        dataType: 'json',       
        data: { 'teacherId': teacherId},
        success: function (data) {                  //data (in JSON form) contains the list of college records retrieved from the API                     
            var teachers = data;
            console.log('data: ', teachers);
            var teacherList = [];
            console.log("Name:" + teachers.person.personName);

            $("#fullName").text(teachers.person.personName);
            $("#employeeNumber").text(teachers.person.employee.employeeNo);
            $("#classification").text(teachers.person.employee.employeeClassificationDescription);
            $("#designation").text(teachers.person.employee.designation);
            $("#designationStatus").text(teachers.person.employee.designationStatus);
            $("#gender").text(teachers.person.gender);
            $("#civilStatus").text(teachers.person.civilStatus);
            $("#nationality").text(teachers.person.nationality);
            $("#birthdate").text(moment(teachers.person.birthdate).format("l"));
            $("#age").text(teachers.person.age);
            $("#telephoneNumber").text(teachers.person.telephoneNo);
            $("#mobileNumber").text(teachers.person.mobileNo);
            $("#email").text(teachers.person.emailAddress);
            $("#houseno").text(teachers.person.address.houseBlkLotNo);
            $("#streetname").text(teachers.person.address.street);
            $("#barangay").text(teachers.person.address.barangay);
            $("#municipality").text(teachers.person.address.cityMunicipality);
            $("#province").text(teachers.person.address.province);
            $("#teacher-image").attr("src", teachers.person.pictureLink);

            getAllTeacherSubjects(teacherId);
        },
        error: function (error) {
            console.log('Error: ', error);
            Toast.fire({
                icon: 'error',
                title: 'Could not connect to the server!'
            });
        }
    });

    $('#teacherDetails').modal({         //show  modal
        show: true,
        backdrop: 'static',
        keyboard: false
    });
    console.log("Modal student details. is open.")
}

function getAllTeacherSubjects(teacherId) {
    //Get all teachers subject
    $.ajax({                                        //connect to the API using AJAX
        url: API_URL + 'TeacherCourseSchedule/GetList/teacherSchedules',
        type: 'GET',
        dataType: 'json',
        //contentType: 'application/json',
        data: { 'teacherId': teacherId },
        success: function (data) {
            if (data != null) {
                var courseData = data;
                console.log('data: ', courseData);
                //for each college record, convert to datatable set
                var courseSchedIds = [];
                var courseSet = [];
                $(courseData).each(function (index, item) {
                    var removeSubjectbtn = '<a class="removeSubject" onclick="AddOrRemoveTeacherSubject(\'Remove\',\'' + teacherId + '\',\'' + courseData[index].courseSchedules.courseScheduleId + '\')" title="Remove subject from teacher."><i class="fa-solid fa-xmark"></i></a>';
                    var courseRecord = new Array(courseData[index].courseSchedules.edpCode, courseData[index].courseSchedules.course.courseCode,
                        courseData[index].courseSchedules.course.courseDescription, courseData[index].courseSchedules.course.units, courseData[index].courseSchedules.course.noOfHours,
                        courseData[index].courseSchedules.course.courseTypeName, courseData[index].courseSchedules.timeStart, courseData[index].courseSchedules.timeEnd, courseData[index].courseSchedules.day, removeSubjectbtn);
                    courseSet.push(courseRecord);
                    courseSchedIds.push(courseData[index].courseSchedules.courseScheduleId);

                });
                console.log(courseSchedIds);
                $('#tblTeacherCourses').DataTable({
                    destroy: true,
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
                        { title: "Day" },
                        { title: "", orderable: false }
                    ],
                    columnDefs: [
                        { className: 'text-center', targets: [0, 8] }    //center align selected columns
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
                $("#tblTeacherCourses_wrapper > .dt-buttons").appendTo("div.buttons-location-2").addClass("float-right");
                $(".btn-group > button").removeClass("btn-secondary");

                $("#openUnassignedSubjectModal").click(function () {
                    openModalCourseNotInList(teacherId, courseSchedIds);
                    $('#modalCourseNotInList').modal({         //show  modal
                        show: true,
                        backdrop: 'static',
                        keyboard: false
                    });
                });
            }
            else {            
                $("#courseList").text("This teacher doesn't have a subject.");
            }

        }

    });

}


function openModalCourseNotInList(teacherId, courseSchedIds) {

    //var teacherId = 2;
    console.log("Teacher ID: " + teacherId);
    console.log("Array: " + courseSchedIds);
    $.ajax({                                        //connect to the API using AJAX
        url: API_URL + 'TeacherCourseSchedule/CourseNotInTeacherList',
        type: 'GET',
        dataType: 'json',
        traditional: true,
        //contentType: 'application/json',
        data: { 'courseSchedId': courseSchedIds },
        success: function (data) {
            if (data != null) {
                var courseData = data;
                console.log('data: ', courseData);
                //for each college record, convert to datatable set
                var courseSet = [];
                $(courseData).each(function (index, item) {
                    console.log(courseData[index].courseSchedules.edpCode)
                    var addSubjectbtn = '<a class="addTeacherSubject" onclick="AddOrRemoveTeacherSubject(\'Add\',\'' + teacherId + '\',\'' + courseData[index].courseSchedules.courseScheduleId + '\')" href="#" title="Assign subjet to teacher."><i class="fa-solid fa-plus"></i></a>';
                    var courseRecord = new Array(courseData[index].courseSchedules.edpCode, courseData[index].courseSchedules.course.courseCode,
                        courseData[index].courseSchedules.course.courseDescription, courseData[index].courseSchedules.course.units, courseData[index].courseSchedules.course.noOfHours,
                        courseData[index].courseSchedules.course.courseTypeName, courseData[index].courseSchedules.timeStart, courseData[index].courseSchedules.timeEnd, courseData[index].courseSchedules.day, addSubjectbtn);
                    courseSet.push(courseRecord);
                });

                $('#tblCourseNotInList').DataTable({
                    destroy: true,
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
                        { title: "Day" },
                        { title: "", orderable: false }
                    ],
                    columnDefs: [
                        { className: 'text-center', targets: [0, 8] }    //center align selected columns
                        //{ visible: false, targets: [0] }                    //hide first column
                    ],
                    data: courseSet
                });
            }                
          //$('#tblUnenrolledStudent').DataTable().columns.adjust().draw();
        },
        error: function (error) {
            console.log('Error: ', error);
            Toast.fire({
                icon: 'error',
                title: 'Could not connect to the server!'
            });
        }
    });

   
    //$('#modalTitle').text('Students not in the subject')
    console.log("Modal is open.");
}


//Add or Remove a Teacher subject.
function AddOrRemoveTeacherSubject(operation, teacherId, courseSchedId) {
    console.log("Im In!");
    console.log(teacherId, courseSchedId);
    if (operation == 'Add') {
        $.ajax({                                        //connect to the API using AJAX
            url: API_URL + 'CourseSchedule/AddTeacherCourseSchedule' + '?' + $.param({ 'teacherId': teacherId, 'courseScheduleId': courseSchedId }),
            type: 'POST',
            //dataType: 'json',
            contentType: 'application/json',
            //data: { 'studentId': studId, 'courseScheduleId': courseSchedId },
            success: function (data) {                  //data (in JSON form) contains the list of college records retrieved from the API                     
                Swal.fire(
                    'The subject added to the teacher!',
                    'The subject has been successfully added',
                    'success'
                )
                openModalCourseNotInList(teacherId, courseSchedId);
                getAllTeacherSubjects(teacherId);
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
    else if (operation == 'Remove') {
        Swal.fire({                                                 //Sweat Alert Confirmation Modal
            title: 'Are you sure you want to remove this subject?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Remove Subject'
        }).then((result) => {
            if (result.isConfirmed) {
                console.log("Teacher ID: " + teacherId);
                console.log("Course Sched ID: " + courseSchedId);

                $.ajax({                                        //connect to the API using AJAX
                    url: API_URL + 'CourseSchedule/RemoveTeacherCourseSchedule' + '?' + $.param({ 'teacherId': teacherId, 'courseScheduleId': courseSchedId }),
                    type: 'PUT',
                    dataType: 'json',
                    //contentType: 'application/json',
                    traditional: true,
                    //data: {'studentId':studId, 'courseScheduleId':courseSchedId},
                    success: function (data) {                  //data (in JSON form) contains the list of college records retrieved from the API                     
                        console.log(data);
                        Swal.fire(
                            'The subject has been removed',
                            'The subject has been successfully removed!',
                            'success'
                        )
                        getAllTeacherSubjects(teacherId);

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
