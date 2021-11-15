$( window ).ready(function() {
    alert("ddddddddddddddddddddd");
    $('#load').on("click",function(){
        alert("ddddddddddddddddddddd");
// html2canvas($('#testdiv'), {
//     onrendered: function (canvas) {
//         var img = canvas.toDataURL("image/png")
//         window.open(img);
//     }
// });

});
});

jQuery(function($){
    alert("ddddddddddddddddddddd");
});

$(window).load(function(){
    alert($("#load").html());
    var body = document.getElementsByTagName("body")[0]; 
    $('#load').click(function(){
        // ,{
        //     useCORS:true,
        //     allowTaint: true,
        //     foreignObjectRendering: true
        // }
        html2canvas(body,{foreignObjectRendering: true}).then(canvas => {
            //document.body.appendChild(canvas);
            var a = document.createElement('a');
            a.href = canvas.toDataURL("image/jpeg").replace("image/jpeg", "image/octet-stream");
            a.download = 'somefilename.jpg';
            a.click();

            
        });

});
});




// function saveAs(uri, filename) {
//     var link = document.createElement('a');
//     if (typeof link.download === 'string')
//     {
//         link.href = uri;
//         link.download = filename;
//         document.body.appendChild(link);
//         link.click();
//         document.body.removeChild(link);
//     }
//     else
//     {
//         window.open(uri);
//     }
//     // finish download go back to home
//     window.location.href = "{{URL::to('/')}}";
// }


