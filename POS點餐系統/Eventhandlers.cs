using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS點餐系統
{
    internal class Eventhandlers
    {

        public static event EventHandler<string> ResultEvent;
        public static event EventHandler <FlowLayoutPanel> DisplayEvent;


        public static void NotifyEvent(string Total)
        {
            ResultEvent.Invoke(null, Total);
        }
        public static void NotifyDisplayEvent(FlowLayoutPanel data)
        {
            DisplayEvent.Invoke(null, data);
        }

    }
}
