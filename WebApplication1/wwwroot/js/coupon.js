////$('#submit').click(function () {
////    $.ajax({
////        url: '\Coupon\Index',
////        type: 'GET',
////        data: {
////            Name: 'email@example.com',
////        },
////        success: function (msg) {
////            alert('coupon Sent');
////        }
////    });
////});
$(function () {
    // bind 'myForm' and provide a simple callback function
    $('#c').ajaxForm(function () {
        alert("Thank you for your comment!");
    });
});
