using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JGame
{
    public partial class Form1 : Form, IDisplay
    {
        IGame _theGame;
        float _interp = 0.0f;
        HashSet<Keys> _pressedKeys;
        FramesPerSecondCalc _fpsCalc;
        Font _debugFont;

        public Form1()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Cursor.Dispose();

            // IMPORTANT: Tell Windows that we will do all
            // drawing in the Paint method
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque | ControlStyles.DoubleBuffer, true);

            _pressedKeys = new HashSet<Keys>();
            _fpsCalc = new FramesPerSecondCalc(true);
            _debugFont = new System.Drawing.Font(FontFamily.GenericMonospace, 10f);

            _theGame = new TheGame(this, ClientSize);
            _theGame.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            _theGame.Draw(e.Graphics, _interp);
            
            // draw fps
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            Pen p = new Pen(Color.Black, 2.0f);
            path.AddString(String.Format("FPS: {0}", _fpsCalc.Fps),
                           FontFamily.GenericSansSerif, 0, 24f,
                           Point.Empty, StringFormat.GenericTypographic);
            e.Graphics.DrawPath(p, path);
            e.Graphics.FillPath(Brushes.White, path);
            p.Dispose();
            path.Dispose();

            _fpsCalc.DrawFrame(); // used for calculating FPS
        }

        public void Draw(float interp)
        {
            _interp = interp;
            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_pressedKeys.Contains(e.KeyCode))
            {
                _pressedKeys.Add(e.KeyCode);
                _theGame.KeyHandler(e.KeyCode, KeyState.Down);
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            _theGame.KeyHandler(e.KeyCode, KeyState.Up);
            _pressedKeys.Remove(e.KeyCode);
        }

        public void Exit()
        {
            Application.Exit();
        }

    }
}
