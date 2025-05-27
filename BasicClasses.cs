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

        public abstract void Draw(Graphics g);//用于实现的抽象绘制方法
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
        public void draw(Graphics g,bool DrawAttributeOrNot,int index)
        {
            //绘制属性
            spatialPart.Draw(g);
            if(DrawAttributeOrNot)
                attributePart.draw(g,spatialPart.centroid,index);
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

        public void draw(Graphics g,GISVertex location,int index) {
        //绘制属性
            g.DrawString(values[index].ToString(),
                new Font("宋体",20),
            new SolidBrush(Color.Black),
                (int)location.x,(int)location.y);
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
    }
    class GISPoint : GISSpatial
    {
        public GISPoint(GISVertex onevertex)
        {
            centroid = onevertex;
            extent = new GISExtent (onevertex,onevertex);
        }
        public override void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Red),
                new Rectangle((int)centroid.x - 3, (int)centroid.y - 3, 6, 6));
        }
        public double Distance(GISVertex anothervertex)
        {
            return centroid.Distance (anothervertex);
        }
    }
    class GISLine : GISSpatial
    {
        List<GISVertex> allVertices;
        public override void Draw(Graphics g)
    {
        }
    }
    class GISPolygon : GISSpatial
    {
        List<GISVertex> allVertices;
        public override void Draw(Graphics g)
    {
        }
    }
}
