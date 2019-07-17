using ApiHome.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ApiHome.Controllers
{
    public class CardController : ApiController
    {
        List<Card> cards = new List<Card>() {
            new Card { CardId = 1, CardBalance = 1000, OwnerId = 1 },
            new Card { CardId = 2, CardBalance = 2000, OwnerId = 2 }
        };
        List<Client> clients = new List<Client>() { new Client { Id = 1, FirstName = "Test1", LastName = "test2", Card = new Card { CardId = 555, OwnerId = 1, CardBalance = 5000 } } };

        
        [HttpGet, Route("client/card")]
        public IEnumerable<Card> Card()
        {
            return cards;
        }

        [HttpGet, Route("client/{clientId:int}/card/{cardId:int}")]
        public Card Card(int cardId, int clientId)
        {
            var client = clients.FirstOrDefault(x => x.Id == clientId);
            if (client != null && client.Card.CardId == cardId) return client.Card;
            throw new HttpException(404, "Not found");
        }

        [HttpPost, Route("client/{clientId:int}/card")]
        public List<Card> Card(Card data,int clientId)
        {
            var client = clients.FirstOrDefault(x => x.Id == clientId);
            if (client != null && data != null)
            {
                client.Card = new Card
                {
                    CardBalance = data.CardBalance,
                    OwnerId = client.Id,
                    CardId = data.CardId
                };
                return cards;
            }
            throw new HttpException(404, "Not found");
        }

        [HttpDelete, Route("client/card/{cardId:int}")]
        [ActionName("Card")]
        public void Card_1(int cardId)
        {
            if (cards.Remove(cards.FirstOrDefault(_ => _.CardId == cardId)));
        }
    }
}
