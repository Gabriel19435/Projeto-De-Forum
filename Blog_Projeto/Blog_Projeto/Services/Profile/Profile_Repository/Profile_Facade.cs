namespace Blog_Projeto.Services.Profile.Profile_Repository
{
    public class Profile_Facade
    {
        public readonly Profile_Services Model;
        public Profile_Facade(Profile_Services _Model)
        {
            Model = _Model;
        }
    }
}
