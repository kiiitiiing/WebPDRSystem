// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {

    
    $('.select2').select2({
        theme: 'bootstrap4'
    });

    $('input').on('change', function () {
        console.log('input changed');
        $('input').removeClass('input-validation-error');
    });

    var placeholderElement = $('#placeholder');

    var dmf = $('#daily_monitoring_form');

    $('button[data-toggle="ajax-modal"]').click(function (event) {
        console.log("here")
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            placeholderElement.empty();
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
        });
    });

    $('a[data-toggle="ajax-modal"]').click(function (event) {
        console.log('yow?');
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            placeholderElement.empty();
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
        });
    });


    var otherdets = $('#other_details');
    var temps = $('#temperature');

    temps.click(function () {
        console.log('sad');
    });

    otherdets.click(function () {
        console.log('hapuattr');
    });
    

    dmf.on('click', 'button[data-save="modal"]', function (event) {
        //Showload();
        placeholderElement.empty();
        event.preventDefault();
        event.stopImmediatePropagation();
        var form = dmf.find('.modal').find('form');
        var formId = dmf.find('.modal').attr('id');
        var actionUrl = form.attr('action');
        var dataToSend = form.serialize();
        console.log('1');
        $.post(actionUrl, dataToSend).done(function (data) {
            $('.select2').select2({
                theme: 'bootstrap4'
            });
            var newBody = $('.modal-body', data);
            dmf.find('.modal-body').replaceWith(newBody);
            Hideload();
            var validation = $('span.text-danger').text();
            if (validation == '') {
                dmf.find('.modal').modal('hide');
                if (formId == 'new-user') {
                    dmf.empty();
                    //location.reload();
                }
                if (formId == 'view-user') {
                    LoadIndex('');
                    dmf.empty();
                    //location.reload();
                }
                if (formId == 'pdr-modal') {
                    LoadDashboard('');
                    dmf.empty();
                    //location.reload();
                }
                if (formId == 'QDFormModal') {
                    LoadDashboard('');
                    dmf.empty();
                    //location.reload();
                }
                if (formId == 'QDFormModal') {
                    LoadDashboard('');
                    dmf.empty();
                    //location.reload();
                }
            }
        });
    });


    placeholderElement.on('click', 'button[data-save="modal"]', function (event) {
        //Showload();
        event.preventDefault();
        event.stopImmediatePropagation();
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
            Hideload();
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
                if (formId == 'pdr-modal' || formId == 'ReferralModal' || formId == 'attention' || formId == 'QNFormModal' || formId == 'QDFormModal') {
                    LoadDashboard('');
                    //location.reload();
                }
                if (formId == 'edit-census') {
                    LoadCensus();
                }
                if (formId == 'change-name-modal') {
                    LoadMedHistory();
                }
                if (formId == 'edit-meds') {
                    LoadMedHistory();
                }
            }
        });
    });
})


function Attended(id) {
    var url = "/Home/Attended?id=" + id;
    console.log('here i am ' + url);
    $.ajax({
        url: url,
        tpye: 'POST',
        async: true,
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.responseText);
            alert(thrownError);
        }
    });
    setTimeout(LoadDashboard(''), 1500);
}

function startTime() {
    var today = new Date();
    var h = today.getHours();
    var m = today.getMinutes();
    var s = today.getSeconds();
    var culture = "AM";
    m = checkTime(m);
    s = checkTime(s);
    if (h > 12) {
        culture = "PM";
        h = h - 12;
    }
    document.getElementById('time-top').innerHTML =
        h + ":" + m + ":" + s + " " + culture;
    var t = setTimeout(startTime, 500);
}
function checkTime(i) {
    if (i < 10) { i = "0" + i };  // add zero in front of numbers < 10
    return i;
}

//CENSUS

function startTime1() {
    console.log()
    var today = new Date();
    var h = today.getHours();
    var m = today.getMinutes();
    var s = today.getSeconds();
    var culture = "AM";
    m = checkTime1(m);
    s = checkTime1(s);
    if (h > 12) {
        culture = "PM";
        h = h - 12;
    }
    document.getElementById('time-top1').innerHTML =
        h + ":" + m + ":" + s + " " + culture;
    var t = setTimeout(startTime1, 500);
}
function checkTime1(i) {
    if (i < 10) { i = "0" + i };  // add zero in front of numbers < 10
    return i;
}

//END

function Showload() {
    $('#loading').removeAttr('hidden');
}

function Hideload() {
    $('#loading').css('background', 'none');
}

function UpdateQnForm(formId) {

    var placeholderElement = $('#placeholder');
    placeholderElement.find('.modal').modal('hide');
    if (formId != '') {
        var url = "/Home/UpdateQnForm?formId=" + formId;
        console.log(url);
        $.ajax({
            url: url,
            tpye: 'get',
            async: true,
            success: function (data) {
                placeholderElement.empty();
                placeholderElement.html(data);
                placeholderElement.find('.modal').modal('show');
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(xhr.responseText);
                alert(thrownError);
            }
        });
    }
    else {
        console.log('No id');
    }
}


function EditMedHistory(id) {
    var url = "/Pdrusers/EditMed?medHistoryId=" + id;
    var placeholderElement = $('#placeholder');
    $.ajax({
        url: url,
        tpye: 'get',
        async: true,
        success: function (data) {
            placeholderElement.empty();
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.responseText);
            alert(thrownError);
        }
    });
}


function OpenForm(id, action, controller) {
    if (id != '') {
        setTimeout(function () {
            var placeholderElement = $('#placeholder');
            var url = "/" + controller + "/" + action + "?pdrId=" + id;
            if (action == 'UpdateQnForm') {
                url = "/" + controller + "/" + action + "?pisti=" + id;
            }
            $('#loadings').modal('toggle');
            console.log(url);
            $.ajax({
                url: url,
                tpye: 'get',
                async: true,
                success: function (data) {
                    $('body').find('#loadings').modal('toggle');
                    //Hideload();
                    placeholderElement.empty();
                    placeholderElement.html(data);
                    placeholderElement.find('.modal').modal('show');
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    $('body').find('#loadings').modal('toggle');
                    alert(xhr.responseText);
                    alert(thrownError);
                }
            });
           /* $.get(url).done(function (data) {
                placeholderElement.empty();
                placeholderElement.html(data);
                placeholderElement.find('.modal').modal('show');
            });*/
        }, 300);
    }
    else {
        console.log('No id');
    }
}

function EditCensus() {
    var url = "/Dashboard/EditCensus"
    var placeholderElement = $('#placeholder');
    $.ajax({
        url: url,
        tpye: 'GET',
        async: true,
        success: function (data) {
            placeholderElement.empty();
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.responseText);
            alert(thrownError);
        }
    });
}

function LabResultScan(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#imgb64').val(e.target.result);
            $('#cur-pic')
                .attr('src', e.target.result)
                .addClass('cur-pic')
                .removeAttr('hidden');
        };

        reader.readAsDataURL(input.files[0]);
    }
}

function ChangePhoto(input,width,height) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#imgb64').val(e.target.result);
            $('#cur-pic')
                .attr('src', e.target.result)
                .addClass('cur-pic');
        };

        reader.readAsDataURL(input.files[0]);
    }
}

function ChangeName(patientId, medName) {
    var url = "/Pdrusers/ChangeMedname?patientId=" + patientId + "&medName=" + medName;
    var placeholderElement = $('#placeholder');
    $.ajax({
        url: url,
        tpye: 'GET',
        async: true,
        success: function (data) {
            placeholderElement.empty();
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.responseText);
            alert(thrownError);
        }
    });
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

function LoadIDP() {
    var url = "/Dashboard/ImmediateDashboardPartial";
    $.ajax({
        url: url,
        tpye: 'get',
        async: true,
        success: function (output) {
            $('#idashboard_table').html(output).fadeIn("slow");
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.responseText);
            alert(thrownError);
        }
    });
}

function LoadCensus() {
    var url = "/Dashboard/CensusPartial";
    $.ajax({
        url: url,
        tpye: 'get',
        async: true,
        success: function (output) {
            $('#census_main').html(output).fadeIn("slow");
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.responseText);
            alert(thrownError);
        }
    });

}

function LoadMedHistory() {
    var url = "/Pdrusers/MedhistoryPartial";
    $.ajax({
        url: url,
        tpye: 'get',
        async: true,
        success: function (output) {
            $('#med_history').html(output).fadeIn("slow");
            Hideload();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.responseText);
        }
    });
}

function LoadDashboard(search) {
    var url = "/Home/DashboardPartial?search=" + search;
    $.ajax({
        url: url,
        tpye: 'get',
        async: true,
        success: function (output) {
            $('#dashboard_table').html(output).fadeIn("slow");
            Hideload();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.responseText);
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