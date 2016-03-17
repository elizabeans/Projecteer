using Projecteer.Core.Models;

namespace Projecteer.Core.Domain
{
    public class Message
    {
        public Message()
        {

        }

        public Message(MessagesModel message)
        {
            this.Update(message);
        }

        public void Update(MessagesModel message)
        {
            Text = message.Text;
        }

        public int MessageId { get; set; }
        public string ProjecteerUserId { get; set; }
        public string Text { get; set; }

        public virtual ProjecteerUser ProjecteerUser { get; set; }
    }
}
