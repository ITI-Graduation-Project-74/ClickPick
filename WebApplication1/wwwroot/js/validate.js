jQuery.validator.addMethod("matches", function (phone_number, element) {
    phone_number = phone_number.replace(/\s+/g, "");
    return this.optional(element) || phone_number.length > 9 &&
        phone_number.match(/^0\d{10}$/);
}, "Please specify a valid phone number");
$(function () {
    var $headerForm = $("#Orderheader");
    if ($headerForm.length) {
        $headerForm.validate({

            rules: {
                Phone: {
                    required: true,
                    matches: true, // <-- no such method called "matches"!
                    minlength: 11,
                    maxlength: 11
                },
                Address: {
                    required: true
                }
            },
            messages: {
                Phone: {
                    required: "Required",
                    matches: "ex:01xxxxxxxxx",  // <-- no such method called "matches"!
                    minlength: "not valid",
                    maxlength: "not valid"
                },
                Address: {
                    required: "Required"
                }
            }

        })
    }
});
//$('#billingAddressCheck').click(function () {
//    $('#billingAddress')[this.checked ? "show" : "hide"]();
//});
$("#billingAddressDiv").hide();
$('input[name=billingAddressCheck]').on('change', function () {
    if ($(this).is(":checked")) {
        $('#billingAddress').val('');
        $('#billingAddressDiv').show();
    } else {
        $('#billingAddress').val('');
        $('#billingAddressDiv').hide();
    }
});

////Regestriation
//$(function () {
//    var $registerForm = $("#registerForm");
//    if ($registerForm.length) {
//        $registerForm.validate({

//            rules: {
//                Phone: {
//                    required: true,
//                    matches: true, // <-- no such method called "matches"!
//                    minlength: 11,
//                    maxlength: 11
//                },
//                FirstName: {
//                    required: true,
//                    number: false
//                },
//                LastName: {
//                    required: true,
//                    number: false
//                },
//                Email: {
//                    required: true,
//                    email:true
//                }
//            },
//            messages: {
//                Phone: {
//                    required: "Required",
//                    matches: "ex:01xxxxxxxxx",  // <-- no such method called "matches"!
//                    minlength: "not valid",
//                    maxlength: "not valid"
//                },
//                FirstName: {
//                    required: "Required",
//                    number: "Please enter a valid name"
//                },
//                LastName: {
//                    required: "Required",
//                    number: "Please enter a valid name"

//                },
//                Email: {
//                    required: "Required",
//                    email: "Please enter valid email"
//                }
//            }

//        })
//    }
//});