$(document).ready(function () {

    $(".checkIn").datepicker({
        format: "yyyy-mm-dd",
        todayBtn: true,
        autoclose: true,
        startDate: new Date()
    })
        .on("changeDate", function (e) {
            var checkInDate = e.date, $checkOut = $(".checkOut");
            checkInDate.setDate(checkInDate.getDate() + 1);
            $checkOut.datepicker("setStartDate", checkInDate);
            $checkOut.datepicker("setDate", checkInDate).focus();
        });

    $(".checkOut").datepicker({
        format: "yyyy-mm-dd",
        todayBtn: true,
        autoclose: true
    });


    $("#jsBrand").change(function () {
        var req_data = {
            brendid: $(this).val()
        };
        $.ajax({
            url: "/car/modelsjr",
            type: "get",
            dataType: "json",
            data: req_data,
            success: function (response) {
                $("#jsModel").empty();

                $.each(response, function (key, value) {
                    $("#jsModel").append(`<option value="${value.ID}">${value.Name}</option>`);
                });
            },
            error: function (err) {
                $("#jsModel").empty();
                swal("Brend tapılmadı!", "error");

            }
        });
    });



    var form = $('#message-contact');
    var formMessages = $('.form-messages');
    $(form).submit(function (e) {
        e.preventDefault();
        var formData = $(form).serialize();
        $.ajax({
            type: 'POST',
            url: $(form).attr('action'),
            data: formData
        }).done(function (response) {
            $(formMessages).removeClass('error');
            $(formMessages).addClass('success');
            $(formMessages).text(response);
            $(this).find("input").val("");
            $(form).trigger("reset");
        }).fail(function (data) {
            $(formMessages).removeClass('success');
            $(formMessages).addClass('error');
            if (data.responseText !== '') {
                $(formMessages).text(data.responseText);
            } else {
                $(formMessages).text('Mesajınız göndərilərkən xəta baş verdi.');
            }
        });
    });


    $(document).ready(function () {
        $("#input-sort").on('change', function () {
            var selected = $(this).val();
            console.log(selected);
            $.ajax({
                url: "/Car/CarFilter",
                type: "GET",
                data: { value: selected },
                success: function (res) {
                    if (res !== null) {
                        $("#searchedhome").html(res);
                    }
                }
            });
        });
      

        $(document).on("click", "#searchwithAJAX", function () {
            var picklocation = $("#searchedPickUpLocation").val();
            var droplocation = $("#searchedDropOffLocation").val();
            var pickdate = $("#searchedpickdate").datepicker("getDate").toLocaleDateString();
            var dropdate = $("#searchedropdate").datepicker("getDate").toLocaleDateString();

            if (!picklocation || !droplocation || !pickdate|| !dropdate ) {
                swal("Boş buraxmayın", "Axtardığınız məntəqədə və seçilən tarixdə maşın yoxdur.", "error");
            }

            $.ajax({
                url: "/Car/SearchAJAX",
                type: "GET",
                data: {
                    pickuplocation: picklocation, dropofflocation: droplocation,
                    pickupdate: pickdate, dropoffdate: dropdate
                },
                beforeSend: function () {
                    jQuery("#status").fadeOut();
                    jQuery("#preloader").delay(350).fadeOut("slow");
                },
                success: function (res) {
                        $("#searchedhome").empty();
                        $("#searchedhome").html(res);
                },

                error: function () {
                    $("#searchedhome").empty();
                    $(".pagination").hide();
                    swal("Maşın tapılmadı", "Axtardığınız məntəqədə və seçilən tarixdə maşın yoxdur.", "error");
                }
            });

        });

        $(document).on("click", "#carfilterbtn", function () {
            var carmodel = $("#jsModel").val();
            console.log(carmodel);
            $.ajax({
                url: "/car/submittedcar",
                type: "POST",
                data: { ModelID: carmodel },
                success: function (res) {
                    $("#searchedhome").html(res);
                },
                error: function () {
                    swal("Təəssüf!", "Axtardığınız seçimə uyğun maşın yoxdur.", "error");
                }

            });
        });

    });
});

