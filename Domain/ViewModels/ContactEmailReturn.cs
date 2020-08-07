using VirtualMarketPlace.ViewModels;

namespace VirtualMarketPlace.Models
{
    public class ContactEmailReturn
    {
        public bool IsMessageSent { get; set; }
        public bool HasException { get; set; }
        public string ReturnMessage { get; set; }
        public ContactViewModel Contact { get; set; }
    }
}
