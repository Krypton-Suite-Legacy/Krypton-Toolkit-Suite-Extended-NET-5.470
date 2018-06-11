﻿using ComponentFactory.Krypton.Toolkit;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ExtendedControls.ExtendedToolkit.ToolstripControls
{
    [ToolboxBitmap(typeof(ToolStripStatusLabel)), ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.StatusStrip | ToolStripItemDesignerAvailability.ToolStrip)]
    public class ExtendedToolStripStatusLabel : ToolStripStatusLabel
    {
        #region Variables

        #region Krypton
        IPalette _palette;

        IRenderer _renderer;

        // This may not be needed, but oh well...
        KryptonPalette _kryptonPalette;
        #endregion

        Color _textColour, _backGradient1, _backGradient2;

        Font _textTypeface;

        LinearGradientMode _linearGradientMode;
        #endregion

        #region Properties        
        /// <summary>
        /// Gets or sets the gradient colour one.
        /// </summary>
        /// <value>
        /// The gradient colour one.
        /// </value>
        [DefaultValue(typeof(Color), "White"), Description("The first gradient colour."), Category("Appearance")]
        public Color GradientColourOne
        {
            get
            {
                return _backGradient1;
            }

            set
            {
                _backGradient1 = value;

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the gradient colour two.
        /// </summary>
        /// <value>
        /// The gradient colour two.
        /// </value>
        [DefaultValue(typeof(Color), "Blue"), Description("The second gradient colour."), Category("Appearance")]
        public Color GradientColourTwo
        {
            get
            {
                return _backGradient2;
            }

            set
            {
                _backGradient2 = value;

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the gradient mode.
        /// </summary>
        /// <value>
        /// The gradient mode.
        /// </value>
        [DefaultValue(typeof(LinearGradientMode), "ForwardDiagonal"), Description("Gradient mode"), Category("Appearance")]
        public LinearGradientMode GradientMode
        {
            get
            {
                return _linearGradientMode;
            }

            set
            {
                _linearGradientMode = value;

                Invalidate();
            }
        }
        #endregion

        #region Constructors
        public ExtendedToolStripStatusLabel()
        {

        }
        #endregion

        #region Overrides
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override Color BackColor { get => new Color(); set {; } }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStripItem.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    Graphics g = e.Graphics;

        //    Rectangle r = new Rectangle(0, 0, Width, Height);

        //    if (ForeColor != Color.Empty)
        //    {
        //        g.TextRenderingHint = TextRenderingHint.AntiAlias;

        //        Font typeface = new Font(Font.FontFamily, Font.Size, Font.Style, Font.Unit);

        //        SolidBrush brush = new SolidBrush(ForeColor);

        //        g.DrawString(Text, typeface, brush, 0, 0);
        //    }
        //    else if (BackColor != Color.Empty)
        //    {
        //        using (SolidBrush sb = new SolidBrush(BackColor))
        //        {
        //            g.FillRectangle(sb, r);
        //        }
        //    }
        //    else if (GradientColourOne != Color.Empty || GradientColourTwo != Color.Empty)
        //    {
        //        using (LinearGradientBrush lgb = new LinearGradientBrush(r, GradientColourOne, GradientColourTwo, GradientMode))
        //        {
        //            g.FillRectangle(lgb, r);
        //        }
        //    }

        //    base.OnPaint(e);
        //}
        protected override void OnPaint(PaintEventArgs e)
        {
            // Set a graphics variable
            Graphics g = e.Graphics;

            // Rectangle variable
            Rectangle r = new Rectangle(0, 0, Width, Height);

            if (ForeColor != Color.Empty)
            {
                g.TextRenderingHint = TextRenderingHint.AntiAlias;

                Font typeface = new Font(Font.FontFamily, Font.Size, Font.Style, Font.Unit);

                SolidBrush brush = new SolidBrush(ForeColor);

                g.DrawString(Text, typeface, brush, 0, 0);
            }

            if (BackColor != Color.Empty)
            {
                using (SolidBrush sb = new SolidBrush(BackColor))
                {
                    g.FillRectangle(sb, r);
                }
            }
            else if (GradientColourOne != Color.Empty || GradientColourTwo != Color.Empty)
            {
                using (LinearGradientBrush lgb = new LinearGradientBrush(r, GradientColourOne, GradientColourTwo, GradientMode))
                {
                    g.FillRectangle(lgb, r);
                }
            }

            base.OnPaint(e);
        }
        #endregion

        #region Methods
        public void SetTextColour(Color textColour)
        {
            if (_palette != null)
            {

            }
        }
        #endregion
    }
}