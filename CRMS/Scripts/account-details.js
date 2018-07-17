function accountFunction(accountnumber) {

    var address = "/crms/Home";
    //var address = "/Home";
    var aname = "";
    $.ajax({
        type: "GET",
        url: address + "/AccountDetails",
        contentType: "application/json",
        datatype: 'json',
        data: { accountNumber: accountnumber },
        async: false,
        success: function(data) {
            //console.log(data);
            for (var i = 0; i < data.length; i++) {
                
                aname = data[0]['AccountName'];
              
            }
        }
    });
    return aname;
}