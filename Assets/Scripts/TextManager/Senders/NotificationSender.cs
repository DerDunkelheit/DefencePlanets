using UnityEngine;

namespace TextManager.Senders
{
    public class NotificationSender : MonoBehaviour,ISender
    {
        public void Send(string textToSend)
        {
            Debug.Log("Sending notification...");
        }
    }
}
