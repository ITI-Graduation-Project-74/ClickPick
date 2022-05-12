jQuery.validator.addMethod("NameMatch", function (Name, element) {
    Name = Name.replace(/\s+/g, "");
    return this.optional(element) || Name.length > 1 &&
        Name.match(/^[a-z ,.'-]+$/i);
}, "Please specify a valid Name");


jQuery.validator.addMethod("matches", function (phone_number, element) {
    phone_number = phone_number.replace(/\s+/g, "");
    return this.optional(element) || phone_number.length > 9 &&
        phone_number.match(/^0\d{10}$/);
}, "Please specify a valid phone number");

jQuery.validator.addMethod("PassMatch", function (Password, element) {
    Password = Password.replace(/\s+/g, "");
    return this.optional(element) || Password.length > 5 &&
        Password.match(/^(?=.[A-Z])(?=.[a-z])(?=.[0-9]).$/);
}, "Please specify a valid PassWord");

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
$(function () {
    var $registerForm = $("#registerForm");
    if ($registerForm.length) {
        $registerForm.validate({

            rules: {
                "Input.PhoneNumber": {
                    required: true,
                    matches: true, // <-- no such method called "matches"!
                    minlength: 11,
                    maxlength: 11
                },
                "Input.FirstName": {
                    required: true,
                    number: false,
                    NameMatch: true
                },
                "Input.LastName": {
                    required: true,
                    number: false,
                    NameMatch: true
                },
                "Input.Email": {
                    required: true,
                    email:true
                },
                "Input.Password": {
                    required: true,
                    PassMatch:true

                },
            
                
            },
            messages: {
                "Input.PhoneNumber": {
                    required: "Required",
                    matches: "ex:01xxxxxxxxx",  // <-- no such method called "matches"!
                    minlength: "not valid",
                    maxlength: "not valid"
                },
                "Input.FirstName": {
                    required: "Required",
                    NameMatch: "Please enter a valid name"
                },
                "Input.LastName": {
                    required: "Required",
                    NameMatch: "Please enter a valid name"

                },
                "Input.Email": {
                    required: "Required",
                    email: "Please enter valid email"
                },
                "Input.Password": {
                    required: "Required",
                    PassMatch: "Password must have at least 8 characters, 1 number, 1 upper and 1 lowercase, no special chars"

                }
            }

        })
    }
});

$(".error").css("color", "red");