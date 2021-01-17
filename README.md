# Azure Function Hash Sample
- Sample project calls Azure Function from API.
- Azure Function takes string as paramter and returns MD5 hashed string.
- Generic function client implemented. Reads from appsettings.json and use as dictionary. Appsettings key and function client class name should be same.
- I implemented unit test for Azure Function.

Api Url: https://recruitmentapi20210117153645.azurewebsites.net/api/hash  
Api Test: Send a post request { "login":"serhat", "password":"pwd" }

Function URL: https://sthash.azurewebsites.net/api/hashfunction  
Function Test: https://sthash.azurewebsites.net/api/hashfunction/serhat+pwd
