namespace DfESurveyTool.Web.Models.Shared
{
    public class Link
    {
        public string Title { get; set; }

        public string URL { get; set; }

        public Link()
        {
        }

        public Link(string title, string url)
        {
            Title = title;
            URL = url;
        }
    }
}
