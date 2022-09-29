using OpenAPIDemo.Models;
using Microsoft.AspNetCore.Mvc;
using OpenAPIDemo.Attributes;

namespace OpenAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class SubscriptionController : ControllerBase
    {
        internal List<SubscriptionData> _items = new List<SubscriptionData>();
        public SubscriptionController() {
            _items.Add(new SubscriptionData() { SubscriptionName = "Item 1", IsSubscribed = false });
            _items.Add(new SubscriptionData() { SubscriptionName = "Item 2", IsSubscribed = false });
            _items.Add(new SubscriptionData() { SubscriptionName = "Item 3", IsSubscribed = false });
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<SubscriptionData> Get()
        {
            return _items;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public SubscriptionData Get(string id)
        {
            return _items.FirstOrDefault(i => i.Id == id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post(SubscriptionData subscriptionData)
        {
            _items.Add(subscriptionData);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] SubscriptionData subscriptionData)
        {
            SubscriptionData subscriptionDataToUpdate = _items.First(i => i.Id == id);
            if (subscriptionDataToUpdate != null) {
                subscriptionDataToUpdate.IsSubscribed = subscriptionData.IsSubscribed;
                subscriptionDataToUpdate.SubscriptionName = subscriptionData.SubscriptionName;
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            SubscriptionData subscriptionDataToRemove = _items.First(i => i.Id == id);
            if (subscriptionDataToRemove != null)
            {
                _items.Remove(subscriptionDataToRemove);
            }
        }
    }
}