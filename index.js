//#region Source Generation 

function GetPageData(link, callback)
{
    var xmlhttp = window.XMLHttpRequest ?
        new XMLHttpRequest() :                  // Code for Internet Explorer 7+, Firefox, Chrome, Opera, and Safari
        new ActiveXObject("Microsoft.XMLHTTP"); // Code for Internet Explorer 6 and Internet Explorer 5

    xmlhttp.onreadystatechange = function(data) {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {

            var title = "";
            var author = "";
            var date = "";

            var parser = new DOMParser();
            var doc = parser.parseFromString(xmlhttp.responseText, "text/html");
            
            title = doc.getElementsByTagName("title")[0].innerText;
            date = doc.lastModified;

            title = doc.getElementsByTagName("title")[0].innerHTML;

            var info = doc.getElementsByTagName('META')[0];
            for (var i= 0 ; i < info.length; i++)
                if (info[i].getAttribute('NAME').toLowerCase() == 'author')
                   author = info[i].getAttribute('CONTENT');

            if (callback)
            callback({"title": title, "author": author, "date": date});
        }
    }
    xmlhttp.open("GET", 'https://api.allorigins.win/get?url=' + encodeURIComponent(link), true);
    xmlhttp.send();
}

function OutputSource(source)
{
    var source = `${source.lastName}, ${source.firstName.charAt(0)}. ${source.date}. ${source.workName}. Viitattu: ${source.referred}. ${source.link}`;

    var textarea = document.getElementById("textarea");
    textarea.value = source;
    //textarea.value = "Tuomi, S. & Latvala, E. N.d. Opinnäytetyön ohjaajan käsikirja. Jyväskylä: Jyväskylän ammattikorkeakoulu. Viitattu 16.8.2016. https://oppimateriaalit.jamk.fi/yamk-kasikirja/.";
}

function CreateSource()
{
    var link = document.getElementById("link").value;

    /*
    Step 1. Who -> Sukunimi, Etunimen ensimmäinen kirjain.
    Step 2. When -> Julkaisuvuosi
    Step 3. What -> Artikkelin otsikko
    Step 4. Where ->
    - Optional, Step 5. -> Viitattu
    - Optional, Step. 6 -> linkki
    */

   var today = new Date();
   var dd = String(today.getDate()).padStart(2, '0');
   var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
   var yyyy = today.getFullYear();

   var date = {
       NoDate: "N.d",
       Today: dd + '.' + mm + '.' + yyyy
    };

   GetPageData(link, function(response) {
    OutputSource({
        "lastName": response.author,
        "firstName": response.author,
        "date": response.date ?? date.NoDate,
        "workName": response.title,
        "referred": date.Today,
        "link": link
    });
   });
}

//#region Copy Functionality

function Copy()
{
    var copyText = document.getElementById("myInput");
    copyText.select();
    copyText.setSelectionRange(0, 99999);
    document.execCommand("copy");
    
    var tooltip = document.getElementById("myTooltip");
    tooltip.innerHTML = "Copied: " + copyText.value;
}
  
function outFunc() {
    var tooltip = document.getElementById("myTooltip");
    tooltip.innerHTML = "Copy to clipboard";
}

//#endregion

function ToggleManualInfo()
{
    var inputs = document.getElementById("inputs");
    $(inputs).toggleClass("show");

}