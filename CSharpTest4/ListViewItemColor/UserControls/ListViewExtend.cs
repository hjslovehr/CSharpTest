using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListViewItemColor
{
    /// <summary>
    /// ListView 控件扩展
    ///     目的：皮面 ListView 控件刷新数据时闪烁
    /// </summary>
    public class ListViewExtend : ListView
    {
        public ListViewExtend() : base()
        {
            // 启用双缓冲
            SetStyle(ControlStyles.DoubleBuffer |
                        ControlStyles.OptimizedDoubleBuffer |
                        ControlStyles.AllPaintingInWmPaint,
                        true);
            UpdateStyles();
        }

        protected override void OnNotifyMessage(Message m)
        {
            // WM_ERASEBKGND = 0x0014  当窗口背景必须被擦除时（例在窗口改变大小时）
            if (0x14 != m.Msg)
            {
                base.OnNotifyMessage(m);
            }

        }
    }
}
