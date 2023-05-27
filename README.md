# Sample_DotNetCore_WebAPI
[Technology used .NET Core 5 / Entity Framework Core]
I was follow below steps for creating this project.

Step 1 : On creating application visual studio UI shows different application template option in that we have to select 'ASP NET Core Web API' in Visual Studio 	 2019.
Step 2: Register API Controller Service- In the 'Startup.cs' file we have to register the 'AddController' service.
        ![image](https://github.com/sayantan2017/Sample_DotNetCore_WebAPI/assets/26603086/3d9012fa-4ff7-4896-aa73-cd5e5483a33e)
Step 3: Install Swagger from Nuget package manager , Below are list of the Swagger libraries which is required (The Swagger is an API Documentation Tool used to 	  test the endpoints.)
        There are three main components of Swashbuckle.
        Swashbuckle.AspNetCore.Swagger
        Swashbuckle.AspNetCore.SwaggerGen
        Swashbuckle.AspNetCore.SwaggerUI
        
 Step 4: Register Swagger Service
         ![image](https://github.com/sayantan2017/Sample_DotNetCore_WebAPI/assets/26603086/86af5f7d-42ec-475f-b1f0-9f90f1c73d96)
         
 Step 5: Register Swagger Middleware
         ![image](https://github.com/sayantan2017/Sample_DotNetCore_WebAPI/assets/26603086/41799af2-b254-4077-b0d9-1b2302383418)
 Step 6:  Install EF Core Nuget
          ![image](https://github.com/sayantan2017/Sample_DotNetCore_WebAPI/assets/26603086/f86b565a-88fe-43a6-ac97-4cfa12bb153c)
 Step 7 : Create a table in MS SQL Server database , Use below query
          CREATE TABLE [dbo].[Gadgets](
	                    [Id] [int] IDENTITY(1,1) NOT NULL,
	                    [ProductName] [varchar](max) NULL,
                    	[Brand] [varchar](max) NULL,
                    	[Cost] [decimal](18, 0) NOT NULL,
                    	[ImageName] [varchar](1024) NULL,
                    	[Type] [varchar](128) NULL,
                    	[CreatedDate] [datetime] NULL,
                    	[ModifiedDate] [datetime] NULL,
                      PRIMARY KEY CLUSTERED 
                        (
                        	[Id] ASC
                            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                          ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
                          
   Step 8 : Setup Entity Framework Core DbContext:
            First, let's create POCO class that represents our table. So let's create a new folder 'Data', inside of it create one more folder like 'Entities'.               Inside of the 'Entities' folder creates our POCO class.
            Data/Entities/Gadgets.cs:
            ![image](https://github.com/sayantan2017/Sample_DotNetCore_WebAPI/assets/26603086/048b5897-a814-4660-baf8-075b9f875ca2)

   Step 9: In EF Core DbContext is like a database that manages all POCO classes(classes represent tables). Inside the 'Data' folder create a context class.
            Data/Project_DBContext.cs:
            ![image](https://github.com/sayantan2017/Sample_DotNetCore_WebAPI/assets/26603086/c5925832-ecc9-4185-b17e-a906893fa566)
            
   Step 10 : Add database connection string into 'appsetting.Development.json'.
            appsetings.Development.json:
            "ConnectionStrings":{
                   "ProjectDbConnection":"your_connection"
             }
             
   Step 11: Register 'MyWorlDbContext' into the dependency services.
            ![image](https://github.com/sayantan2017/Sample_DotNetCore_WebAPI/assets/26603086/500bfdb5-bf20-4ace-b7e5-0fe13df8fd28)

   Step 12: Create A Sample Controller:
          In Web API Controller is entry point of the request. So controller will have methods called actions, these action executed per request based on the               route.
          Controllers/GagetsController.cs:
          ![image](https://github.com/sayantan2017/Sample_DotNetCore_WebAPI/assets/26603086/0745e026-a815-4e02-9179-4df1712b285a)
          Decorated with 'ApiController' attribute indicates that a type and all derived types are used to serve HTTP API responses. Controller                             decorated with this attribute are configured wth features and behavior target at improving the developer experience for building APIs.
           Route to define our URL. The default expression '[Controller]' means name of the controller means 'Gadgets'. You can define your custom route                       name if you wanted.
            Our c# class to become a controller it need to inherit 'Microsoft.AspNetCore.Mvc.ControllerBase'.
           (Line[23-27]) Injected our DbContext into the controller.
           
   Step 13 : Refer GagetsController.cs , for crud operations.


         

         
