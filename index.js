function GetPageData(link)
{
    var title1 = "";

    $.ajax({
        url: link,
        success: function(data) {

            // Create a placeholder element to contain all the incoming data
            var placeholder = document.createElement("hmtl");
            placeholder.style.display = "none";

            placeholder.innerHTML = data.responseText;

            // Get page data
            var title = $('title', placeholder);
            title1 = title;

            console.log(title);

            //Remove redundant data
            $(placeholder).remove();
            title1 = title;

            console.log(title);
        },
        error: function(error) {
            object.error = error;
        }
    });

    console.log(title1);

    return title1

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

   var firstName = "Antti";
   var lastName = "Veikkolainen";
   var workName = "Suomalaiset juomavat paljon olutta";

   var obj = GetPageData(link);
   console.log(obj);
   
   OutputSource({
            "lastName": lastName,
            "firstName": firstName,
            "date": date.NoDate,
            "workName": workName,
            "referred": date.Today,
            "link": link
        });

}


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