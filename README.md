# CreditWorks
A simple user interface for managing vehicles.


This project is written in C# and targeted for .Net7 and uses simple entity framework to set up the required tables and data.


I have used Fluxor to manage different states within the application. You can find more about Fluxor (Flux/Redux pattern for Blazor) [here](https://github.com/mrpmorris/Fluxor/).


If you come across any other issues, bugs, or you manage to break the app somehow, please get in touch 😊


# Getting started
1. Ensure you have SQL Server installed.
1. Ensure you set ```ConnectionString.Default``` in appsettings.json.
1. Run the ```Update-Database``` command in Package Manager Console to set up the necessary tables and data in your SQL Server Database.
1. If there are any Database issues, add ```TrustServerCertificate=True;``` at the end of your connection string.

# Accessing Package Manager Console
Click on ```Tools > NuGet Package Manager > Package Manager Console ``` in your Visual Studio.

## Use Cases
As a user, I should be able to:
1. Create new vehicles and edit their details
2. Update existing vehicles
3. View vehicles list
4. Sort vehicles by their owner, year, manufacturer, and category
5. Create, change, and delete Categories
6. Set an icon for each category
7. See the new icon in the vehicle list
