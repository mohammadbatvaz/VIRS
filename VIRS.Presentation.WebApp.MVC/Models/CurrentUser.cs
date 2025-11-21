namespace VIRS.Presentation.WebApp.MVC.Models
{
    public class CurrentUser
    {
        public static Guid Id { get; private set; }
        public static string? FullName { get; private set; }

        public static void Set(Guid id, string fullName)
        {
            Id = id;
            FullName = fullName;
        }

        public static void Clear()
        {
            Id = Guid.Empty;
            FullName = null;
        }
    }
}
