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
        GameEngine ge = new GameEngine();
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
            rtxProgress.Text = "";
            timerTicks++;
            lblRound.Text = timerTicks.ToString();
            if (ge.MapTracker.numDayWalkers > 0 && ge.MapTracker.numNightRiders > 0)
            {
                ge.GameRun();
                lblMap.Text = ge.MapTracker.drawMap();
                Display();
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            battleTimer.Stop();
        }

        private void Display()
        {
            string battleInfo = "";
            foreach (Unit temp in ge.MapTracker.unitArray)
            {
                string typeCheck = temp.GetType().ToString();
                string[] splitArray = typeCheck.Split('.');
                typeCheck = splitArray[splitArray.Length - 1];

                if (typeCheck == "MeleeUnit")
                {
                    MeleeUnit obj = (MeleeUnit)temp;
                    battleInfo += obj.ToString();
                }
                else
                {
                    RangedUnit obj = (RangedUnit)temp;
                    battleInfo += obj.ToString();
                }
            }

            rtxProgress.Text = battleInfo;
        }

            private void frmBattlefield_Load(object sender, EventArgs e)
        {
            GameEngine ge = new GameEngine();
            lblMap.Text = ge.MapTracker.drawMap();
            foreach (Unit temp in ge.MapTracker.unitArray)
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
