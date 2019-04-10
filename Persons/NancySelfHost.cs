namespace Persons
{
    using System;
    using Nancy.Hosting.Self;

    public class NancySelfHost
    {
        private NancyHost _nancyHost;

        /// <summary>
        /// Starts Nancy service.
        /// </summary>
        public void Start()
        {
            _nancyHost = new NancyHost(new Uri("http://localhost:5000"));
            _nancyHost.Start();
        }

        /// <summary>
        /// Stops Nancy service.
        /// </summary>
        public void Stop()
        {
            _nancyHost.Stop();
            Console.WriteLine("Stopped. Good bye!");
        }
    }
}
