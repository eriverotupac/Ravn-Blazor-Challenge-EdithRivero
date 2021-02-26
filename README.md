# Ravn Challenge

## Description

This project was developed for training proposes with Blazor in the web platform. It is possible to get and show the information of people registered in Star Wars API(SWAPI).

## Setup and running instrucions
## Requirements
.Net Blazor SKD: 5.0
Visual Studio Version 16.8.6 (if want to be the code in kindly way)
## Running in local machine
1. Clone the code
2. Open Command Prompt (cmd) and type the following:  **dotnet run 'here goes the complete path of project code'**
3. Open a browser and type localhost and the port that shows in the cmd.

## Assumptions
1. When I saw how the SWAPI was returning the data and how the screens were designed, I decided to get all the required information in the same call. Let me explain:
In the first screen it was required to show the name, the specie and the planet of people. Then if the name is clicked, it has to be shown detailed information of people including the vehicles it has. 
So, in the fisrt call, I got all the detailed information and when the name is clicked only show this information instead of calling again the SWAPI.
This desicion was made because the information is few, but maybe in other scenarios, I will call API to get the detailed information.
2. The number of the species could be one or more, so I take the first one.
3. The specie was considered *human* when gender was male or female. 

## Technologies used
AspNetCore.Blazor.Httpclient package: For obtaining the response in the json format.

## Additional information
- I was about to install the awesome font, because the arrow in the OpenIconic is a bit width than the mockup, but later I decided to used the OpenIconic because I read in the css details: "Use platform default indicator". 

## Some difficulties:
- I did not finish to design the error page.
- To be honest, the frontend code is a bit challenge that backend. So, I was stucked in making the list of people.
- The other thing that made me search a lot on the internet, was how to handle the pagination. I first tried *Virtualization*, but it did not work as was wantted. Then, I tried  *ItemsProviderResult* and I realized that it took so much time. So, I decided to add a button to get the data. I know this is not the functionaly expected, but I prefer to let it working.

## Happiness
I really enjoyed doing this!

## Screenshots of working in application
![alt text](https://github.com/eriverotupac/Ravn-Blazor-Challenge-EdithRivero/blob/master/RavnChallenge/wwwroot/screenshots/sc01.JPG?raw=true)
![alt text](https://github.com/eriverotupac/Ravn-Blazor-Challenge-EdithRivero/blob/master/RavnChallenge/wwwroot/screenshots/sc02.JPG?raw=true)
![alt text](https://github.com/eriverotupac/Ravn-Blazor-Challenge-EdithRivero/blob/master/RavnChallenge/wwwroot/screenshots/sc03.JPG?raw=true)
![alt text](https://github.com/eriverotupac/Ravn-Blazor-Challenge-EdithRivero/blob/master/RavnChallenge/wwwroot/screenshots/sc04.JPG?raw=true)
![alt text](https://github.com/eriverotupac/Ravn-Blazor-Challenge-EdithRivero/blob/master/RavnChallenge/wwwroot/screenshots/sc05.JPG?raw=true)
![alt text](https://github.com/eriverotupac/Ravn-Blazor-Challenge-EdithRivero/blob/master/RavnChallenge/wwwroot/screenshots/sc06.JPG?raw=true)
![alt text](https://github.com/eriverotupac/Ravn-Blazor-Challenge-EdithRivero/blob/master/RavnChallenge/wwwroot/screenshots/sc07.JPG?raw=true)
![alt text](https://github.com/eriverotupac/Ravn-Blazor-Challenge-EdithRivero/blob/master/RavnChallenge/wwwroot/screenshots/sc08.JPG?raw=true)
![alt text](https://github.com/eriverotupac/Ravn-Blazor-Challenge-EdithRivero/blob/master/RavnChallenge/wwwroot/screenshots/sc09.JPG?raw=true)
![alt text](https://github.com/eriverotupac/Ravn-Blazor-Challenge-EdithRivero/blob/master/RavnChallenge/wwwroot/screenshots/sc10.JPG?raw=true)
![alt text](https://github.com/eriverotupac/Ravn-Blazor-Challenge-EdithRivero/blob/master/RavnChallenge/wwwroot/screenshots/sc11.JPG?raw=true)
![alt text](https://github.com/eriverotupac/Ravn-Blazor-Challenge-EdithRivero/blob/master/RavnChallenge/wwwroot/screenshots/sc12.JPG?raw=true)

