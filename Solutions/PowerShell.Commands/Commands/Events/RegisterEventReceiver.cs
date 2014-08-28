﻿using OfficeDevPnP.PowerShell.Commands.Base.PipeBinds;
using Microsoft.SharePoint.Client;
using System.Management.Automation;

namespace OfficeDevPnP.PowerShell.Commands
{
    [Cmdlet(VerbsLifecycle.Register, "SPOEventReceiver")]
    public class RegisterEventReceiver : SPOWebCmdlet
    {
        [Parameter(Mandatory = true, ParameterSetName = "List")]
        public SPOListPipeBind List;

        [Parameter(Mandatory = true)]
        public string Name;

        [Parameter(Mandatory = true)]
        public string Url;

        [Parameter(Mandatory = true)]
        [Alias("Type")]
        public EventReceiverType EventReceiverType;

        [Parameter(Mandatory = true)]
        [Alias("Sync")]
        public EventReceiverSynchronization Synchronization;

        [Parameter(Mandatory = false)]
        public SwitchParameter Force;

        protected override void ExecuteCmdlet()
        {
            if (ParameterSetName == "List")
            {
                var list = this.SelectedWeb.GetList(List);
                WriteObject(list.RegisterRemoteEventReceiver(Name, Url, EventReceiverType, Synchronization, Force));
            }
            else
            {
                Microsoft.SharePoint.Client.Web web = SelectedWeb;
                WriteObject(this.SelectedWeb.RegisterRemoteEventReceiver(Name, Url, EventReceiverType, Synchronization, Force));
            }

        }

    }

}


