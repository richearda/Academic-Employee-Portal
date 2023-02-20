var userDetails = JSON.parse(window.localStorage.getItem('userDetails'));
var eventFormValidator;
$(document).ready(function () {
    if (userDetails == null || userDetails.role != "SchoolAdmin") {
        window.location.replace('http://localhost:5001/Unauthorized/ReturnUnauthorizedPage');      
    }

    $("#user-image").attr('src', userDetails.pictureLink);
    $("#username").text(userDetails.name);
    $("#user-role").text(userDetails.role);

    $.validator.setDefaults({
        submitHandler: function () {
            submitEventData();
        }
    });

    //Validate the event form
    eventFormValidator = $('#eventForm').validate({
        rules: {
            eventTitle: {
                required: true
            },
            eventDescription: {
                required: true
            },
            eventStart: {
                required: true
            },
            eventEnd: {
                required: true
            },
            themeColor: {
                required: true
            }
        },
        messages: {
            eventTitle: {
                required: "Please provide a title"
            },
            eventDescription: {
                required: "Please provide a description"
            },
            eventStart: {
                required: "Please select start date and time"
            },
            eventEnd: {
                required: "Please select end date and time"
            },
            themeColor: {
                required: "Please choose event color"
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

   // ShowEventDetails();
    //Executes when openAddForm button is clicked   
    $("#openAddForm").click(function () {
        //clear form
        clearForm();

        //change the modal title and Delete text to Clear
        $("#eventModal .modal-title").text("Add Event");
        $("#btnDeleteClear").text("Clear");
        //remove class btn-danger for delete button and change it to btn-secondary to change the button color
        $("#btnDeleteClear").removeClass('btn-danger');
        $("#btnDeleteClear").addClass('btn-secondary');

        //Display the modal for adding event.
        $("#eventModal").modal({
            show: true,
            backdrop: 'static',
            keyboard: false
        });
    });
    //renders the calendar
    RenderCalendar();
    $("#eventModal").on("hidden.bs.modal", function (e) {
        $(this).removeData();
    });
    $("#datetimepickerstart").flatpickr({
        enableTime: true,
        dateFormat: "Y-m-d"
    });
    $("#datetimepickerend").flatpickr({
        enableTime: true,
        dateFormat: "Y-m-d H:i:S"
    });

    $("openAddForm").on('click', function () {

    })
    
});


function submitEventData() {
    console.log('login credentials submitted');

    var eventData = {
        eventTitle: $('#loginUsername').val().trim(),
        eventDescription: $('#loginPassword').val().trim(),
        eventStart: $("#datetimepickerstart").val().trim(),
        eventEnd: $("#datetimepickerend").val().trim(),
        themeColor: $("#ddThemeColor option:selected").text(),
    };

}


//get the list of events in the database.
function RenderCalendar() {
    events = [];
    $.ajax({
        url: API_URL + "Event/GetList",
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            console.log("List of Admin Events: ", data);
            $(data).each(function (index, value) {
                events.push({
                    eventID: value.eventId,
                    title: value.title,
                    description: value.description,
                    start: value.start, 
                    end: value.end, 
                    color: value.themeColor
                });
            })
            console.log("List of Admin Events: ", events);
            GenerateCalenderEvents(events);
        },
        error: function (error) {
            console.log('Error: ', error);
            Toast.fire({
                icon: 'error',
                title: 'Could not connect to the server!'
            });
        }
    })
}

//display the events to calendar from the RenderEvent function
function GenerateCalenderEvents(events) {
    console.log("Events passed: " + events);
    $('#calendarAdmin').fullCalendar('destroy');
    $('#calendarAdmin').fullCalendar({
        contentHeight: 400,
        defaultDate: new Date(),
        timeFormat: 'h(:mm)a',
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,basicWeek,basicDay,agenda'
        },
        eventLimit: true,
        eventColor: '#378006',
        eventRender: function (events, $el) {
            $el.popover({
                title: events.title,
                content: "Date: " + moment.utc(events.start).format('l') + " - " + moment.utc(events.end).format('l') + "\nTime: " + moment.utc(events.start).format('LT') + " - " + moment.utc(events.end).format('LT') + "\n" + events.description,
                trigger: 'hover',
                placement: 'top',
                container: 'body'
            });
        },
        eventDisplay: 'auto',
        events: events,
        eventClick: function (calEvent) {
            console.log("Event ID to update: " + calEvent.eventID);
            $("#btnOperation").removeAttr('onclick');
            $("#btnDeleteClear").removeAttr('onclick');
            $("#btnDeleteClear").removeClass('btn-secondary');
            $(".modal-title").text("Update/Delete Event");
            $("#txtTitle").val(calEvent.title);
            $("#txtDescription").val(calEvent.description);
            $("#datetimepickerstart").val(calEvent.start);
            $("#datetimepickerend").val(calEvent.end);
            $("#ddThemeColor option").each(function () { this.selected = (this.text == calEvent.color); });
            console.log(calEvent.eventID);
            console.log(calEvent);
            $("#chkIsHoliday").val(calEvent.isHoliday);                               
            $("#btnOperation").text("Update Event");
            $("#btnDeleteClear").text("Delete Event");
            $("#btnDeleteClear").addClass('btn-danger');
            
            $("#eventModal").modal({
                show: true,
                backdrop: 'static',
                keyboard: false
            });
            
            $("#btnOperation").click(function () {
                updateEvent(calEvent.eventID);
            })
            $("#btnDeleteClear").attr('onClick', deleteEvent(calEvent.eventID));
                       
        }
    })
}


//Add event function
function addEvent() {
    //if ($("#eventForm").isValid()) {
        //clearForm();

        var formData = {
            title: $("#txtTitle").val().trim(),
            description: $("#txtDescription").val().trim(),
            start: $("#datetimepickerstart").val().trim(),
            end: $("#datetimepickerend").val().trim(),
            themeColor: $("#ddThemeColor option:selected").text(),
            isHoliday: $("#chkIsHoliday").is(":checked")
        }
        $.ajax({                            //connect to the API using AJAX    
            type: 'POST',
            dataType: 'json',
            contentType: 'application/json',
            url: API_URL + 'Event/Add',
            data: JSON.stringify(formData),
            success: function (data) {  //data (in JSON form) contains the list of records retrieved from the API                     
                console.log("Event Added.");
                Swal.fire(
                    'Operation Success!',
                    'The event is successfully added!',
                    'success'
                )
                $("#calendarAdmin").fullCalendar('refetchEvents');

                clearForm();
                $("#eventModal").modal({
                    show: false
                });
                RenderCalendar();
            }
        });
    //}
}
//Update event function
function updateEvent(eventID) {

    console.log("this is the event id: " + JSON.stringify(eventID));
    $("#btnOperation").on('click', function () {
        console.log("Event ID to be updated: " + eventID);
        var updatedEventData = {
            eventId: eventID,
            title: $("#txtTitle").val().trim(),
            description: $("#txtDescription").val().trim(),
            start: moment($("#datetimepickerstart").val().trim()).format('LLL'),
            end: moment($("#datetimepickerend").val().trim()).format('LLL'),
            themeColor: $("#ddThemeColor option:selected").text(),
            isHoliday: $("#chkIsHoliday").is(":checked")
        }

        console.log("Event to update: " + JSON.stringify(updatedEventData));
        $.ajax({                                        //connect to the API using AJAX    
            type: 'PUT',
            dataType: 'json',
            contentType: 'application/json',
            url: API_URL + 'Event/Edit',
            data: JSON.stringify(updatedEventData),
            success: function (data) {  //data (in JSON form) contains the list of records retrieved from the API                     
                console.log("Event Updated.");
                Swal.fire(
                    'Event Updated!',
                    'The event has been successfully updated!',
                    'success'
                )
                $("#calendarAdmin").fullCalendar('refetchEvents');
                $("#btnOperation").attr('onclick', addEvent());
                $("#eventModal").modal({
                    show: false                    
                });
                RenderCalendar();
            }
        });
    });
}
//deletes and event
    function deleteEvent(eventID)
    {
        $("btnDeleteClear").on('click', function () {
            Swal.fire({                                                 //Sweat Alert Confirmation Modal
                title: 'Are you sure you want to delete the event?',
                text: "You won't be able to revert this!",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Delete Event'
            }).then((result) => {
                if (result.isConfirmed) {

                    $.ajax({                                        //connect to the API using AJAX    
                        type: 'DELETE',
                        dataType: 'json',
                        contentType: 'application/json',
                        url: API_URL + 'Event/Delete',
                        data: eventID,
                        success: function (data) {  //data (in JSON form) contains the list of college records retrieved from the API                     
                            console.log("Event Updated.");
                            Swal.fire(
                                'Event Updated!',
                                'The event has been successfully updated!',
                                'success'
                            )
                            $("#calendarAdmin").fullCalendar('refetchEvents');
                            $("#btnOperation").attr('onclick', addEvent());
                            $("btnDeleteClear").attr('onclick', clearForm());
                            $("#eventModal").modal({
                                show: false
                            });
                        }
                    });
                }
            })
        });
        
    }



//clear the form
    function clearForm()
    {      
            $("#txtTitle").val(""),
            $("#txtDescription").val(""),
            $("#datetimepickerstart").flatpickr({
                enableTime: true,
                dateFormat: "Y-m-d H:i:S"
            });
            $("#datetimepickerend").flatpickr({
                enableTime: true,
                dateFormat: "Y-m-d H:i:S"
            });
            $("#chkIsHoliday").prop('checked', false);
            $("#ddThemeColor").val($("#ddThemeColor option:first").val());                 
    }

