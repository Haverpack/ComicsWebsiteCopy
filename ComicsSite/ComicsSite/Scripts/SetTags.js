const { post } = require("jquery");
var currentComic;

//Reference: https://www.w3schools.com/howto/howto_js_filter_lists.asp
function myFunction() {
    // Declare variables
    var input, filter, ul, li, a, i, txtValue;
    input = document.getElementById('myInput');
    filter = input.value.toUpperCase();
    ul = document.getElementById("myUL");
    li = ul.getElementsByTagName('li');

    //Loop through all list items, and hide those who don't match the search query
    for (i = 0; i < li.length; i++) {
        a = li[i].getElementsByTagName("a")[0];
        txtValue = a.textContent || a.innerText;
        if (txtValue.toUpperCase().indexOf(filter) > -1) {
            li[i].style.display = "";
        } else {
            li[i].style.display = "none";
        }
    }


}

function Logger(content) {
    temp = content.slice(1, -1);
    temp = temp.replaceAll('"', '');
    arr = temp.split(",");

    var list = document.createElement('ul');

    var i = 0;
    for (i = 0; i < arr.length; i++) {
        var item = document.createElement('li');
        var item2 = document.createElement('a');
        item2.id = i + 14;
        //item2.href = "https://localhost:44352/Home/Reader";
        item2.setAttribute("onclick", "SetCurrentComic(this.id)");
        console.log(item2.id);
        //console.log(item2.href);

        item2.appendChild(document.createTextNode(arr[i]));
        item.appendChild(item2);
        list.appendChild(item);
        //console.log(arr[i]);
    }

    document.getElementById("myUL").innerHTML = list.innerHTML;
}

function SetCurrentComic(id) {
    currentComic = document.getElementById(id).innerText;
    console.log(currentComic);

    var list = document.createElement('ul');
    var item = document.createElement('li');
    var statement = "Currently settings tags For: " + currentComic;

    item.appendChild(document.createTextNode(statement));
    list.appendChild(item);

    document.getElementById("currCom").innerHTML = list.innerHTML;
}

function getClickedTag() {
    var i;
    var arr = []

    for (i = 1; i < 14; i++) {
        var currentTag = document.getElementById(i);
        if (currentTag.getElementsByTagName("input")[0].checked) {
            arr.push(currentTag.innerText);
        }

    }

    return arr;

    /*if (arr.length > 0) {
        tagFilter(arr);
    }
    else {
        onStart();
    }*/
}

function tagFilter(tags) {
    //Reference: https://stackoverflow.com/questions/28895101/pass-string-array-as-data-in-jquery-ajax-to-web-api
    var uri = "https://localhost:44366/comics/tags";
    //var tags = ['Adventure'];

    $.ajax({
        url: uri,
        type: 'GET',
        data: { tags: tags },
        cache: false,
        dataType: 'json',
        async: true,
        processData: true,
        success: function (data) {
            console.log("success");
            var translate = JSON.stringify(data);
            Logger(translate);
        },
        error: function (data) {
            console.log("failed");
        }
    });
}

function onStart() {
    var uri = "https://localhost:44366/comics/list";

    $.ajax({
        url: uri,
        type: 'GET',
        cache: false,
        dataType: 'json',
        async: true,
        processData: true,
        success: function (data) {
            console.log("success");
            var translate = JSON.stringify(data);
            console.log(translate);
            Logger(translate);
        },
        error: function (data) {
            console.log("failed");
        }
    });
}

function callController() {
    var tags = getClickedTag();
    var i;

    
    for (i = 0; i < tags.length; i++) {
        
        $.ajax({
            url: 'https://localhost:44366/comic/tag',
            type: 'POST',
            data: { 'comicTitle': currentComic , 'tag': tags[i]},
            cache: false,
            dataType: 'application/json',
            async: true,
        });
    }

    

}