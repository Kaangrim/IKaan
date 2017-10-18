using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

namespace IKaan.Web.Service.Services
{
    public class Repository : IDisposable
    {
        public Repository()
        {

        }

        private AccountService _account;

        public AccountService Account
        {
            get
            {

                if (this._account == null)
                {
                    this._account = new AccountService();
                }
                return _account;
            }
        }


        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {

                }
            }
            this._disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
        }
    }
}