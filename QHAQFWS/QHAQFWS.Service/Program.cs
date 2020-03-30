﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace QHAQFWS.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<QHAQFWSService>();
                x.RunAsLocalSystem();
                x.SetDescription(ConfigurationManager.AppSettings["Description"]);
                x.SetDisplayName(ConfigurationManager.AppSettings["DisplayName"]);
                x.SetServiceName(ConfigurationManager.AppSettings["ServiceName"]);
                x.StartAutomatically();
            });
        }
    }
}
