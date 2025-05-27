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
        List<GISFeature> features = new List<GISFeature>();//存储所有添加的点
        GISView view;//记录当前地图大小和显示范围
        public Form1()
        {
            InitializeComponent();
            //初始化view
            view = new GISView(new GISExtent(new GISVertex(0,450),new GISVertex(600,0)),ClientRectangle);
        }

        private void mBtnAddPoint_Click(object sender, EventArgs e)
        {
            //点击按钮添加点
            double x = Convert.ToDouble(mTxbX.Text);//点的X
            double y = Convert.ToDouble(mTxbY.Text);//点的Y
            GISVertex oneVertex = new GISVertex(x, y);//实例化vertex
            GISPoint onePoint = new GISPoint(oneVertex);//实例化点（坐标+属性）
            
            string attribute = mTxbAttribute.Text;//点的属性
            GISAttribute oneAttribute = new GISAttribute();
            oneAttribute.AddValue(attribute);//添加属性

            GISFeature oneFeature = new GISFeature(onePoint,oneAttribute);//构建Feature
            features.Add(oneFeature);//为列表添加feature

            Graphics g = mPnlDrawArea.CreateGraphics();//获取画布
            oneFeature.draw(g, true, 0,view);//绘制feature
        }

        private void mPnlDrawArea_MouseClick(object sender, MouseEventArgs e)
        {
            //点击画布，查询最近点的属性（距离不大于5）
            GISVertex clickVertex = view.ToMapVertex(new Point(e.X, e.Y));//获取点击处的点在map上的位置
            double mindistance = double.MaxValue;
            int findIndex = -1;//确定选中点在列表的index
            for (int i = 0; i < features.Count; i++)
            {
                double distance = features[i].spatialPart.centroid.Distance(clickVertex);//核心代码
                if (distance < mindistance)
                {
                    mindistance = distance;
                    findIndex = i;
                }
            }
            if (findIndex == -1 || mindistance > 5)
                MessageBox.Show("没有点或没有选中点");
            else MessageBox.Show(features[findIndex].getAttribute(0).ToString());
        }

        private void mBtnRefreshMap_Click(object sender, EventArgs e)
        {
            //从文本框获取边界
            double minX = Double.Parse(mTxbMinX.Text);
            double minY = Double.Parse(mTxbMinY.Text);
            double maxX = Double.Parse(mTxbMaxX.Text);
            double maxY = Double.Parse(mTxbMaxY.Text);
            view.Update(new GISExtent(maxY,minX,minY,maxX),ClientRectangle);//刷新view
            Graphics graphics = mPnlDrawArea.CreateGraphics();
            graphics.Clear(Color.White);//清屏
            //重新绘制点
            for (int i = 0; i < features.Count; i++)
            {
                features[i].draw(graphics, true, 0, view);
            }
        }
    }
}
