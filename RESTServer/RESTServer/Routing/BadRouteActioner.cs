﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RESTServer.Handlers;

namespace RESTServer.Routing
{
    public class BadRouteActioner : RouteActioner
    {
        RestMethodActioner restMethodActioner = new RestMethodActioner();



        public override async Task<bool> ActionRequest(System.Net.HttpListenerContext context, IEnumerable<IHandler> handlers)
        {
            HttpListenerResponse response = context.Response;
            using (System.IO.Stream output = response.OutputStream)
            {
                var buffer = Encoding.UTF8.GetBytes("Not Found");
                output.Write(buffer, 0, buffer.Length);
                response.StatusCode = 404;
                response.StatusDescription = "Not Found";
            }
            return true;

        }


    }
}