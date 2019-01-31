namespace Persons.Service
{
    using Serilog;
    using Topshelf;

    public class Program
    {
        public static void Main()
        {
            var log = new LoggerConfiguration().WriteTo.Console().CreateLogger();
            Log.Logger = log;

            HostFactory.Run(x =>
            {
                x.Service<NancySelfHost>(s =>
                {
                    s.ConstructUsing(name => new NancySelfHost());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();
                x.SetDescription("net.projects.test");
                x.SetDisplayName("net.projects.test Service");
                x.SetServiceName("NetProjectsTest");
            });
        }
    }
}