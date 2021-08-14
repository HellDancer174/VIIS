using System;
using System.Threading.Tasks;
using VIIS.App.Staff.ViewModels.WorkGraphViewModels;
using VIMVVM;

namespace VIIS.App.Staff.ViewModels
{
    public interface IViewWorkGraph
    {
        DateTime Current { get; set; }
        ViewMastersList MastersList { get; }
        RelayCommand Save { get; }

        Task UpdateCollectionAsync();
    }
}