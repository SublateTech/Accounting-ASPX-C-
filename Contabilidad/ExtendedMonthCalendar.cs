using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Contabilidad
{
    public class ExtendedMonthCalendar:MonthCalendar        
    {
        private Point m_LastClickPosition;
        private long m_LastClickTime;
        private bool m_LastClickRaisedDoubleClick;

        public new event DoubleClickEventHandler DoubleClick;
        public new delegate void DoubleClickEventHandler(object sender, EventArgs e);

        protected override void OnDoubleClick(EventArgs e)
        {
            if (DoubleClick != null)
            {
                DoubleClick(this, e);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!m_LastClickRaisedDoubleClick && DateTime.Now.Ticks - m_LastClickTime <= SystemInformation.DoubleClickTime * 10000 && IsInDoubleClickArea(m_LastClickPosition, Cursor.Position))
                {
                    OnDoubleClick(EventArgs.Empty);
                    m_LastClickRaisedDoubleClick = true;
                }
                else
                {
                    m_LastClickRaisedDoubleClick = false;
                }
                m_LastClickPosition = Cursor.Position;
                m_LastClickTime = DateTime.Now.Ticks;
            }
            base.OnMouseDown(e);
        }

        private bool IsInDoubleClickArea(Point Point1, Point Point2)
        {
            return Math.Abs(Point1.X - Point2.X) <= SystemInformation.DoubleClickSize.Width && Math.Abs(Point1.Y - Point2.Y) <= SystemInformation.DoubleClickSize.Height;
        }


    }
}
