# TicketZone
### by Maks Matkov

## What is this?

This my coursework project. Main theme is terminal of free cinema tickets; 

It include backend on .net5 core and client application on Angular framework;

**This .net core 5 API and Angular CLient that include all of my main knowledge at this period!**

BACKEND:
- RESTFUL API
- Dependency injection
- Clear Architecture
- JWT Authentication
- Migrations
- Using stored 
- Connect to SQLite and MSSQL
- Entity Framework Core
- Models Configurations
- And More...

FRONTEND:
- Styles with angular material and scss
- Restful and guarded routings
- JWT token Authentication
- Interceptors for loading visualization
- Globally error catchings 
- Authentication with ROLES
- Animations
- And More...

> start a special :grin:
>
> APPLICATION VIEW
>
> <sup>Main Page</sup>
> ![Main Page](/assets/images/main.png)
>
> <sup>Admin Panel</sup>
> ![Main Page](/assets/images/adminpanel.png)
>
> <sup>Users Orders View</sup>
> ![Main Page](/assets/images/userordersview.png)
> end
> 

 ## **Application Deployment**
 <sup>how deploy this web app and api?</sup>

### **Additional software is required:**
1. Node.js [download](https://nodejs.org/en/download/);
2. Instal Angular using command ```npm install -g @angular/cli```;
3. Visual Studio 2019 or higher [download](https://visualstudio.microsoft.com/downloads/);

### **Up API:**
1. Open "\API\TiketsTerminal.API\TiketsTerminal.API.sln";
2. Build Project;
3. In **appsettings.json** choose type of db and input connection strings: SqlLite or MSSql ('DbType' filed 0 = 'msSQL', 1 = 'sqlLite');
4. Open **Package Manager Console** for **Infrastructure Project** and call **```update-database```** command; 
5. Open the Publishing for API project and select the appropriate option of deployment: Docker Container, IIS, Azure or other;

### **Up Angular Client:**
1. In main folder call command ```npm install```;
2. In main folder call command ```ng build```;
3. After you will receive folder with index.html and js files;
4. You can deploy this locally on IIS, Docker Container, node.js, nginx server no meter;  

## **Questions and Answers**
<sup>answers for some questions?</sup>

### **I can connect to api due to CORS Policy. How fix?**
You need locate both APIs and clients files on **the same host**;

### **I haven`t admin account?**
You have default admin account

- email: **admin@admin.com**;
- password: **adminadmin**

# **That`s all! Rate this if you want)**