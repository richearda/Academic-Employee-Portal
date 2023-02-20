// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//declare global variables and common functions
var API_URL = "http://localhost:12108/api/";      //API URL
var Toast = Swal.mixin({                         //SweetAlert
    toast: true,
    position: 'top-end',
    showConfirmButton: false,
    timer: 3000
});


$(document).ready(function () {
   
    FetchEventAndRenderCalendar();
    $('.card-event').hide();

});


//Get all events and display it in the calendar
function FetchEventAndRenderCalendar() {
   
    events = [];
    $.ajax({
        url: API_URL + "Event/GetList",
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            console.log("List of events: ", data);
            $(data).each(function (index, value) {
                events.push({
                    eventID: value.eventID,
                    title: value.title,
                    description: value.description,
                    start: value.start, //!= null ? moment(value.start).format('LLL') : null,
                    end: value.end, //!= null ? moment(value.end).format('LLL') : null,
                    color: value.themeColor
                   
                });
            })
            console.log(events);
            GenerateCalender(events);
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
function GenerateCalender(events) {
    $('#calendar').fullCalendar('destroy');
    $('#calendar').fullCalendar({
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
                content: "Date: " + moment.utc(events.start).format('l') + " - " + moment.utc(events.end).format('l') + "\nTime: " + moment.utc(events.start).format('LT') + " - " + moment.utc(events.end).format('LT')  + "\n"+events.description,
                trigger: 'hover',
                placement: 'top',
                container: 'body'
            });
        },
        eventDisplay: 'auto',
        events: events      
        //eventClick: function (calEvent) {
        //    selectedEvent = calEvent;
            
        //    var isHidden = $(".card-event").is(":hidden");
           
        //        if (isHidden) {
        //            $('.event-title').text(selectedEvent.title);
        //            $('.event-description').text(selectedEvent.description);
        //            $('.event-start').text(moment(selectedEvent.start));
        //            $('.event-end').text(moment(selectedEvent.end));
        //            $('.card-event').slideToggle(500, 'linear');
        //        }
        //        else {
        //            $('.event-title').text(selectedEvent.title);
        //            $('.event-description').text(selectedEvent.description);
        //            $('.event-start').text(moment(selectedEvent.start));
        //            $('.event-end').text(moment(selectedEvent.end));
        //        }
                                
        //    console.log('appended');
        //}
    })
}

function logout() {
    Swal.fire({                                                 //Sweat Alert Confirmation Modal
        title: 'Are you sure you want to logout?',
        text: "Please confirm to continue!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Logout'
    }).then((result) => {
        if (result.isConfirmed) {
            window.localStorage.removeItem("userDetails");
            window.location.replace("http://localhost:49441");

        }
    })
    
}

