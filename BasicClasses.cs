using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetryClassGIS
{
    class GISVertex
    {
        public double x;
        public double y;

        public GISVertex(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public double Distance(GISVertex anothervertex)
        {
            //计算两点距离
            return Math.Sqrt((anothervertex.x - x) * (anothervertex.x - x) + (anothervertex.y - y)*(anothervertex.y - y));    
        }
    }
    abstract class GISSpatial
    {
        //adj.空间的
        //抽象类，作为父类，用于构成不同的空间实体（点、线、面）的绘画方法
        public GISVertex centroid;//实体的中心坐标
        public GISExtent extent;//实体的边界

        public abstract void Draw(Graphics g,GISView view);//用于实现的抽象绘制方法
    }
    class GISFeature
    {
        //特征类:包含Spatial抽象类(实体)和Attribute属性类
        public GISSpatial spatialPart;
        public GISAttribute attributePart;

        public GISFeature(GISSpatial spatialPart, GISAttribute attributePart)
        {
            //构造一个特征类需要实体和属性
            this.spatialPart = spatialPart;
            this.attributePart = attributePart;
        }
        public void draw(Graphics g,bool DrawAttributeOrNot,int index,GISView view)
        {
            //绘制属性
            spatialPart.Draw(g,view);
            if(DrawAttributeOrNot)
                attributePart.draw(g,spatialPart.centroid,index,view);
        }
        public object getAttribute(int index)
        {
            //获取对应index的属性值
            return attributePart.Getvalue(index);
        }
    }
    class GISAttribute
    {
        ArrayList values = new ArrayList();//用于存储不同属性值函数

        //get、set方法
        public void AddValue(object o)
        {
            values.Add(o);
        }
        public Object Getvalue(int index)
        {
            return values[index];
        }

        public void draw(Graphics g,GISVertex location,int index,GISView view) {
        //绘制属性
            Point screenPoint = view.ToScreenPoint(location);
            g.DrawString(values[index].ToString(),
                new Font("宋体",20),
            new SolidBrush(Color.Black),
                screenPoint.X,screenPoint.Y);
        }
    }
    class GISExtent
    {
        //实体的边界，由左下、右上两个角点构成
        private GISVertex bottomLeft;
        private GISVertex topRight;

        public GISExtent(GISVertex bottomLeft, GISVertex topRight)
        {
            this.bottomLeft = bottomLeft;
            this.topRight = topRight;
        }
        public GISExtent(double bottom,double left,double top,double right)
        {
            this.bottomLeft = new GISVertex(left,bottom);
            this.topRight = new GISVertex(right,top);
        }

        //实现边界属性的查询
        public double getMinX()
        {
            return this.bottomLeft.x;
        }
        public double getMaxX()
        {
            return this.topRight.x;
        }
        public double getMinY()
        {
            return this.topRight.y;
        }
        public double getMaxY()
        {
            return this.bottomLeft.y;
        }
        public double getWidth()
        {
            return this.topRight.x - this.bottomLeft.x;
        }
        public double getHeight()
        {
            return this.bottomLeft.y - this.topRight.y;
        }
    }
    class GISPoint : GISSpatial
    {
        public GISPoint(GISVertex onevertex)
        {
            centroid = onevertex;
            extent = new GISExtent (onevertex,onevertex);
        }
        public override void Draw(Graphics g, GISView view)
        {
            Point screenPoint = view.ToScreenPoint(centroid);
            g.FillEllipse(new SolidBrush(Color.Red),
                new Rectangle(screenPoint.X - 3, screenPoint.Y - 3, 6, 6));
        }
        public double Distance(GISVertex anothervertex)
        {
            return centroid.Distance (anothervertex);
        }
    }
    class GISLine : GISSpatial
    {
        List<GISVertex> allVertices;
        public override void Draw(Graphics g, GISView view)
        {
        }
    }
    class GISPolygon : GISSpatial
    {
        List<GISVertex> allVertices;
        public override void Draw(Graphics g, GISView view)
        {
        }
    }
    class GISView
    {
        // 记录GISView属性
        GISExtent currentMapExtent;//当前显示的范围
        Rectangle mapWindowSize;//地图窗口边界
        double mapMinX, mapMinY;//地图
        double mapW, mapH;
        int winW, winH;//屏幕
        double scaleX,scaleY;//缩小比例

        public GISView(GISExtent currentMapExtent, Rectangle mapWindowSize)
        {
            //更新GISView属性
            Update(currentMapExtent, mapWindowSize);
        }

        public void Update(GISExtent currentMapExtent, Rectangle mapWindowSize)
        {
            this.currentMapExtent = currentMapExtent;
            this.mapWindowSize = mapWindowSize;
            this.mapMinX = currentMapExtent.getMinX();
            this.mapMinY = currentMapExtent.getMinY();
            this.mapW = currentMapExtent.getWidth();
            this.mapH = currentMapExtent.getHeight();
            this.winW = mapWindowSize.Width;
            this.winH = mapWindowSize.Height;
            this.scaleX = mapW / winW;
            this.scaleY = mapH / winH;
        }
        public Point ToScreenPoint(GISVertex oneVertex)
        {
            //将GISVertex点(地图)坐标转换为屏幕坐标
            double screenX = (oneVertex.x - mapMinX)/scaleX;
            double screenY = (oneVertex.y - mapMinY)/scaleY;
            return new Point((int)screenX, (int)screenY);
        }
        public GISVertex ToMapVertex(Point point)
        {
            //将屏幕坐标转换为地图GISVertex点坐标
            double MapX = scaleX * point.X + mapMinX;
            double MapY = scaleY * point.Y + mapMinY;
            return new GISVertex(MapX, MapY);
        }
    }
}
