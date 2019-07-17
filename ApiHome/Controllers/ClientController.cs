using ApiHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ApiHome.Controllers
{
    public class ClientController : ApiController
    {
        public Dictionary<int, Client> clients = new Dictionary<int, Client>
            {
                {1,  new Client { Id = 1, FirstName = "TestFirst1" , LastName = "TestLast1", Card = new Card{ CardId = 111 , OwnerId = 1, CardBalance = 1000 } } },
                {2,  new Client { Id = 2, FirstName = "TestFirst2" , LastName = "TestLast2", Card = new Card{ CardId = 222 , OwnerId = 2, CardBalance = 2000 } } },
                {3,  new Client { Id = 3, FirstName = "TestFirst3" , LastName = "TestLast3", Card = new Card{ CardId = 333 , OwnerId = 3, CardBalance = 3000 } } },
                {4,  new Client { Id = 4, FirstName = "TestFirst4" , LastName = "TestLast4", Card = new Card{ CardId = 444 , OwnerId = 4, CardBalance = 4000 } } },
                {5,  new Client { Id = 5, FirstName = "TestFirst5" , LastName = "TestLast5", Card = new Card{ CardId = 555 , OwnerId = 5, CardBalance = 5000 } } }
            };

        [HttpGet]
        public Dictionary<int, Client> Client()
        {
            return clients;
        }

        [HttpGet]
        public Client Client(int id)
        {
            if (clients.TryGetValue(id, out var client))
            {
                return client;
            }
            throw new HttpException(404, "Not found");
        }
        [HttpPost]
        public IHttpActionResult Client(Client data)
        {
            if (data != null)
            {
                var newClientId = clients.Count() + 1;// создаем примитивно "уникальный" ID для новой записи
                clients.Add(newClientId, new Client { Id = newClientId, FirstName = data.FirstName, LastName = data.LastName, Card = new Card { CardBalance = data.Card.CardBalance, OwnerId = newClientId } });
                return Ok();
            }
            throw new HttpException(404, "Not found");
        }

        [HttpDelete]
        [ActionName("Client")]
        public IHttpActionResult Client_1(int id)
        {
            if (clients.Remove(id))
            {
                return null;
            }
            throw new HttpException(404, "Not found");

        }
    }
}
