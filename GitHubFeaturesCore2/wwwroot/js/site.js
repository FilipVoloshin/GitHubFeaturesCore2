$('#githubinfo_submit').click(function () {
    var requestType = $("#request_type").val();
    var token = $('input[name="__RequestVerificationToken"]', $('#githubinfo_form')).val();
    var dataToSend = {
        userName: $('#users_name').val(),
        repositoryName: $('#repo_name').val(),
        request: requestType
    };

    var dataWithAntiforgeryToken = $.extend(dataToSend, { '__RequestVerificationToken': token });
    var url = "";
    switch (requestType) {
        case "0":
            url = "/Home/CheckRepository";
            break;
        case "1":
            url = "/Home/CheckPullRequests";
            break;
        case "2":
            url = "/Home/CheckBranches";
            break;
        case "3":
            url = "/Home/CheckCommits";
            break;
        case "4":
            url = "https://raw.githubusercontent.com/" + dataToSend.userName + "/" + dataToSend.repositoryName + "/" + $("#path_value").val();
    }

    if (requestType !== "4") {
        $.ajax({
            url: url,
            type: "POST",
            data: dataWithAntiforgeryToken,
            success: function (data) {
                $("#result_window_pl").html(data);
                $("#result_window").modal('show');
            }
        });
    }
    else {
        if (dataToSend.userName && dataToSend.repositoryName && $("#path_value").val()) {
            $.get(url, function (data) {
                var win = window.open(url, '_blank');
                if (win) {
                    win.focus();
                } else {
                    alert('Please allow popups for this website');
                }
            }).fail(function () {
                alert("The dirrection " + url + " does not exist");
            });
        }
        else {
            alert("Fill in all fields");
        }
    }
});

function showHideAdditionalInfo(requestType) {
    if (requestType === "4") {
        $("#path_div").show();
    }
    else {
        $("#path_div").hide();
    }
}

$("#request_type").change(function () {
    showHideAdditionalInfo($("#request_type").val());
});


//C# Code part

$("#check-btn").click(function () {
    var token = $('input[name="__RequestVerificationToken"]', $('#csharp_form')).val();
    var dataToSend = {
        codePart: $("#csharpcode").val()
    };
    var dataWithAntiforgeryToken = $.extend(dataToSend, { '__RequestVerificationToken': token });
    $.ajax({
        url: "/CSharpCompile/GetCodeResult",
        type: "POST",
        data: dataWithAntiforgeryToken,
        success: function (data) {
            $("#result_window_pl").html(data);
            $("#result_window").modal('show');
        }
    });
});


//Keys settings 

$(document).delegate('#csharpcode', 'keydown', function (e) {
    var keyCode = e.keyCode || e.which;

    if (keyCode == 9) {
        e.preventDefault();
        var start = this.selectionStart;
        var end = this.selectionEnd;

        // set textarea value to: text before caret + tab + text after caret
        $(this).val($(this).val().substring(0, start)
            + "\t"
            + $(this).val().substring(end));

        // put caret at right position again
        this.selectionStart =
            this.selectionEnd = start + 1;
    }
});
