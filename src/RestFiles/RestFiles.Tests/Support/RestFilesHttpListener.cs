using Funq;
using RestFiles.ServiceInterface;
using ServiceStack;

namespace RestFiles.Tests
{
	public class RestFilesHttpListener
		: AppHostHttpListenerBase
	{
		public const string ListeningOn = "http://localhost:8080/";

		public RestFilesHttpListener()
			: base("HttpListener Hosts for Unit Tests", typeof(FilesService).Assembly) { }

		public AppConfig AppConfig { get; set; }

		public override void Configure(Container container)
		{
			this.AppConfig = new AppConfig
			{
				RootDirectory = "~/App_Data/files/".MapAbsolutePath(),
				TextFileExtensions = ".txt,.sln,.proj,.cs,.config,.asax".Split(','),
			};
			container.Register(this.AppConfig);

			this.Start(ListeningOn);
		}
	}
}