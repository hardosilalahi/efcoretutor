using System;
namespace tutorefcore.Models
{
    public enum Post_status{
        created = 1,
        pending = 2,
        publised = 3,
        failure = 0
    }
    public class Posts
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
        public Post_status Status { get; set; }
        public DateTime Create_time { get; set; }
        public DateTime Update_time { get; set; }
    }
}