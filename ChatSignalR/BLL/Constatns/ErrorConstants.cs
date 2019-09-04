namespace BLL.Constatns
{
    public static class ErrorConstants
    {
        public const int GeneralError = 1;
        public const int UserAlreadyExists = 2;
        public const int UserNotFound = 3;
        public const int UserWithThatEmailAlreadyExists = 4;
        public const int UserIsBlocked = 5;
        public const int UserIsDeleted = 6;
        public const int UserHasNotBeenVerified = 7;
        public const int IncorrectPasswordOrUsername = 8;
        public const int UnAuthorized = 9;
        public const int SessionExpired = 10;
    }
}
