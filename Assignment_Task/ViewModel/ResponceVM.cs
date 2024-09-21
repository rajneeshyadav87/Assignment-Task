namespace Assignment_Task.ViewModel
{
   
    public class ResponceVM
    {
        public int Status { get; set; }
        public string MSG { get; set; }
     
    }
    public static class ResponseType
    {
        public static string Success { get { return "success"; } }
        public static string Warning { get { return "warning"; } }
        public static string Error { get { return "error"; } }
        public static string Info { get { return "info"; } }
    }
}
