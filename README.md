# Sourcefier

Can't remember the format in which a source item needs to be? We've got you covered!

## Introduction

Input a link to output a source element.

NOTE: Unfortunately, not all developers add the information to their sites we require. 

## Contributing
If you wish to contribute to the project, please create a feature branch. For this functionality you write, create an issue (if not open already) and assign yourself. Now take the id of the issue as the starting name of the branch.
Example:
1234-fix-typo

Once your fix is complete. Please create a pull request to the main branch.

## Detecting the parts of the source

**NOTE: Not all sites contain all the required information, such as the author or the release date so remember to check the output source validity.**

### Author:  
```html
<meta name="author" content="John Doe>
```

### Release Date:  
If the release date is not known we simply use N.d. (No date).

### Referral Date:
The date 

#### Time format of the reffal:  
The default date format is 

Source item structure documentation (in Finnish):  
https://oppimateriaalit.jamk.fi/raportointiohje/files/2020/09/Pikaohje-2020.pdf

## Further documentation

#### Web scraping
The whole app is based on web scraping to read the necessary information from the pages. 

Sourcefier will scan the page HTTP headers, html head and meta tags and more to determine the required values for a valid source reference.

### Retrieving the page contents
AJAX Http Requests to retrieve the web page structure.
https://developer.mozilla.org/en-US/docs/Web/API/XMLHttpRequest 

### All Origins
https://allorigins.win/
https://github.com/gnuns/allorigins
