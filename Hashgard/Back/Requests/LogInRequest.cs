using System;

namespace Hashgard.Back.Requests
{
    public class LogInRequest
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public TimeSpan SessionLifetime { get; set; }
    }
}
