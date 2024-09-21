$(document).ready(function () {
    BindCustomerList();
    BindStateList();
    BindGenderList();

})
// Get modal element
var modal = document.getElementById("customerModal");

// Get the button that opens the modal
var btn = document.getElementById("openModalBtn");

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// When the user clicks the button, open the modal
btn.onclick = function () {

    modal.style.display = "block";
}

// When the user clicks on <span> (x), close the modal
span.onclick = function () {
    $('#frmCustomer')[0].reset();
    modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modal) {
        $('#frmCustomer')[0].reset();
        modal.style.display = "none";
    }
}
function BindGenderList() {
    debugger;
    $.ajax({
        url: 'Home/GetGenderList',
        dataType: "json",
        type: "GET",
        success: function (data) {
            var genderDropdown = $('#GenderId'); // jQuery selector

            // Clear existing options
            genderDropdown.empty();

            // Add new options from the fetched data
            genderDropdown.append($('<option></option>').text('-- Select Gender --'));
            $.each(data, function (index, item) {
                genderDropdown.append($('<option></option>').val(item.value).text(item.text));
            });
        },
        error: function (xhr, status) {
            console.error("Error fetching Gender list:", status);
        }
    });
}

function BindStateList() {
    debugger;
    $.ajax({
        url: "Home/GetStateList",
        dataType: "json",
        type: "GET",
        success: function (data) {
            var stateDropdown = $('#StateId'); // jQuery selector

            // Clear existing options
            stateDropdown.empty();

            // Add new options from the fetched data
            stateDropdown.append($('<option></option>').text('-- Select State --'));
            $.each(data, function (index, item) {
                stateDropdown.append($('<option></option>').val(item.value).text(item.text));
            });
        },
        error: function (xhr, status) {
            console.error("Error fetching state list:", status);
        }
    });
}

function onStateChange(stateid) {
    debugger;
    var _stateId = $(stateid).val();
    if (_stateId > 0) {
        GetDistrict(_stateId);
    }

}

function GetDistrict(_stateId) {

    if (_stateId != null && _stateId != "") {
        $.ajax({
           
            url:"Home/GetDistrictList",
            data: { stateId: _stateId },
            dataType: "json",
            type: "GET",
            async: false,
            success: function (data) {
                var districtDropdown = $('#DistrictId'); // jQuery selector
                // Clear existing options
                districtDropdown.empty();
                // Add new options from the fetched data
                districtDropdown.append($('<option></option>').text('-- Select District --'));
                $.each(data, function (index, item) {
                    districtDropdown.append($('<option></option>').val(item.value).text(item.text));
                });
            },
            error: function (xhr, status) {
                console.error("Error fetching District list:", status);
                Swal.fire("Error: ", "Error fetching District list:", "error");
            }
        });
    }
}


function CheckValidation() {
    var isValid = true;
    var name = $('#Name').val();
    var regex = /^[a-zA-Z]+$/;

    if (regex.test(name) == false || name == "") {
        Swal.fire("Warning !", "Only alphabets are allowed!", "warning");
        return false;
    }
    else if ($('#GenderId').val() == "" || $('#GenderId').val() == "0" || $('#GenderId').val() == "-- Select Gender --") {
        Swal.fire("Warning !", "Please Select Gender!", "warning");
        return false;
    }
    else if ($('#StateId').val() == "" || $('#StateId').val() == "0" || $('#StateId').val() == "-- Select State --") {
        Swal.fire("Warning !", "Please Select State!", "warning");
        return false;
    }
    else if ($('#DistrictId').val() == "" || $('#DistrictId').val() == "0" || $('#DistrictId').val() == "-- Select District --") {
        Swal.fire("Warning !", "Please Select District!", "warning");
        return false;
    }
    return isValid;
}


$('#submitButton').click(function (event) {
    event.preventDefault(); // Prevent the default form submission
    debugger;
    var _customerId = $('#CustomerId').val();
    var isValid = CheckValidation();
    if (isValid) {
        var customer = {
            Name: $('#Name').val(),
            GenderId: $('#GenderId').val(),
            StateId: $('#StateId').val(),
            DistrictId: $('#DistrictId').val(),
            CustomerId: _customerId == "" ? 0 : _customerId
        };

        $.ajax({
            url: 'Home/Index',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(customer),
            success: function (response) {
                if (response.status) {
                    Swal.fire("Done !", response.msg + " !", "success");
                    modal.style.display = "none";
                    BindCustomerList();
                } else {
                    Swal.fire("Error: ", + response.msg + "", "error");
                }
            },
            error: function (xhr) {
                console.error("AJAX error:");
                Swal.fire("Error: ", "Server Error ", "error");
            }
        });
    }
});


function BindCustomerList() {
    debugger;
    $.ajax({
        url: "Home/GetCustomerList",
        dataType: "json",
        type: "GET",
        success: function (data) {
            var tableBody = $('#customerTableBody');
            var i = 1;
            // Clear existing options
            tableBody.empty();
            $.each(data, function (index, item) {
                var row = '<tr>' +
                    '<td>' + (i++) + '</td>' +
                    '<td>' + item.name + '</td>' +
                    '<td>' + item.genderName + '</td>' +
                    '<td>' + item.stateName + '</td>' +
                    '<td>' + item.districtName + '</td>' +
                    '<td><button class=" btn-info btn-sm m-1" onclick="btnUpdateclick(' + item.customerId + ')">Edit</button>' +
                    '<button class=" btn-danger btn-sm m-1" onclick="btnDeleteclick(' + item.customerId + ')" >Delete</button></td>' +
                    '</tr>';

                tableBody.append(row);
            });
        },
        error: function (xhr) {
            console.error("Error fetching state list:");
        }
    });
}

// Bind Delete button click event
function btnUpdateclick(customerId) {
    debugger;
    if (customerId != 0) {
        $.ajax({
            url: 'Home/GetCustomerById',
            type: 'GET',
            async: false,
            data: { CustomerId: customerId },
            success: function (response) {
                if (response != null) {
                    $('#Name').val(response.name);

                    $('#GenderId').val(response.genderId).change();
                    $('#StateId').val(response.stateId).trigger('change');
                    $('#CustomerId').val(response.customerId);
                    $("#DistrictId option[value=" + response.districtId + "]").prop("selected", true);
                    $("#submitButton").val("Update Customer");
                    modal.style.display = "block";

                } else {
                    Swal.fire("Error !", " !", "error");
                }
            },
            error: function (xhr) {
                console.error("AJAX error:");
                Swal.fire("Error !", "Server Error", "error");
            }
        });

    }


};

// Bind Update button click event
function btnDeleteclick(customerId) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes'
    }).then((result) => {
        if (result.isConfirmed) {

            $.ajax({
                url: 'Home/DeleteCustomer',
                type: 'GET',
                data: { CustomerId: customerId },
                success: function (response) {
                    if (response.status == 1) {
                        Swal.fire("Done !", response.msg + " !", "success");
                        BindCustomerList();
                    } else {
                        Swal.fire("Error !", response.msg + " !", "error");
                    }
                },
                error: function (xhr) {
                    console.error("AJAX error:");
                    Swal.fire("Error !", "Server Error", "error");
                }
            });

        }
        else {
            //fn_EnableButton('#btnTopUp', 'Submit')
        }

    })
}