using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TalespireDiceMacros
{
    public partial class frmRolls : Form
    {
        public frmRolls()
        {
            InitializeComponent();
        }

        public class Rolls
        {
            public Dictionary<string, string> macros = new Dictionary<string, string>();
        }

        private Rolls rolls = new Rolls();

        int x = 10;
        int y = 10;
        private void frmRolls_Load(object sender, EventArgs e)
        {
            rolls = JsonConvert.DeserializeObject<Rolls>(System.IO.File.ReadAllText("Macros.json"));
            foreach(KeyValuePair<string,string> macro in rolls.macros)
            {
                Button newButton = new Button();
                newButton.Left = x;
                newButton.Top = y;
                newButton.Width = 200;
                newButton.Height = 60;
                newButton.Text = macro.Key;
                newButton.Click += (s,a)=>NewButton_Click(macro.Key,macro.Value);
                newButton.Enabled = true;
                newButton.Visible = true;
                frmRolls.ActiveForm.Controls.Add(newButton);
                y = y + 60;
                if (y > 600) { y = 10; x = x + 220; }
            }
            if(rolls.macros.Count<10)
            {
                frmRolls.ActiveForm.Height = 660 - (60*(10-rolls.macros.Count));
            }
            else
            {
                frmRolls.ActiveForm.Height = 660;
            }
            frmRolls.ActiveForm.Width = 235+(int)Math.Floor(rolls.macros.Count / 10f) * 220;
        }

        private void NewButton_Click(string name, string formula)
        {
            Process proc = new Process();
            proc.StartInfo = new ProcessStartInfo()
            {
                FileName = "talespire://dice/" + SafeName(name) + ":" + formula,
                Arguments = "",
                UseShellExecute = true,
                CreateNoWindow = true
            };
            proc.Start();
        }

        private string SafeName(string txt)
        {
            return txt.Replace(" ", " "); // Space to ALT+255
        }
    }
}
