# ComicsWebsite
Website for Group Project of CPSC 471 Winter 2022

ComicsAPI:
This Folder is for modifiying and executing the API that will be communicating with the databse for our website (to be included)
HomeController has been removed from this folder as it caused conflicts when running the website, so will see an error instead of a home page when running API (will try to fix if I have the time?)

ComicsSite:
This Folder is for modifiying and executing the Website (frontend) that will be displayed to users.

	Controllers folder is for handling what is shown when a page is navigated to (afaik)
	Images folder is where images will be stored to be used in program
	Styles folder is where stylesheets (css) files are being stored
	Views folder is where .cshtml for webpages are stored
	Models is the (currently empty) folder where c# classes for handling of our relations (i.e. user,admin,comic,community,etc.) will go. Will communicate with API to get info from database and then do whatever it needs to.

I have been mostly using Visual Studio to run these, but if required I can try to see how to run them via command-line so that modifiying with desired IDE/Editor is easier.

ComicsDB:
This folder is for creating and publishing the database to a server (I used the local server created by visual studio, but can create one with sql server and link it to that instead most likely?)
	
   Use LocalComicsDB, ComicsDB was used when I ended up creating a sql server to link. Since I am attempting to use the visual studio local server now to make collaboration simpler, ComicsDB is unnecessary (will most likely delete and rename LocalComicsDB to ComicsDB at a later point)
	
   To ensure that the connection Strings in the API project are valid, probably best to create your database in the server (localdb)\ProjectsV13 with the name ComicsDB, or else you might have to change connection Strings to match your setup
