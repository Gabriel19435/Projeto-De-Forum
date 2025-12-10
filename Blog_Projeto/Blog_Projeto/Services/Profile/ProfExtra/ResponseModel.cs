namespace Blog_Projeto.Services.Profile.ProfExtra
{
    public class ResponseModel<T>
    {
        public T Model { get; set; }
        public string ViewMessage { get; set; }
        public bool Erro { get; set; } = true;
    }
}
