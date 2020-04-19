// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {

    $('.select2').select2({
        theme: 'bootstrap4'
    });


    var placeholderElement = $('#placeholder');

    $('button[data-toggle="ajax-modal"]').click(function (event) {
        console.log("here")
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            placeholderElement.empty();
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
        });
        $('.select2').select2({
            theme: 'bootstrap4'
        });
    });

    $('a[data-toggle="ajax-modal"]').click(function (event) {
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            placeholderElement.empty();
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
        });
        $('.select2').select2({
            theme: 'bootstrap4'
        });
    });


    placeholderElement.on('click', 'button[data-save="modal"]', function (event) {
        event.preventDefault();
        var form = placeholderElement.find('.modal').find('form');
        var formId = placeholderElement.find('.modal').attr('id');
        var actionUrl = form.attr('action');
        var dataToSend = form.serialize();
        console.log(actionUrl);
        $.post(actionUrl, dataToSend).done(function (data) {
            $('.select2').select2({
                theme: 'bootstrap4'
            });
            var newBody = $('.modal-body', data);
            placeholderElement.find('.modal-body').replaceWith(newBody);
            var validation = $('span.text-danger').text();
            if (validation == '') {
                placeholderElement.find('.modal').modal('hide');
                if (formId == 'new-user') {
                    placeholderElement.find('.modal').modal('hide');
                    //location.reload();
                }
                if (formId == 'view-user') {
                    LoadIndex('');
                    //location.reload();
                }
                if (formId == 'pdr-modal') {
                    LoadDashboard('');
                    //location.reload();
                }
            }
        });
    });
})

function ChangePhoto(input,width,height) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#imgb64').val(e.target.result);
            $('#cur-pic')
                .attr('src', e.target.result)
                .width(width)
                .height(height);
        };

        reader.readAsDataURL(input.files[0]);
    }
}

function CaclAge(date) {
    var birth = new Date(date);
    var curr = new Date();
    var diff = curr.getTime() - birth.getTime();
    document.getElementById("PatientNavigation_Age").value = Math.floor(diff / (1000 * 60 * 60 * 24 * 365.25));
}

function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#imgb64').val(e.target.result);
        };

        reader.readAsDataURL(input.files[0]);
    }
}

function LoadDashboard(search) {
    var url = "/Home/DashboardPartial?search=" + search;
    $.ajax({
        url: url,
        tpye: 'get',
        async: true,
        success: function (output) {
            $('#dashboard_table').html(output).fadeIn("slow");
        }
    });
}

function LoadIndex(search) {
    var url = "/Pdrusers/PartialIndex?search=" + search;
    $.ajax({
        url: url,
        tpye: 'get',
        async: true,
        success: function (output) {
            $('#indexpartial').html(output).fadeIn("slow");
        }
    });
}

function AddToTeam(user) {
    var placeholderElements = $('#placeholder');
    var url = "/Pdrusers/AddUsers?id=" + user;
    $.ajax({
        url: url,
        tpye: 'get',
        async: true,
        success: function (output) {
            var newBody = $('.modal-body', output);
            placeholderElements.find('.modal-body').replaceWith(newBody);
            LoadIndex('');
        }
    });
}

function RemoveToTeam(user) {
    var url = "/Pdrusers/RemoveToTeam?user=" + user;
    $.ajax({
        url: url,
        tpye: 'get',
        async: true,
        success: function () {
            LoadIndex('');
        }
    });
}

function ViewPdr(patient) {
    var placeholderElement = $('#placeholder');
    var url = "/Home/PDRModal?id=" + patient;
    $.get(url).done(function (data) {
        placeholderElement.empty();
        placeholderElement.html(data);
        placeholderElement.find('.modal').modal('show');
    });
}

function ViewUser(user) {
    var placeholderElement = $('#placeholder');
    var url = "/Pdrusers/ViewUser?id=" + user;
    $.get(url).done(function (data) {
        placeholderElement.empty();
        placeholderElement.html(data);
        placeholderElement.find('.modal').modal('show');
    });
}

function GetBarangayFiltered(id) {
    var urls = "/helper/barangays/2/" + id;
    return $.ajax({
        url: urls,
        type: 'get',
        async: true
    });
}


function SetBarangay(id) {

    var munct;
    var barangaySelect;
    if (id == '1') {
        munct = $('#patient_muncity').val();
        barangaySelect = $('#patient_barangay');
    }
    else {
        munct = $('#guardian_muncity').val();
        barangaySelect = $('#guardian_barangay');
    }

    $.when(GetBarangayFiltered(munct)).done(function (output) {
        barangaySelect.empty()
            .append($('<option>', {
                value: '',
                text: 'Select Barangay'
            }));
        jQuery.each(output, function (i, item) {
            barangaySelect.append($('<option>', {
                value: item.id,
                text: item.description
            }));
        });
    });
}