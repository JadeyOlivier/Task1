using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JadeOlivier_19013088_Task1
{
    public partial class frmBattlefield : Form
    {
        int timerTicks;
        public frmBattlefield()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            battleTimer.Start();
            
        }

        private void battleTimer_Tick(object sender, EventArgs e)
        {
            timerTicks++;
            lblRound.Text = timerTicks.ToString();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            battleTimer.Stop();
        }

        private void frmBattlefield_Load(object sender, EventArgs e)
        {
            GameEngine ge = new GameEngine();
            lblMap.Text = ge.MapTracker.drawMap();
            foreach (Unit temp in ge.MapTracker.mapArray)
            {
                string typeCheck = temp.GetType().ToString();
                string[] splitArray = typeCheck.Split('.');
                typeCheck = splitArray[splitArray.Length - 1];

                if (typeCheck == "MeleeUnit")
                {
                    MeleeUnit obj = (MeleeUnit)temp;
                    rtxProgress.AppendText(obj.ToString());
                }
                else
                {
                    RangedUnit obj = (RangedUnit)temp;
                    rtxProgress.AppendText(obj.ToString());
                }
            }
        }
    }
}
