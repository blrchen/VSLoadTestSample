using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Http;

namespace Web.Controllers
{
    [RoutePrefix("api/test")]
    public class LoadController : ApiController
    {
        [HttpGet]
        [Route("ip")]
        public string ServerIp()
        {
            string result = string.Empty;
            NetworkInterface[] nets = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var net in nets)
            {
                if (net.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    var ipProperties = net.GetIPProperties();
                    if (ipProperties.UnicastAddresses.Count > 0)
                    {
                        foreach (var address in ipProperties.UnicastAddresses)
                        {
                            result += address.Address + Environment.NewLine;
                        }
                    }
                }
            }
            return result;
        }

        [HttpGet]
        [Route("get")]
        public IHttpActionResult TestGet(string foo, string bar)
        {
            return Ok(foo + bar);
        }

        [HttpPost]
        [Route("post")]
        public IHttpActionResult TestPost(string foo, string bar)
        {
            return Ok(foo + bar);
        }
    }
}