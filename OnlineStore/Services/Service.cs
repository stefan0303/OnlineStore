using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineStore.Data;

namespace OnlineStore.Services
{
    public class Service
    {
        private OnlineStoreContext context;

        public Service()
        {
            this.context = new OnlineStoreContext();
        }

        protected OnlineStoreContext Context => this.context;
    }
}