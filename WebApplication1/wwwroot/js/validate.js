//Phone Regex Validator
jQuery.validator.addMethod("matches", function (phone_number, element) {
    phone_number = phone_number.replace(/\s+/g, "");
    return this.optional(element) || phone_number.length > 9 &&
        phone_number.match(/^0\d{10}$/);
}, "Please specify a valid phone number");

jQuery.validator.addMethod("exists", function (phone_number, element) {
    phone_number = phone_number.replace(/\s+/g, "");
    return this.optional(element) || phone_number.length > 9 &&
        phone_number.match(/^0\d{10}$/);
}, "Please specify a valid phone number");

//Name Regex Validator
jQuery.validator.addMethod("Namematch", function (Name, element) {
    Name = Name.replace(/\s+/g, "");
    return this.optional(element) || Name.length > 1 &&
        Name.match(/^[a-zA-Z .'-]+$/);
}, "Please specify a valid Name");

//Password Regex Validator
jQuery.validator.addMethod("Passmatch", function (Password, element) {
    Password = Password.replace(/\s+/g, "");
    return this.optional(element) || Password.length > 5 &&
        Password.match(/^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#/\$%\^&\*])(?=.{6,})/);
}, "Please specify a valid  Password");

//Order Validation
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


//Billing Address
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
                    Namematch: true
                },
                "Input.LastName": {
                    required: true,
                    Namematch: true
                },
                "Input.Email": {
                    required: true,
                    email:true
                },
                "Input.Password": {
                    required: true,
                    Passmatch: true
                }
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
                    number: "Please enter a valid name"
                },
                "Input.LastName": {
                    required: "Required",
                    number: "Please enter a valid name"

                },
                "Input.Email": {
                    required: "Required",
                    email: "Please enter valid email"
                },
                "Input.Password": {
                    required: "Required",
                    Passmatch: "Password must have at least 6 characters, 1 number, 1 upper and 1 lowercase, one special chars"
                },
            }

        })
    }
});



////categories Form
$(function () {
    var CategoriesForm = $("#CategoriesForm");
    if (CategoriesForm.length) {
        CategoriesForm.validate({

            rules: {
                CategoryName: {
                    required: true
                }
            },
            messages: {
                CategoryName: {
                    required: "Required"
                }

            }
        })
        }
});
//Vendor Request
$(function () {
    var VendorRequest = $("#form1");
    console.log("omar");
    if (VendorRequest.length) {
        VendorRequest.validate({

            rules: {
                Name: {
                    required: true,
                    minlength: 3,
                    maxlength: 20
                },
                Description: {
                    required: true,
                    minlength: 3,
                    maxlength: 20
                },
                Price: {
                    required: true,
                    number: true
                },
                Size: {
                    required: true,
                },
            },
            messages: {
                Name: {
                    required: "Required",
                    minlength: "Minimum length: 3 charachters",
                    maxlength: "Maximum length: 20 charachters"
                },
                Description: {
                    required: "Required",
                    minlength: "Minimum length: 3 charachters",
                    maxlength: "Maximum length: 20 charachters"
                },
                Price: {
                    required: "Required",
                    number: "Please enter the proce Correctly"
                },
                Size: {
                    required: "Required",
                }
            }

        })
    }
});

// PhoneNumber Check 

$('#Input_PhoneNumber').on('input', function () {
    var phoneval = document.getElementById('Input_PhoneNumber').value;
   
    if (phoneval.length > 10) {
        $.ajax({
            url: "/Coupon/checkPhone",
            method: "GET",
            data: { phone: phoneval },
            success: function (data) {
                if (data == "Sorry, This Phone number already exists") {
                    $("#pleasework").text(data);
                    $("#pleasework").css({
                        color: "red"
                    });
                    $('#registerSubmit').click(function (e) {

                        e.preventDefault();
                        e.stopPropagation();
                        e.stopImmediatePropagation();
                    });
                } else {
                    $("#pleasework").text(data);
                    $('#registerSubmit').unbind('click');

                }

            },

            error: function (e) {
                console.log(e);
                $("#PhoneNumbernn").text(e);
            }

        });
    }
});



