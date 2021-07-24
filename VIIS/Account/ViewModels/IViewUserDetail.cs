using System.Threading.Tasks;

namespace VIIS.App.Account.ViewModels
{
    public interface IViewUserDetail
    {
        Task Save(string firstPass, string secondPass);
    }
}