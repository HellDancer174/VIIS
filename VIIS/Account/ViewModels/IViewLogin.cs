using System.Threading.Tasks;

namespace VIIS.App.Account.ViewModels
{
    public interface IViewLogin
    {
        Task LogIn(string pass);
    }
}