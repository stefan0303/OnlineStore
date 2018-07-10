using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.Owin;
using OnlineStore.Controllers;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineStore.Startup))]
namespace OnlineStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }

  
}
