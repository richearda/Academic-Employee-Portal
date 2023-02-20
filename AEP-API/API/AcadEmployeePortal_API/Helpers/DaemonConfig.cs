namespace ISMS_API.Helpers
{
    public class DaemonConfig
    {
        public string DaemonName { get { return "MCC-ISMS API Service"; } }
        public string HTTP_Port { get { return "5000"; } }
        public string HTTPS_Port { get { return "5001"; } }
        public string Secret { get; set; }
    }
}