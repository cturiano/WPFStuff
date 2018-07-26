using System.Security;

namespace Chat.Core.Interfaces
{
    public interface IHavePassword
    {
        #region Properties

        SecureString Password { get; }

        #endregion
    }
}