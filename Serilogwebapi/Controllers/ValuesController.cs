using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Serilogwebapi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        
        {
            //Log.Logger = new LoggerConfiguration()
            //    //.WriteTo.File("c:\\test.txt", rollingInterval: RollingInterval.Day)
            //    .WriteTo.EventLog()                                                                                                     
            //    .CreateLogger();

            String logTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u}] [{SourceContext}] {Message}{NewLine}{Exception}";

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(@"C:\mylog.txt",outputTemplate:logTemplate,shared:true)
    .WriteTo.EventLog("Wep API", manageEventSource: true)
    .CreateLogger();

            Log.Information("Hello, Windows Event Log!");
            Log.Error("This is information");
            Log.ForContext("SourceContext", "ValuesController.Get()").Information("End");

            Log.CloseAndFlush();

            
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
