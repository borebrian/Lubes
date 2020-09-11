
    $(document).ready(function () {
        //displayname.value = item_name;
        //displayquantity.innerHTML = inputValue;

        //document.getElementById("displayname").innerHTML = a;
        //document.getElementById("displayquantity").innerHTML = document.getElementById("item_name1").value;
        var data = "@ViewBag.AllowPopup";

        if (data == "1") {

        $('#myModal').modal('show')

    }
        else {

    }


    });
