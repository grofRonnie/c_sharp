
namespace ZH2_NAP_APP
{
    [Serializable]
    internal class MaximalisFordulatszamNemErvenyesException : Exception
    {
        public MaximalisFordulatszamNemErvenyesException()
        {
        }

        public MaximalisFordulatszamNemErvenyesException(string? message) : base(message)
        {
        }

        public MaximalisFordulatszamNemErvenyesException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}