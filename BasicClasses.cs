using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    class GISPoint
    {
        //第一章仅实现点属性、位置的输入、显示、查询
        public GISVertex location;
        public string attribute;
        //构造函数
        public GISPoint(GISVertex onevertex,string onestring)
        {
            location = onevertex;
            attribute = onestring; 
        }
        //绘制点
        public void DrawPoint(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Red),
                new Rectangle((int)(location.x - 3), (int)(location.y - 3), 6, 6));
        }
        //绘制属性
        public void DrawAttribute(Graphics g) { 
        g.DrawString(attribute,new Font("宋体",15),
            new SolidBrush(Color.Black),
            new PointF((int)(location.x), (int)location.y));
        }
        public double Distance(GISVertex anothervertex)
        {
            return location.Distance(anothervertex);
        }
    }
    class GISLine
    {
        List<GISVertex> AllVertexes;
    }
    class GISPolygon
    {
        List<GISVertex> AllVertexes;
    }
}
