# ITCourses

This web application created with ASP.NET MVC5 using EntityFramework 6.0.

The project has the initializer for the database, so to set it up, you just need to start the solution. The initializer works every time you start the solution. If you dont want it you should make the following change in the DAL/StationInitializer.cs: replace the "public class StationInitializer : System.Data.Entity.DropCreateDatabaseAlways" with "public class StationInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges"

Short app description:

This is the service station administration application. You can search for existing clients using the search boxes on the "Clients" page. Or you can create a brand wen client. For each client is avalable to edit and delete it, if there is no cars attached to it. Also you can see and edit the list of cars for each client. For each client is avalable to edit and delete it, if there is no orders attached to it. You also can create, edit and delete orders. Note: you can see the date fields while creating client or order. In this application US date format is used: MM/DD/YYY.
