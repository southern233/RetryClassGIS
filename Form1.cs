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
        public Form1()
        {
            InitializeComponent();
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
            oneFeature.draw(g, true, 0);//绘制feature
        }

        private void mPnlDrawArea_MouseClick(object sender, MouseEventArgs e)
        {
            //点击画布，查询最近点的属性（距离不大于5）
            GISVertex clickVertex = new GISVertex(e.X, e.Y);//在点击处创建点
            double mindistance = double.MaxValue;
            int findIndex = -1;//确定选中点在列表的index
            foreach (GISFeature feature in features) {//遍历features
                findIndex++;
                double distance = features[findIndex].spatialPart.centroid.Distance(clickVertex);//核心代码
                if(mindistance > distance) mindistance = distance;
            }
            if (findIndex == -1 || mindistance > 5)
                MessageBox.Show("没有点或没有选中点");
            else MessageBox.Show(features[findIndex].attributePart.Getvalue(0).ToString());
        }
    }
}
