namespace Training.DTO
{
    public class ResponeSaveDTO<TModel>
    {
        public TModel Model { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
