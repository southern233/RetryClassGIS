using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetryClassGIS
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 所有手动添加的点
        /// </summary>
        List<GISFeature> manualAddedFeatures = new List<GISFeature>();
        GISView view;//记录当前地图大小和显示范围
        GISLayer layer;//显示图层

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
            manualAddedFeatures.Add(oneFeature);//为列表添加feature

            Graphics g = mPnlDrawArea.CreateGraphics();//获取画布
            oneFeature.draw(g, true, 0,view);//绘制feature
        }

        private void mPnlDrawArea_MouseClick(object sender, MouseEventArgs e)
        {
            //点击画布，查询最近点的属性（距离不大于5）
            GISVertex clickVertex = view.ToMapVertex(new Point(e.X, e.Y));//获取点击处的点在map上的位置
            double mindistance = double.MaxValue;
            int findIndex = -1;//确定选中点在列表的index
            for (int i = 0; i < manualAddedFeatures.Count; i++)
            {
                double distance = manualAddedFeatures[i].spatialPart.centroid.Distance(clickVertex);//核心代码
                if (distance < mindistance)
                {
                    mindistance = distance;
                    findIndex = i;
                }
            }
            if (findIndex == -1 || mindistance > 5)
                MessageBox.Show("没有点或没有选中点");
            else MessageBox.Show(manualAddedFeatures[findIndex].getAttribute(0).ToString());
        }

        private void mBtnRefreshMap_Click(object sender, EventArgs e)
        {
            //从文本框获取边界
            double minX = Double.Parse(mTxbMinX.Text);
            double minY = Double.Parse(mTxbMinY.Text);
            double maxX = Double.Parse(mTxbMaxX.Text);
            double maxY = Double.Parse(mTxbMaxY.Text);
            view.Update(new GISExtent(maxY,minX,minY,maxX),ClientRectangle);//刷新view
            UpdateMap();
        }
        private void mBtnActions_Click(object sender, EventArgs e)
        {
            GISMapAction action = GISMapAction.zoomin;
            switch ((sender as Button).Tag)
            {
                case "mBtnZoomIn":
                    action = GISMapAction.zoomin;
                    break;
                case "mBtnZoomOut":
                    action = GISMapAction.zoomout;
                    break;
                case "mBtnMoveLeft":
                    action = GISMapAction.moveleft;
                    break;
                case "mBtnMoveRight":
                    action = GISMapAction.moveright;
                    break;
                case "mBtnMoveUp":
                    action = GISMapAction.moveup;
                    break;
                case "mBtnMoveDown":
                    action = GISMapAction.movedown;
                    break;
                default:
                    return;
            }
            view.ChangeView(action);
            UpdateMap();
        }

        private void UpdateMap()
        {
            //更新地图
            Graphics g = mPnlDrawArea.CreateGraphics();
            g.Clear(Color.White);//清屏
            //重新绘制点手动添加的点
            for (int i = 0; i < manualAddedFeatures.Count; i++)
            {
                manualAddedFeatures[i].draw(g, true, 0, view);
            }
            g.Dispose();
        }

        private void mBtnAddRandomPoints_Click(object sender, EventArgs e)
        {
            //生成100个随机点
            manualAddedFeatures.Clear();//清空点
            Random rand = new Random();
            double x = 0, y = 0;
            for (int i = 0; i < 100; i++)
            {
                GISAttribute attribute = new GISAttribute();
                attribute.AddValue(Convert.ToString(i));
                x = rand.NextDouble() * ClientRectangle.Width;
                y = rand.NextDouble() * ClientRectangle.Height;
                GISPoint point = new GISPoint(new GISVertex(x, y));
                manualAddedFeatures.Add(new GISFeature(point, attribute));
            }
            UpdateMap();
        }

        private void mBtnOpenPointFileDialog_Click(object sender, EventArgs e)
        {
            string filePath = @"D:\Swork\GIS开发\XGIS_Sample_Data\XGIS_Sample_Data\cities.shp";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = ".shp文件(*.shp*)|*.shp*";
            ofd.RestoreDirectory = true;//记住路径
            ofd.Title = "选取ShapeFile文件（.shp）";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
            }

            GISShapeFile shpFile = new GISShapeFile();
            layer = shpFile.ReadShapeFile(filePath);
            layer.drawAttributeOrNot = false;

            showAllSpatial();

            MessageBox.Show("读取了" + layer.FeatureCount() + "个点");
        }

        private void showAllSpatial()
        {
            view.UpdateExtent(layer.extent);
            UpdateMap();
        }

        private void mBtnShowAll_Click(object sender, EventArgs e)
        {
            showAllSpatial();
        }
    }
}
