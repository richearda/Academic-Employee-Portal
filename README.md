# Academic Employee Portal
A web base application for Academic Employees.


# Technologies Used
Frontend
- HTML
- CSS/Bootstrap
- JavaScript/jQuery

Backend
- C#.NET 
- MS SQL Server 
- Entity Framework (EF) Core 
- jQuery Ajax

## User Types
- Teacher
- Dean
- School Admin

# Screenshots
 ## Teacher
 ||||
|:-:|:-:|:-:|
|![Teacher Main](https://i.imgur.com/qPZSKtc.png "Teacher Main")|![Student Masterlist](https://i.imgur.com/iEYoLVV.png "Teacher's subject master list")| ![View Student Info](https://i.imgur.com/wt9HXqy.png "View Student Info")|

## Dean
 ||||
|:-:|:-:|:-:|
|![Dean Main](https://i.imgur.com/Ny8EDz4.png "Dean Main")|![View Teacher Info](https://i.imgur.com/yc02MG4.png "Teacher's Information")| ![Assign Subject](https://i.imgur.com/eBSCFjs.png "Assign Teacher Subject")|

## School Admin
 ||||
|:-:|:-:|:-:|
|![Acad Main](https://i.imgur.com/lwWsg9F.png "Acad Main")|![Add Event](https://i.imgur.com/hlCn8CZ.png "Add Event")| ![Update Event](https://i.imgur.com/rtQPRio.png "Update Event")|

# Run the app on a local machine.
1. Download the project source code.
2. Extract the project folder on your desktop or anywhere you like on your local machine.
3. Open the project folder, you will find two different folders inside the project's folder, the **AEP-API** and **AEP-UI**.
4. Open the **AEP-API** folder, you can find two different folders inside the RegSys-API’s folder, the **DB**, and **API**.
5. Open the DB folder and copy the backup database file.
6. Navigate to **C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\Backup** or **C:\Program Files (x86)\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\Backup** if you have installed a 32-bit version of MS SQL Management Studio.
7. Paste the database file and open your MS SQL Management Studio.
8. Restore the database by locating it in the folder link in step number 6.
9. Once you have successfully restored the database, open the AEP-API solution in the RegSys-API folder.
10. Change the connection string in the **appsettings.json** and **appsettings.Development.json**
11. Once you have already changed the connection string, launch the API to test.
12. Once everything is working fine, open the **AEP-UI** folder and open the project solution.
13. Navigate to **wwwroot** and inside the **js** folder, open the **site.js** file.
14. Inside the **site.js** file, you can find a global variable name **API_URL**, this is the API URL that the UI will be used to call the endpoints using AJAX, you need to change it as exactly as the link of the API that you launch/run in your local machine, or else the UI cannot connect to the database.
15. Once you have changed the API_URL link, launch the project solution and try to log in with the account details below:
### For Teacher ###
**Username:** userasteacher | **Password:** password
### For Dean ###
**Username:** userasdean | **Password:** password
### For School Admin ###
**Username:** userasschooladmin | **Password:** password

## Note ##

If you encountered an error, it might be because you have not followed the instructions carefully or missed some steps. Try to review the steps again.

