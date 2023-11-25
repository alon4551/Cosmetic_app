using Cosmetic_App.Forms;
using iText.Layout.Borders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic_App.Utiltes
{
    public static class App_Process
    {
        public static int NewOrder(string worker_id)
        {
            using (Store store = new Store(worker_id))
            {
                store.ShowDialog();
                if (store.finish)
                {
                    using (Order_Edit edit = new Order_Edit((int)store.Order.Value))
                    {
                        edit.ShowDialog();
                    }
                    return (int)store.Order.Value;
                }
            }
            return -1;
        }
    }
}
