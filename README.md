# Disney Dreamlight Valley Tracker App
This site will function as a paired down wiki and collection tracker for the game [Disney Dreamlight Valley](https://disneydreamlightvalley.com) The goal is to make a companion site to streamline gameplay and to offer more features and user friendly navigation than in-game.

## Getting started
- [VS2022](https://visualstudio.microsoft.com/)
- ASP.NET and web development workload
- .NET 8 (Included in VS2022)

## Create the database and insert test data
- Run update-database in the DDVTracker project, some starter seed data is located in the Data/DreamlightDbContext file
- Run the website to create the default roles and Master admin login

## Admin Credentials
- To log in as the Master admin, the username is **master** and the password is **P@ssword1**

## Roles
- New registered users will be added to the User role, promotions to other levels are a work in progress.
- All users will be able to view general information, but registered users will be able to mark off collected items and update progress they wish to track.
  
### General user
![Screenshot 2024-05-13 071242](https://github.com/FeelinProggy/DDVTracker/assets/147089624/7936e97a-42a1-477b-839d-1e731d442d7e)  

### Registered user
![Screenshot 2024-05-13 071233](https://github.com/FeelinProggy/DDVTracker/assets/147089624/c8b57568-f7d2-4901-8d09-23a9dd02507c)  

### Elevated user
![Screenshot 2024-05-13 071308](https://github.com/FeelinProggy/DDVTracker/assets/147089624/325895b8-b217-40d5-ade8-ac1116d37968)

### Images
 - Sample images are located in the wwwroot folder id you'd like to test creating/editing objects

Images below are from the game's collections tab. 
![in game collections tab](https://github.com/FeelinProggy/DDVTracker/assets/147089624/58ceea4f-fc72-4a7c-9c86-127bb81d50ad)

![in game characters tab](https://github.com/FeelinProggy/DDVTracker/assets/147089624/cfd152a9-ef2d-4640-b8dc-267d22730f78)

![in game meals tab](https://github.com/FeelinProggy/DDVTracker/assets/147089624/6f5ef653-49a6-4f7b-87a8-5adfa13ae948)

