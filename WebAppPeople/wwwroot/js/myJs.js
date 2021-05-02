var peopleBtnElement = document.getElementById("peopleBtn");
var personBtnElement = document.getElementById("searchBtn");
var removeBtnElement = document.getElementById("removeBtn");
var searchIdInputElement = document.getElementById("searchTextInput");
var resultDiv = document.getElementById("result");

peopleBtnElement.addEventListener("click", DisplayPeople);
personBtnElement.addEventListener("click", DisplayPerson);
removeBtnElement.addEventListener("click", RemovePerson);


function DisplayPeople() {
    $.get("AjaxPeople/DisplayPeople", function (data, status) {
        console.log("Data: " + data + "\nStatus: " + status);
        resultDiv.innerHTML = data;
    });
}

function DisplayPerson() {
    $.post("AjaxPeople/DisplayPerson",
        {
            id: searchIdInputElement.value
        },
        function (data, status) {
            console.log("Data: " + data + "\nStatus: " + status);
            resultDiv.innerHTML = data;
        });
}

function RemovePerson() {
    $.post("AjaxPeople/RemovePerson",
        {
            id: searchIdInputElement.value
        },
        function (data, status) {
            console.log("Data: " + data + "\nStatus: " + status);
                resultDiv.innerHTML = data;
        });
}
