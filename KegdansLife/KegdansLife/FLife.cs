using System;
using System.Threading;
using System.Windows.Forms;

namespace KegdansLife
{
    public partial class FLife : Form
    {
        private CancellationTokenSource _cts;
        private readonly Field _field;
        public FLife()
        {
            InitializeComponent();
            _field = new Field(this);
           
        }

       

        private void bSetFieldSize_Click(object sender, EventArgs e)
        {
            _field.SetSize(int.Parse(mTBFieldSize.Text));
        }

        private void cBIsSetAlive_CheckedChanged(object sender, EventArgs e)
        {
            _field.ChangeSetMode(cBIsSetAlive.Checked);
        }

        private void bNextStep_Click(object sender, EventArgs e)
        {
            _field.NextStep();
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            _field.Clear();
        }

        private async void bNextXStep_Click(object sender, EventArgs e)
        {
            using (_cts = new CancellationTokenSource())
            {
                ControlsState(false);
                await _field.Start(_cts);
                ControlsState(true);
            }
         
            
        }

        private void ControlsState(bool isEnable)
        {
            bClear.Enabled = isEnable;
            bNextStep.Enabled = isEnable;
            bStart.Enabled = isEnable;
            bSetFieldSize.Enabled = isEnable;
            bCancel.Enabled = !isEnable;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            _cts.Cancel();
        }

     
    }
}
