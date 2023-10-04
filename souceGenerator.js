document.onload = function()
{
    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    const lang = urlParams.get('lang')

    // TODO: Update lang check box

    document.getElementById("lang").checked = lang === "fi" ? true : false;
}

function Load()
{
    // TODO: link to actual source generation

    // Activate the overlay
    var overlay = document.getElementById("overlay");
    overlay.style.display = "flex";

    // TODO: This is temporary functionality to test the failing case

    // Add a timer to simulate loading
    setTimeout(() => {
        overlay.style.display = "none";

        // TODO: Show error only if source generation fails.  
        var error = document.getElementById("error");
        error.style.display = "block";

        var manualModeCheckbox = document.getElementById("manual-mode");
        manualModeCheckbox.checked = true;

        var manual = document.getElementById("manual-input-container");
        manual.style.display = "block";

    }, "1000")
      
}

function GetPageData(link, callback)
{
    if (!callback)
        return; // TODO: Handle gracefully

    // Initialize the http client based on browser.
    var xmlhttp = window.XMLHttpRequest ?
        new XMLHttpRequest() :                  // Code for Internet Explorer 7+, Firefox, Chrome, Opera, and Safari
        new ActiveXObject("Microsoft.XMLHTTP"); // Code for Internet Explorer 6 and Internet Explorer 5

    xmlhttp.onreadystatechange = function(data) {

        // Handle success status
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
            var date = "";

            var parser = new DOMParser();
            var doc = parser.parseFromString(xmlhttp.responseText, "text/html");
         
            // TODO: Link to functions retrieving data.
            callback({
                "title": title, 
                "author": {},
                 "date": date
                });
        }

        // TODO: Handle fail status
    }

    // Send the request
    // NOTE: We are sending the request through allorigins.win's proxy server to avoid CORS errors.
    xmlhttp.open("GET", 'https://api.allorigins.win/get?url=' + encodeURIComponent(link), true);
    xmlhttp.send();
}
function GetTitle()
{
    // TODO: Look for publish date
    return doc.getElementsByTagName("title")[0].innerText;
}

function GetAuthor()
{
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

    return {
        "lastName": authorLastName, 
        "firstName": authorFirstName
    };
}

function GetDate()
{
    var jsDate = new Date(doc.lastModified); 
    date = String(jsDate.getFullYear()); // January = 0
    
    // No date found NoDate
    if (date === "")
        date = "N.d";
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
    // Find the user link
    var link = document.getElementById("link").value;

    // TODO: Show error if the link was not provided.
    if (link === "") { }

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

    // Get the page data
    GetPageData(link, function(response) {

        // Send the retrieved data to the output text area
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

// "Copy to clipboard" functionality
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