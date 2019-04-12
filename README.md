## Rental Portal
# Developer Home Assignment 
The Project Consist of two well structured microservice backend project and a frontend web application<br><br>
The Microservice backend consists of :<br><br>
<b>A User Identity .Net Core API</b> : which registers and validates user login credential as well as generating an auth token[COMPLETED] <br><br>
<b>An Order .Net Core API </b> : which handles Equipment,ShoppingCart and Orders[COMPLETED] <br><br>
 The Frontend Consist of a :<br><br>
 <b>.Net Core Web Application</b> which sends requests to the microservices endpoints.[NOT COMPLETE]<br><br>
 # To run the application

	1.The 3 projects should be set as startup projects
	2.The Database for the two microservices should be initialized
	3.connection string should be updated in the appsettings configuration file
	4.a user may be created and auth token generated for by sending post requests to "api/accounts/register" and "api/auth/login" respectively
	5.the equipment table in the order microservice db should be seeded with sample data. seedDB.sql in the repo root could be used for this.
	
# the microservice implementation approach is necessary in other to make scaling up/out of sets of related features(individual microservice projects) easier and faster; based on the amount of user request being served. unlike a monolithic approach where the entire system would have to be scaled out/up.

 
 

