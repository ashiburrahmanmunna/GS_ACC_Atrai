var pageSize = 20;
var pageIndex = 0;
var selectedMedia;
var selectedInput;
var isMultipleAllowed = false;
var mediaArray = [];
var selectedMediasId;


$(function () {
    $(document).on('click', '[su-media-popup]', function () {
        $('.image-checkbox-checked').each(function () {
            $(this).removeClass('image-checkbox-checked');
        });
        mediaArray = [];
        selectedInput = $(this);
        //console.log(selectedInput);
        isMultipleAllowed = selectedInput.siblings('input[su-media-selected-input]').attr('su-media-selected-input') == 'multiple' ? true : false;
        //alert(isMultipleAllowed);
        $("#suMediaModal").modal('show');
        GetData();
    });

    $(document).on('click', '.load-more', function () {
        GetData();
    });
});

function GetData() {
    //alert('hit');
    $.ajax({
        type: 'GET',
        url: '/getpagedmedia',
        data: { "pageindex": pageIndex, "pagesize": pageSize },
        dataType: 'json',
        success: function (data) {
            console.log(data);
            if (data.length != 0) {
                //console.log("Data Available");
                for (var i = 0; i < data.length; i++) {
                    $('<label class="image-checkbox m-2"><img class="img-fluid" su-media-id="' + data[i].Id + '" src="/' + data[i].Name + '" alt="User picture" style="max-height: 100px;max-width:-webkit-fill-available"><i class="fa fa-check"></i></label>').hide().appendTo(".media-image").fadeIn(1000);
                }
                pageIndex++;
            } else {
                //console.log("Data Not Available");
                $("#nomoredata").show();
            }
        },
        beforeSend: function () {
            $(".load-more").text("Loading...");
        },
        complete: function () {
            $(".load-more").text("Load More");
        },
        error: function () {
            alert("Error while retrieving data!");
        }
    });
}

function workaroundDropzone() {
    //alert('hit');
    return "files";
}
Dropzone.autoDiscover = false;
var mediaDropzone = new Dropzone("#mediaDropzone", {
    paramName: workaroundDropzone,
    autoProcessQueue: false,
    acceptedFiles: "image/*,application/pdf",
    parallelUploads: 30, // Number of files process at a time (default 2)
    //maxFilesize: 1, // MB
    //maxFiles: 30,
    uploadMultiple: true,
    dictRemoveFile: 'Remove',
    //dictFileTooBig: 'Image is larger than 1MB',
    addRemoveLinks: true,
    error: function (file, errorMessage) {
        errors = true;
        console.log(errorMessage);
        var err = [];
        err.push(errorMessage);
        renderValidationError(err);
    },
    //success: function (file, response) {
    //    alert(JSON.stringify(response));
    //},

});

mediaDropzone.on("success", function (file) {
    setTimeout(function () { mediaDropzone.removeFile(file); }, 1000);
    $('[href="#nav-gallery"]').tab('show');
});

mediaDropzone.on("queuecomplete", function (file) {
    $(".media-image").empty();
    pageIndex = 0;
    GetData();
});

$('#btnSubmit').click(function () {
    mediaDropzone.processQueue();
});


jQuery(function ($) {
    
    //var isMultipleAllowed = false;
    //$('#allowmultiple').click(function () {
    //    isMultipleAllowed = $('#allowmultiple').is(':checked') ? true : false;
    //    $('.image-checkbox-checked').each(function () {
    //        $(this).removeClass('image-checkbox-checked');
    //    });
    //    mediaArray = [];
    //});
    //alert('hit');

    $(document).on('click', '.image-checkbox', function (e) {
        var selected = $(this).find('img').attr('su-media-id');
        console.log(selected);
        if ($(this).hasClass('image-checkbox-checked')) {
            $(this).removeClass('image-checkbox-checked');
            // remove deselected item from array
            mediaArray = $.grep(mediaArray, function (value) {
                return value != selected;
            });
        }
        else {
            if (isMultipleAllowed == false) {
                $('.image-checkbox-checked').each(function () {
                    $(this).removeClass('image-checkbox-checked');
                });
                mediaArray = [];
                mediaArray.push(selected);
            } else {
                if (mediaArray.indexOf(selected) === -1) {
                    mediaArray.push(selected);
                }
            }
            $(this).addClass('image-checkbox-checked');
        }
        //console.log(selected);
        getById(selected);
        console.log(mediaArray);
        selectedMediasId = mediaArray.join(",");
        //selectedMedia = selectedMediasId;
        //console.log(selectedMediasId);
        //console.log(isMultipleAllowed);
        e.preventDefault();
    });
});


function getById(id) {
    //alert('hit');

    $.ajax('/getmediabyid/' + id, {
        type: 'GET',
        success: function (response, status, xhr) {
            $('input[su-media-id]').val(response.Id);
            $('input[su-media-name]').val(response.Name);
            $('[su-media-name]').html(response.Name);
            $('input[su-media-title]').val(response.Title);
            $('input[su-media-tags]').val(response.Tags);
            $('input[su-media-tags]').amsifySuggestags();

            selectedMedia = response;
        },
        error: function (jqXhr, textStatus, errorMessage) {
            console.log(errorMessage);
        }
    });
}


//add selected image value to image section from gallery
$(document).on('click', '#selectmedia', function () {
    //alert('hit');
    console.log(selectedMedia);
    selectedInput.siblings('div').find('img[su-media-preview]').attr("src", "/" + selectedMedia.Name);
    selectedInput.siblings('input[su-media-selected-input]').val(selectedMediasId);
    selectedInput.siblings('div').addClass('set-selected-media');

});


//add remove-image icon dynamically if image not null
$(function () {
    $('div[su-media-section]').each(function () {
        var thisItemImageSrc = $(this).children('div').find('img[su-media-preview]').attr('src');
        console.log(thisItemImageSrc);
        if (!thisItemImageSrc.includes("no-image")) {
            $(this).children('div').addClass('set-selected-media');
        }
    });
})


//remove image after remove-image icon click
$(document).on('click', '.set-selected-media i', function () {
    //alert('hit');
    console.log(selectedMedia);
    var thisItem = $(this).closest('div[su-media-section]');
    thisItem.find('img[su-media-preview]').attr("src", "/media/images/no-image.png");
    thisItem.find('input[su-media-selected-input]').val('');
    thisItem.find('div').removeClass('set-selected-media');
});

$("#mediaUpdateForm").submit(function (event) {
    event.preventDefault();
    $f = $(event.currentTarget); // fetch the form object

    var url = $f.attr("action");
    var data = new FormData(this);
    $.ajax({
        url: url,
        method: "POST",
        cache: false,
        data: data,
        processData: false,
        contentType: false,
        enctype: 'multipart/form-data',
        success: function (response, status, xhr) {
            console.log(response);
        },
        error: function (jqXhr, textStatus, errorMessage) {
            console.log(errorMessage);
        },
        beforeSend: function () {
            $("#mediasavebtn").show();
        },
        complete: function (jqXHR, status) {
            $("#mediasavebtn").hide();
            if (status == "error") { notifier.open({ type: "error", message: jqXHR.statusText }); }
        }
    });
});


