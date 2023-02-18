function UseManualMode(manualModeCheckbox)
{
    var manual = document.getElementById("manual-input");

    if (manualModeCheckbox.checked == true)
        manual.style.display = "block";

    if (manualModeCheckbox.checked == false)
        manual.style.display = "none";
}

function TitleChanged()
{
    // TODO: Change output source text from custom input
}

function AuthorFirstNameChanged()
{
    // TODO: Change output source text from custom input
}

function AuthorLastNameChanged()
{
    // TODO: Change output source text from custom input
}

function IsReleaseDateKnown()
{
    var use = document.getElementById("useDate").checked;

    var date = document.getElementById("date");
    date.disabled = !use;

    if (use === false)
        date.placeholder = "N.d.";
    else
        date.placeholder = "Date";
}

function ReleaseDateChanged()
{
    // TODO: Change output source text from custom input
}

function ReferralDateChanged()
{
    // TODO: Change output source text from custom input
}

function ChangeLanguage()
{
    // TODO: Change the language of all visible text

    // TODO: Change the language of the output source.
}