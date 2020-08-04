namespace VirtualMarketPlace.Models
{
    public class ContactEmailReturn 
    {
        public bool IsMessageSent { get; set; }
        public bool HasException { get; set; }
        public string ReturnMessage { get; set; }
        public Contact Contact { get; set; }
    }
}
