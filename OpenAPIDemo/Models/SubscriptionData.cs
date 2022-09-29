namespace OpenAPIDemo.Models
{
    public class SubscriptionData
    {
        public string Id { get; set; }
        public string SubscriptionName { get; set; }
        public bool IsSubscribed {get;set;}

        public SubscriptionData()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}