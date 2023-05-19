namespace LabOne.Models
{
    public class GeneralResponse
    {
        public string Message { get; set; }
        public GeneralResponse(string mess)
        {
            Message = mess;
        }
    }
}
