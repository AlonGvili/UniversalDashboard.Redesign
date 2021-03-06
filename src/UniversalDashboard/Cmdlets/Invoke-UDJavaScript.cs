using NLog;
using System.Management.Automation;
using Microsoft.AspNetCore.SignalR;

namespace UniversalDashboard.Cmdlets
{
    [Cmdlet(VerbsLifecycle.Invoke, "UDJavaScript")]
    public class InvokeUDJavaScriptCommand : PSCmdlet
    {
		//private readonly Logger Log = LogManager.GetLogger(nameof(SelectUDElementCommand));

        [Parameter(Mandatory = true)]
		public string JavaScript { get; set; }

        protected override void EndProcessing()
        {
            var hub = this.GetVariableValue("DashboardHub") as IHubContext<DashboardHub>;
            var connectionId = this.GetVariableValue("ConnectionId") as string;   
            hub.InvokeJavaScript(connectionId, JavaScript).Wait();
		}
	}
}
