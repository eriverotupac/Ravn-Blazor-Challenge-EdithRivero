Ravn Challenge

Description

This project was developed for training proposes with Blazor in the web platform. Then, it is possible to get and show the information of people registered in Star Wars API(SWAPI).

Requirements
.Net Blazor SKD: 5.0

Setup and running instrucions

1. Clone the code
2. Open Command Prompt and type the following
dotnet run 'here goes the complete path of project'
3. Open a browser (preference Chrome)

Assumptions

1. When I saw how the SWAPI was returning the data and how the screens were designed, I decided to get all the required information in the same call. Let me explain:
In the first screen it was required to show the name, the specie and the planet of people. Then if the name is clicked, it has to be shown detailed information of people including the vehicles it has. 
So, in the fisrt call, I got all the detailed information and when the name is clicked only show this information instead of calling again the SWAPI.
This desicion was made because the information is few, but maybe in other scenarios, I will call API to get the detailed information.

2. 

Additional information
I have to donwload the httpclient balzor package for obtaining the answers in the json format.
I was about to install the awesome font, because the arrow in the OpenIconic is a bit width than the mockup, but later I decided to used the OpenIconic because I read in the css details: "Use platform default indicator". 


Some difficulties:
To be honest, the frontend code is a bit challenge that backend. So, I was stucked in making the list of people.

Upgrading my version (3.1) of vs because for doing pagination I used virtualization.

