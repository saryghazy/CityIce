namespace IceCity
{
    [Serializable]
    internal class HeaterFailedException : Exception//
    {
        public HeaterFailedException()
        {
        }

        public HeaterFailedException(string? message) : base(message)
        {
        }

        public HeaterFailedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}