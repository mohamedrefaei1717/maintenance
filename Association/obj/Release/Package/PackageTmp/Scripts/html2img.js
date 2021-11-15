$(document).ready(function () {
    $('#saveImg').click(function () {
        //saveImg
        html2canvas($('body')[0]).then(canvas => {
    //document.body.appendChild(canvas);
    var a = document.createElement('a');
a.href = canvas.toDataURL("image/jpeg").replace("image/jpeg", "image/octet-stream");
a.download = 'Maintenance.jpg';
a.click();




            
});
        //html2canvas($('body')[0], {
        //    onrendered: function (canvas) {
        //        var a = document.createElement('a');
        //        a.href = canvas.toDataURL("image/jpeg").replace("image/jpeg", "image/octet-stream");
        //        a.download = 'somefilename.jpg';
        //        a.click();
        //    }
        //});
});

$('#imgInp').change(function () {

    const file = $(this).context.files[0];
    if (file){
        document.getElementById("blah").src = URL.createObjectURL(file);
        $("#blah").show();
    }
        
});

});








