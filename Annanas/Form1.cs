using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Annanas
{
    public partial class Form1 : Form
    {
        IModel<T> model;
        IController<T> controller;
        public Form1()
        {
            InitializeComponent();
            controller = new Controller<T>();
            model = new Model<T>();
            panelView1.SetModel(model);
            controller.SetModel(model);
            controller.AddView(panelView1);
            int w = 70, h = 70;
            controller.SetMatrix(panelView1.Width / w, panelView1.Height / h);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            T items = new T();
            items.Data = "228";
            controller.Add(items);
        }
    }
}

struct T
{
    string data;
    public string Data { get { return data; } set { data = value; } }
}