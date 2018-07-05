# Telemetry
An sample repository to showcase usage of GraphQL in ASP.NET CORE WEB API

In order to run the project follow the below mentioned steps

1. Set Telemetry.DAL as startup project in visual studio.
2. Go to file TemporaryDbContextFactory and replace the connection string as per your SQL server.
3. Navigae in command prompt to the Telemetry.DAl folder and Run "dotnet ef database update".
4. This should have created the Database and added the required tables in SQL Server.
5. Now set Telemetry.API as startup project.
6. Go to appsettings.Development.JSON and replace the ConnectionStrings:TeleMetry to the same connection string given in step 2.
7. press ctrl-F5.
8. Broser must open the page http://localhost:49771/GraphQL/

Below is the sample request you can create in the GraphQL

query DeviceQuery($id:Int!)
{
   deviceById(id:$id){
   deviceId,
   deviceName,
   description,
   createdBy,
   createdOn,
   updatedBy
   },
  
  allDevices {
    deviceId
  }
}

Under the QUERY VARIABlES set below
{
  "id":<<SOME_VALID_ID>>
}
