namespace Assignment_Task.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string? Massage { get; set; }
        public string Environment  { get; set; }
        public string stackTrace { get; set; }
    }
}
