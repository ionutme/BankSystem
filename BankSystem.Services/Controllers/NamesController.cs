using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BankSystem.Services.Controllers
{
    public class NamesController : ApiController
    {
        private static readonly List<string> DbNames = InitNames();

        [HttpGet]
        public IEnumerable<string> GetNames()
        {
            return DbNames;
        }

        // GET api/accounts
        /*public IEnumerable<string> Get()
        {
            return DbAccounts;
        }*/

        // GET api/accounts/1
        public HttpResponseMessage Get(int id)
        {
            if (id > DbNames.Count)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, DbNames[id]);
        }

        // POST api/accounts
        public HttpResponseMessage Post([FromBody]string account)
        {
            DbNames.Add(account);

            int newlyCreatedAccountId = DbNames.IndexOf(account);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri + newlyCreatedAccountId.ToString());

            return response;
        }

        // PUT api/accounts
        public void Put(int id, [FromBody]string account)
        {
            DbNames[id] = account;
        }

        // DELETE api/accounts/id
        public void Delete(int id)
        {
            DbNames.RemoveAt(id);
        }

        private static List<string> InitNames()
        {
            return new List<string> { "Mihai", "Dani" };
        }
    }
}
