document.onload = function()
{
    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    const lang = urlParams.get('lang')

    // TODO: Update lang check box

    document.getElementById("lang").checked = lang === "fi" ? true : false;
}


//#region Source Generation 

function GetPageData(link, callback)
{
    var xmlhttp = window.XMLHttpRequest ?
        new XMLHttpRequest() :                  // Code for Internet Explorer 7+, Firefox, Chrome, Opera, and Safari
        new ActiveXObject("Microsoft.XMLHTTP"); // Code for Internet Explorer 6 and Internet Explorer 5

    xmlhttp.onreadystatechange = function(data) {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {

            var title = "";
            var authorFirstName = "";
            var authorLastName = "";
            var date = "";

            var parser = new DOMParser();
            var doc = parser.parseFromString(xmlhttp.responseText, "text/html");
            
            // TODO: Look for publish date
            title = doc.getElementsByTagName("title")[0].innerText;
            
            var jsDate = new Date(doc.lastModified); 
            date = String(jsDate.getFullYear()); // January = 0
            
            // No date found NoDate
            if (date === "")
                date = "N.d";

            title = doc.getElementsByTagName("title")[0].innerHTML;


            // Look for author meta tag
            var info = doc.querySelector('meta[name="author"]');

            if (info !== null)
            {
                if (info.content !== "")
                {
                    //var author = info.content.split();

                    // TODO: Split by ' '
                }
            }

            // Look for author class
            var authorClass = doc.getElementsByClassName(".author")[0];

            console.log(authorClass);

            if (authorClass !== undefined)
            {
                authorLastName = authorClass.innerText;
            }

            // Look for author id
            var authorId = doc.getElementById("author");

            if (authorId !== "")
            {
                authorLastName = authorFirstName.innerText;
            }

            // Look for 'a rel'
            var authorAnchor = doc.querySelector('a[rel]');

            console.log(authorAnchor);

            if (authorAnchor !== undefined)
            {
                // TODO: Fix this

                authorLastName = authorAnchor.innerText;
            }

            if (callback)
                callback({"title": title, "author": { "lastName": authorLastName, "firstName": authorFirstName}, "date": date});
        }
    }
    xmlhttp.open("GET", 'https://api.allorigins.win/get?url=' + encodeURIComponent(link), true);
    xmlhttp.send();
}

function OutputSource(source)
{
    // TODO: Remove time from date

    var author = source.lastName === "" && source.firstName === "" ? "" : `${source.lastName}, ${source.firstName.charAt(0)}.`;

    // True = finnish, False = english
    var referredText = source.lang ? "Viitattu" : "Referred";

    // TODO: Fix referral time format
    console.log(source.referred);

    var referralDate = new Date();

    if (source.referred === "")
        referralDate = new Date();
    else
        referralDate = source.referred

    var dd = String(referralDate.getDate()).padStart(2, '0');
    var mm = String(referralDate.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = referralDate.getFullYear();

    switch (document.getElementById("referralDateFormat").value)
    {
        // YYYYMMDD
        case 1:
            referralDate = `${yyyy}.${mm}.${dd}`;
            break;

        // DDYYYYMM
        case 2:
            referralDate = `${dd}.${yyyy}.${mm}`;
            break;

        // MMYYYYDD
        case 3:
            referralDate = `${mm}.${yyyy}.${dd}`;
            break;

        // MMDDYYYY
        case 4:
            referralDate = `${mm}.${dd}.${yyyy}`;
            break;

        // DDMMYYYY
        case 0:
        default:
            referralDate = `${dd}.${mm}.${yyyy}`;
            break;
    }

    console.log(referralDate);

    var source = `${author} ${source.date}. ${source.title}. ${referredText}: ${referralDate}. ${source.link}`;

    var textarea = document.getElementById("textarea");
    textarea.value = source;
    //textarea.value = "Tuomi, S. & Latvala, E. N.d. Opinnäytetyön ohjaajan käsikirja. Jyväskylä: Jyväskylän ammattikorkeakoulu. Viitattu 16.8.2016. https://oppimateriaalit.jamk.fi/yamk-kasikirja/.";
}

function CreateSource()
{
    var link = document.getElementById("link").value;

    if (link === "")
        link = document.getElementById("link").placeholder;

    /*
    Step 1. Who -> Lastname, Firstname's first letter.
    Step 2. When -> Release year, if not known N.d (no date)
    Step 3. What -> Title
    Step 4. Where -> Additional information
    - Optional, Step 5. -> Referal date
    - Optional, Step. 6 -> Link
    */

    // Intercept search with custom values
    var lastName = document.getElementById("lastName").value ?? "";
    var firstName = document.getElementById("firstName").value ?? "";
    var date = document.getElementById("date").value ?? "";
    var title = document.getElementById("title").value ?? "";
    var referred = document.getElementById("referred").value ?? "";

    var lang = document.getElementById("lang").checked;

   GetPageData(link, function(response) {
    OutputSource({
        "lastName": lastName === "" ? response.author.lastName : lastName,
        "firstName": firstName === "" ? response.author.firstName : firstName,
        "date": date === "" ? response.date ?? date.NoDate: date,
        "title": title === "" ? response.title: title,
        "referred": referred,
        "link": link,
        "lang": lang
    });
   });
}

// Copy to clipboard functionality
function Copy()
{
    var copyText = document.getElementById("textarea");

    if (copyText.value === "") { }
        // tooltip.innerHTML = "Nothing to copy!";

    if (copyText.value !== "")
    {
        // Select the text field
        copyText.select();
        copyText.setSelectionRange(0, 99999); // For mobile devices

        // Copy the text inside the text field 
        navigator.clipboard.writeText(copyText.value);

        // tooltip.innerHTML = "Copied: " + copyText.value;
    }
}

function ChangeLanguage()
{
    var value = document.getElementById("lang").checked;
}

function DisableDate()
{
    var use = document.getElementById("useDate").checked;

    var date = document.getElementById("date");
    date.disabled = !use;

    if (use === false)
        date.placeholder = "N.d.";
    else
        date.placeholder = "Date";
}