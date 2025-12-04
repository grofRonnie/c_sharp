
namespace ZH2_NAP_APP
{
    [Serializable]
    internal class NagyMaximalisToltotomegException : Exception
    {
        public NagyMaximalisToltotomegException()
        {
        }

        public NagyMaximalisToltotomegException(string? message) : base(message)
        {
        }

        public NagyMaximalisToltotomegException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}