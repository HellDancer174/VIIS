using System.Threading.Tasks;

namespace VIIS.App.GlobalViewModel
{
    public interface IUpdatableCollection
    {
        Task UpdateCollectionAsync();
    }
}