namespace Blog_Projeto.Services.Posts.Posts_Repository
{
    public class Posts_Facade
    {
        public readonly Posts_Service Posts;
        public Posts_Facade(Posts_Service post)
        {
            Posts = post;
        }
    }
}
