namespace CRUPersonRepository.Utility
{
    public class Response<TModel>
    {
        public bool status {  get; set; }
        public TModel value { get; set; }
        public string msg { get; set; }
    }
}
