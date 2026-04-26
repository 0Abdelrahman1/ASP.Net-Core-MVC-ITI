namespace MVC_WebApp_EF_Repo_Injection_Environment_Partial_Validation_Bundling.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
