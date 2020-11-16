namespace DfESurveyTool.Web.Config
{
    public class AzureAdConfig
    {
        public string Instance { get; set; }
        public string Domain { get; set; }
        public string CallbackPath { get; set; }
        public string TenantId { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

        // API Auth settings
        //public string Authority { get; set; }
        //public string Audience { get; set; }
    }
}
