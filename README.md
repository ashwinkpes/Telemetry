# Telemetry
An sample repository to showcase usage of GraphQL in ASP.NET CORE WEB API

In order to run the project follow the below mentioned steps

1. Set <b>Telemetry.DAL</b> as startup project in visual studio.
2. Go to file <b>TemporaryDbContextFactory</b> and replace the connection string as per your SQL server.  
     2.1 optionsBuilder.UseSqlServer("<<YOUR_SQL_SERVER>>");
3. Navigate in command prompt to the Telemetry.DAl folder and Run <b>"dotnet ef database update"</b>.
4. This should have created the Database and added the required tables in SQL Server.
5. Now set <b>Telemetry.API</b> as startup project.
6. Go to appsettings.Development.JSON and replace the ConnectionStrings:TeleMetry to the same connection string given in step 2.
7. Download and run Serilog-SEQ from https://getseq.net/Download 
8. press ctrl-F5.
9. Browser must open the page http://localhost:49771/GraphQL/

Sample queries
=================
1) To get a specific device with a given device id
```
query TelemetryQuery($id:Int!)
{
   deviceQuery {
   deviceById(id:$id)
    {
      deviceName
    }
  }
}

Under query variables
{
  "id" : 152
}
```
2) To get all devices
```
query TelemetryQuery
{
   deviceQuery {
    allDevices {
      deviceId,
      deviceName
    }
  }
}
```
3) To add a device
```
mutation ($CreateDeviceType:InputCreateDevice!)
{
  deviceMutation{
       addDevice(CreateDeviceType: $CreateDeviceType){
    deviceId
    deviceName
  }

  }

}

Under query variables

{
  "CreateDeviceType":{
    "deviceName":  "TestDevice",
     "description":   "TestDescription"
  }
}
```
