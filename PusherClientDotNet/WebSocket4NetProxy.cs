using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebSocket4Net;

namespace PusherClientDotNet
{
    class WebSocket4NetProxy : WebSocket4Net.WebSocket, IWebSocket
    {
        public WebSocket4NetProxy(string url)
            : base(url)
        {
            Opened += (o, e) => { if (OnOpen != null) OnOpen(this, e); };
            Closed += (o, e) => { if (OnClose != null) OnClose(this, e); };
            MessageReceived += (o, e) => { if (OnData != null) OnData(this, e); };            
        }

        public event EventHandler<EventArgs> OnClose;

        public event EventHandler<MessageReceivedEventArgs> OnData;

        public event EventHandler<EventArgs> OnOpen;

        public void SendMessage(string data)
        {
            Send(data);
        }
    }
}
