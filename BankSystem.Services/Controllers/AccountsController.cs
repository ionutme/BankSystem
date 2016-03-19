using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BankSystem.Services.Models;

namespace BankSystem.Services.Controllers
{
    public class AccountsController : ApiController
    {
        private static readonly List<Account> DbAccounts = InitAccounts();

        [HttpGet]
        public IEnumerable<Account> GetAccounts()
        {
            return DbAccounts;
        }

        public HttpResponseMessage Get(int id)
        {
            if (id < 0 || id > DbAccounts.Count)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, DbAccounts.Single(x => x.id == id));
        }

        public HttpResponseMessage Post([FromBody] Account account)
        {
            HttpResponseMessage response;
            if (ReferenceEquals(null, account))
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                int newlyCreatedAccountId = DbAccounts.IndexOf(account) + 1;
                account.id = newlyCreatedAccountId;
                DbAccounts.Add(account);

                response = Request.CreateResponse(HttpStatusCode.Created);
                response.Headers.Location = new Uri(Request.RequestUri + newlyCreatedAccountId.ToString());
            }

            return response;
        }

        public void Put(int id, [FromBody] Account account)
        {
            DbAccounts[id] = account;
        }

        #region Private Methods

        private static List<Account> InitAccounts()
        {
            return new List<Account>
            {
                new Account {id = 1, name = "Ionut", category = "Personal", balance = 6340.93m},
                new Account {id = 2, name = "Ade", category = "Shopping", balance = 990.5m},
            };
        }

        #endregion
    }
}
