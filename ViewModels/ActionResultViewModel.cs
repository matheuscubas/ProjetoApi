namespace DesafioDesafiante.ViewModels
{
    public class ActionResultViewModel<T>
    {
        public ActionResultViewModel(T data, List<string> errors)
        {
            Data = data;
            Errors = errors;
        }

        public ActionResultViewModel(T data) 
            => Data = data;

        public ActionResultViewModel(List<string> errors)
            => Errors = errors;

        public ActionResultViewModel(string error)
            => Errors.Add(error);
        

        public T? Data { get; set; }
        public List<string> Errors { get; private set; } = new();
    }
}
