using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Design_Pattern.Patterns
{
    public sealed class Server
    {
        public string ServerName { get; set; }
        public int PlayerCounter { get; set; }
        private Server() { }
        private static Server? _server;
        public static Server GetServer()
        {
            if (_server == null)
            {
                _server = new Server { PlayerCounter = 0, ServerName = "SampleServer" };
            }
            return _server;
        }
    }
}