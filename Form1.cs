using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetryClassGIS
{
    public partial class Form1 : Form
    {
        List<GISPoint> points = new List<GISPoint>();//存储所有添加的点
        public Form1()
        {
            InitializeComponent();
        }

        private void mBtnAddPoint_Click(object sender, EventArgs e)
        {
            //点击按钮添加点
            double x = Convert.ToDouble(mTxbX.Text);//点的X
            double y = Convert.ToDouble(mTxbY.Text);//点的Y
            string attribute = mTxbAttribute.Text;//点的属性
            GISVertex onevertex = new GISVertex(x, y);//实例化vertex
            GISPoint onepoint = new GISPoint(onevertex,attribute);//实例化点（坐标+属性）
            Graphics g = mPnlDrawArea.CreateGraphics();//创建画布
            onepoint.DrawPoint(g);//绘制点
            onepoint.DrawAttribute(g);//绘制属性
            points.Add(onepoint);//将点添加到列表
        }

        private void mPnlDrawArea_MouseClick(object sender, MouseEventArgs e)
        {
            //点击画布，查询最近点的属性（距离不大于5）
            GISVertex clickvertex = new GISVertex(e.X, e.Y);//在点击处创建点
            double mindistance = double.MaxValue;
            int findIndex = -1;//确定选中点在列表的index
            foreach (GISPoint point in points) {//遍历points
                findIndex++;
                double distance = point.Distance(clickvertex);
                if(mindistance > distance) mindistance = distance;
            }
            if (findIndex == -1 || mindistance > 5)
                MessageBox.Show("没有点或没有选中点");
            else MessageBox.Show(points[findIndex].attribute);
        }
    }
}
