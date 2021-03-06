using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.OrdersJournal.OrderDetail.ViewModels;
using VIIS.Domain.Customers;

namespace VIIS.App.OrdersJournal.OrderDetail.Models
{
    public class ViewTransferableClient : Client
    {
        private readonly Client other;
        private readonly ViewClient media;

        public ViewTransferableClient(Client other, ViewClient media) : base(other)
        {
            this.other = other;
            this.media = media;
        }

    }
}
