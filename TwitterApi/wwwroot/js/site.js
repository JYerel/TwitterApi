﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("#addTwitterModal").on("show.bs.modal",
    function (event) {
        var button = $(event.relatedTarget); // Button that triggered the modal
        var recipient = button.data("twitter-recipient"); // Extract info from data-* attributes
        // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
        // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
        var modal = $(this);
        modal.find(".modal-title").text("Currently set for " + recipient);
        modal.find(".modal-body input").val(recipient);
    });
