Thanks for looking into my project. This project was built using Asp.Net Core 6 with Web
API, Rest API, as a Monolite. 

I divided my project into different layers:
1) application layer (which
includes controllers, wwwroot for static files, and middlewares)
2) Service layer for business logic, 
3) Repository for connecting to the database Entity Framework Core 6  as then ORM with a DB-first approach.
4) DTO for transferring data to the client using Auto Mapper.


I gave special attention to scaling the site by using async/await and implementing browser caching.

Error handling is taken care of by logging with NLOG. All errors should be caught using a middleware for that.
Configuration file (appsettings.json) for environment variables.
I added a rating middleware to record all site entries. 
The code was written following the "Clean Code" guide.
Thank you for checking out my project!
