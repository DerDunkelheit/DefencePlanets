using UnityEngine;

namespace TextManager.Senders
{
    public class MailSender : MonoBehaviour,ISender
    {
        public void Send(string textToSend)
        {
            Debug.Log("Sending text to mail...");
        }
    }
}
