namespace RestWCFWinService
{
    #region Namespaces
    using System.ComponentModel;
    using System.Configuration.Install;
    using System.ServiceProcess;
    #endregion

    [RunInstaller(true)]
    public partial class MyRestWCFRestWinSerInstaller : System.Configuration.Install.Installer
    {
        private ServiceProcessInstaller process;
        private ServiceInstaller service;

        public MyRestWCFRestWinSerInstaller()
        {
            process = new ServiceProcessInstaller();
            process.Account = ServiceAccount.LocalSystem;
            service = new ServiceInstaller();
            service.ServiceName = "Document  scanner v1.0";
            service.Description = "WCF REST API Hosting on Windows Service";
            service.DelayedAutoStart = true;
            this.service.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            //service.StartType = ServiceStartMode.Automatic;

            this.service.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.serviceInstaller1_AfterInstall);
            this.service.StartType = ServiceStartMode.Automatic;
            Installers.Add(process);
            Installers.Add(service);
           
        }

        private void serviceInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {
            new ServiceController(service.ServiceName).Start();
        }
     

        private void serviceProcessInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {

        }
    }
}








