﻿using Cosmetic_App.Utiltes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cosmetic_App.Custom_View
{
    public partial class Appoitment_view : UserControl
    {// a custom view for Appoitment
        public Appoitment_view(int orderId)
        {
            InitializeComponent();
            button1.Tag = orderId;
        }

        public void SetDate(Row r)
        {//setting information by record
            string text;
            time.Text = $"{r.GetColValue(Database_Names.Calender_Columes[6])} - {r.GetColValue("ending").ToString()}" ;
            worker_name.Text = "עובד:"+r.GetColValue("worker_name").ToString();
            text = $"לקוח {r.GetColValue("client_name")} " +
                $"עושה {r.GetColValue("treatment_name")}";
            description.Text = text;
        }

        private void Appoitment_view_Load(object sender, EventArgs e)
        {

        }
        public void SetAction(EventHandler clickEvent)//adding action to button
        {
            button1.Click += clickEvent;
        }

    }
}
