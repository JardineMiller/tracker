namespace Tracker.DAL
{
    public class ValidationConstants
    {
        public static class User
        {
            public const int MinimumPasswordLength = 6;
        }

        public static class Task
        {
            public const int MaxNameLength = 100;
            public const int MaxDescriptionLength = 250;
        }
    }
}