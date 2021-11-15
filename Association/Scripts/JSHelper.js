$(document).ready(function () {
    /*Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
    }); */

    $('.chosen').chosen({
        //width: "100%",
        search_contains: true
           , search_contains: true,
        no_results_text: "لا توجد نتائج"
    });
    $('.datepicker').attr("readonly", "true");
    $('body').on('click', '.datepicker', function () {
        //var dayOfWeek = weekday[Date.getUTCDay()];
        $(this).datetimepicker({pickTime: false}).focus();
    });




       
    $('.date').datetimepicker({ pickTime: false });


    $('.datetime').datetimepicker({ format: "dddd DD-MM-YYYY hh:mm:ss A" });
});


function pageLoad() { 
    $('.date').datetimepicker({ pickTime: false });
} 


function ShowMess(msg, type) {

    if (type == "Success") {
        $('.Success').show().fadeIn(1000).fadeOut(3000).html(msg);
    }
    else {
        $('.Failed').show().fadeIn(1000).fadeOut(3000).html(msg);
    }
}