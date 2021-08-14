using ElegantLib.Authorize.Tokenize;
using ElegantLib.Primitives;
using ElegantLib.Requests.JsonRequests;
using ElegantLib.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VIIS.App.GlobalViewModel;
using VIIS.Domain.Account;
using VIIS.Domain.Account.Requests;
using VIIS.Domain.Global.Documents;
using VIIS.Domain.Staff;
using VIIS.Domain.Staff.Decorators;

namespace VIIS.App.Staff.ViewModels.WorkGraphViewModels
{
    public class ViewMastersList: EmployeesDecorator, IUpdatableCollection
    {
        private List<int> columnNames;
        private List<ViewMasterOfWorkDays> mastersWorkDays;
        private List<string> months;
        private DateTime month;
        private readonly HttpClient client = new HttpClient();
        private readonly Action<RefreshViewModel> saveToken;

        public ViewMastersList(Employees other, DateTime month, Action<RefreshViewModel> saveToken) : base(other)
        {
            this.months = new List<string>() { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
            ChangeMonth(month);
            this.saveToken = saveToken;
        }
        public ViewMastersList(Employees other, DateTime month):this(other, month, (token) => App.Token = token)
        {

        }

        public void ChangeMonth(DateTime month)
        {
            this.month = month;
            mastersWorkDays = this.Select(master => new ViewMasterOfWorkDays(master, month)).ToList();
            columnNames = new Month(month).Days();
            CurrentMonth = months[month.Month - 1] + " " + month.Year;
            ChangeProperty(nameof(MastersWorkDays));
            ChangeProperty(nameof(ColumnNames));
            ChangeProperty(nameof(CurrentMonth));
        }

        public List<ViewMasterOfWorkDays> MastersWorkDays => mastersWorkDays;

        public string CurrentMonth { get; private set; }
        public List<int> ColumnNames => columnNames;

        public async Task UpdateCollectionAsync()
        {
            this.Clear();
            //var elements = await requestsFunc.Invoke(new HttpClient(), url);
            var elements = await new DeserializableResponseMessage<IEnumerable<Master>>(
                await new MemoryAuthorizedJsonRequest(new JsonRequest(client, new VIISJwtURL().MasterssUrl), App.Token, new MemoryJwtAccount(client, new VIISJwtURL(), saveToken), saveToken).Response()).DeserializedContent();
            foreach (var element in elements)
            {
                this.Add(element);
            }
        }
        public async Task SaveMonth()
        {
            await new InsertableDocument(new WorkDaysViewModel(mastersWorkDays.Select(master => master.Model()).ToArray(), month), saveToken, App.Token, new VIISJwtURL().WorkDaysUrl).TransferAsync();
        }
    }
}
