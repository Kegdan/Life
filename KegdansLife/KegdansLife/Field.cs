using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KegdansLife
{
    internal class Field : Control
    {
        private int _size;
        private bool _isMousePresses;
        private bool[,] _state;
        private bool[,] _isNeedChange;
        private bool _isAlive = true;
        private readonly Graphics _graphics;
        private int _step;
        private bool _isEnableForEdit = true;

        public Field(Control parent)
        {
            Parent = parent;
            Height = parent.ClientRectangle.Height;
            Width = Height;
            SetSize(FieldConst.DefaultSize);
            _graphics = CreateGraphics();
            BackColor = FieldConst.DeadColor;
        }

        #region Add/Remove cell
        protected override void OnMouseDown(MouseEventArgs e)
        {
            _isMousePresses = e.Button == MouseButtons.Left;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _isMousePresses = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!_isMousePresses) return;
            SetCell(e.X / _step, e.Y / _step);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            SetCell(e.X / _step, e.Y / _step);
        }

        private void SetCell(int x, int y)
        {
            if (!_isEnableForEdit||!_inField(x) || !_inField(y)) return;
            _state[x + 1, y + 1] = _isAlive;
            _graphics.FillRectangle(_isAlive ? FieldConst.AliveBrush : FieldConst.DeadBrush, _step*x + 1, _step*y + 1,
                _step - 1, _step - 1);
        }

        private bool _inField(int i)
        {
            return i >= 0 && i < _size;
        }

        public void ChangeSetMode(bool isAlive)
        {
            _isAlive = isAlive;
        }
        #endregion

        #region Draw
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            PaintAll();
        }

        private void PaintAll()
        {
            for (int i = 1; i <= _size; i++)
                for (int j = 1; j <= _size; j++)
                        _graphics.FillRectangle(_state[i, j] ? FieldConst.AliveBrush : FieldConst.DeadBrush,
                            _step * (i - 1) + 1, _step * (j - 1) + 1, _step - 1, _step - 1);
            for (int i = 0; i <= _size; i++)
            {
                _graphics.DrawLine(FieldConst.DefaultPen, i * _step, 0, i * _step, _step * _size);
                _graphics.DrawLine(FieldConst.DefaultPen, 0, i * _step, _step * _size, i * _step);
            }
        }

        private void FieldPaint()
        {
            for (int i = 1; i <= _size; i++)
                for (int j = 1; j <= _size; j++)
                    if (_isNeedChange[i, j])
                        _graphics.FillRectangle(_state[i, j] ? FieldConst.AliveBrush : FieldConst.DeadBrush,
                            _step * (i - 1) + 1, _step * (j - 1) + 1, _step - 1, _step - 1);
        }
        #endregion

        public void SetSize(int size)
        {
            _size = size;
            _state = new bool[size + 2, size + 2];
            _isNeedChange = new bool[size + 2, size + 2];
            _step = Width/_size;
            Invalidate();
        }

        public void NextStep()
        {
            FillBorders();

            int neighbors;
            for (int i = 1; i <= _size; i++)
                for (int j = 1; j <= _size; j++)
                {
                    neighbors = 0;
                    for (int ii = i - 1; ii <= i + 1; ii++)
                        for (int ji = j - 1; ji <= j + 1; ji++)
                            if (_state[ii, ji]) neighbors++;
                    _isNeedChange[i, j] = _state[i, j] ? neighbors != 4 && neighbors != 3 : neighbors == 3;

                }
            for (int i = 1; i <= _size; i++)
                for (int j = 1; j <= _size; j++)
                    if (_isNeedChange[i, j]) _state[i, j] = !_state[i, j];
            FieldPaint();

        }

        private void FillBorders()
        {
            for (int i = 1; i <= _size; i++)
            {
                _state[0, i] = _state[_size, i];
                _state[_size + 1, i] = _state[1, i];
                _state[i, 0] = _state[i, _size];
                _state[i, _size + 1] = _state[i, 1];
            }
            _state[0, 0] = _state[_size, _size];
            _state[0, _size + 1] = _state[_size, 1];
            _state[_size + 1, 0] = _state[1, _size];
            _state[_size + 1, _size + 1] = _state[1, 1];
        }

        public async Task Start(CancellationTokenSource cts)
        {
            _isEnableForEdit = false;
            while (!cts.Token.IsCancellationRequested)
            {
                NextStep();
                var wait = Task.Factory.StartNew(() => Thread.Sleep(200));
                if (isAllDead()) cts.Cancel();
                await wait;
            }
            _isEnableForEdit = true;
        }

        private bool isAllDead()
        {
            var result = false; 
            for (int i = 1; i <= _size; i++)
                for (int j = 1; j <= _size; j++)
                    result |= _state[i, j];
            return !result;
        }

        public void Clear()
        {
            _state = new bool[_size + 2, _size + 2];
            Invalidate();
        }

        private static class FieldConst
        {
            public static readonly Pen DefaultPen = new Pen(Color.Black);
            public const int DefaultSize = 10;
            public static Color DeadColor = Color.White;
            public static Brush AliveBrush = new SolidBrush(Color.Green);
            public static Brush DeadBrush = new SolidBrush(DeadColor);

        }
    }
}
