using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
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
        public void CopyFrom(GISVertex vertex)
        {
            x = vertex.x;
            y = vertex.y;
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
        
        private double zoomingFactor = 1.5;//地图的放大值,默认为1.5
        private double movingFactor = 0.2;//地图的移动值,默认为0.2

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

        //修改边界
        public void ChangeExtent(GISMapAction action)
        {
            double newMinX = bottomLeft.x;
            double newMaxX = topRight.x;
            double newMinY = topRight.y;
            double newMaxY = bottomLeft.y;
            switch (action)
            {
                case GISMapAction.zoomin:
                    newMinX = (getMinX() + getMaxX() - getWidth() / zoomingFactor) / 2;
                    newMaxX = (getMinX() + getMaxX() + getWidth() / zoomingFactor) / 2;
                    newMinY = (getMinY() + getMaxY() - getWidth() / zoomingFactor) / 2;
                    newMaxY = (getMinY() + getMaxY() + getWidth() / zoomingFactor) / 2;
                    break;
                case GISMapAction.zoomout:
                    newMinX = (getMinX() + getMaxX() - getWidth() * zoomingFactor) / 2;
                    newMaxX = (getMinX() + getMaxX() + getWidth() * zoomingFactor) / 2;
                    newMinY = (getMinY() + getMaxY() - getWidth() * zoomingFactor) / 2;
                    newMaxY = (getMinY() + getMaxY() + getWidth() * zoomingFactor) / 2;
                    break;
                case GISMapAction.moveup:
                    newMinY -= getHeight() * movingFactor;
                    newMaxY -= getHeight() * movingFactor;
                    break;
                case GISMapAction.movedown:
                    newMinY += getHeight() * movingFactor;
                    newMaxY += getHeight() * movingFactor;
                    break;
                case GISMapAction.moveleft:
                    newMinX -= getWidth() * movingFactor;
                    newMaxX -= getWidth() * movingFactor;
                    break;
                case GISMapAction.moveright:
                    newMinX += getWidth() * movingFactor;
                    newMaxX += getWidth() * movingFactor;
                    break;
            }
            bottomLeft.y = newMaxY;
            bottomLeft.x = newMinX;
            topRight.y = newMinY;
            topRight.x = newMaxX;
        }

        public void SetZoomingFactor(double zoomingFactor)
        {
            //设置缩小指数
            this.zoomingFactor = zoomingFactor;
        }
        public void SetMovingFactor(double movingFactor)
        {
            //设置移动指数
            this.movingFactor = movingFactor;
        }
        public void CopyFrom(GISExtent extent)
        {
            topRight.CopyFrom(extent.topRight);
            bottomLeft.CopyFrom(extent.bottomLeft);
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
        public void ChangeView(GISMapAction action)
        {
            currentMapExtent.ChangeExtent(action);
            Update(currentMapExtent,mapWindowSize);
        }

        public void UpdateExtent(GISExtent extent)
        {
            currentMapExtent.CopyFrom(extent);
            Update(currentMapExtent,mapWindowSize);
        }
    }
    enum GISMapAction
    {
        //移动操作的枚举类型
        zoomin, zoomout,moveup,movedown,moveleft,moveright
    };
    /// <summary>
    /// 读取Shapefile文件,可以用来显示在GISLayer中
    /// </summary>
    class GISShapeFile
    {
        //用于读取shapefile文件
        [StructLayout(LayoutKind.Sequential,Pack = 4)]
        struct ShapeFileHeader
        {
            //定义文件头的结构体
            public int Unused1, Unused2, Unused3, Unused4, Unused5, Unused6, Unused7;//Big Integer无实际意义
            public int Unused8;//Little Integer版本号
            public int ShapeType;//Little Integer空间对象类型
            public double Xmin,Ymin, Xmax, Ymax;//Little Double文件中所有空间对象的四个角点
            public double Unused9, Unused10, Unused11, Unused12;//Little Double二维数据不涉及的数据项
        }
        [StructLayout (LayoutKind.Sequential,Pack = 4)]
        struct RecordHeader
        {
            //定义数据体部分的文件头结构体
            public int RecordNumber;//Big Integer记录的序号，是顺序生成的
            public int RecordLength;//Big Integer记录内容的字(双字节)数，包括了下一个表文件类型的ShapeType,读到a长度,实际长度为a*2-4
            public int ShapeType;//Little Integer表记录的空间类型，重复了文件头的ShapeType
        }
        ShapeFileHeader ReadFileHeadr(BinaryReader br)
        {
            //获取文件的Header
            //获取文件头位置和大小 -> 将文件头打包成struct类型数据 -> 释放handle占用的资源
            byte[] buff = br.ReadBytes(Marshal.SizeOf(typeof(ShapeFileHeader)));//获取文件头长度的字节组，buff数据类型为二进制byte[]
            GCHandle handle = GCHandle.Alloc(buff, GCHandleType.Pinned);//为buff对象分配Pinned类型(防止垃圾回收)的handle
            ShapeFileHeader header = (ShapeFileHeader)Marshal.PtrToStructure//将指针指向的数据封送为托管类型（Structure）
                (handle.AddrOfPinnedObject(), typeof(ShapeFileHeader));//提供参数为：指针指向的地址、需要转换成的类型
            handle.Free();//释放handle
            return header;
        }
        RecordHeader ReadRecordHeader(BinaryReader br)
        {
            //获取记录的Header
            //与获取文件头相似
            byte[] buff = br.ReadBytes(Marshal.SizeOf(typeof(RecordHeader)));
            GCHandle handle = GCHandle.Alloc(buff, GCHandleType.Pinned);
            RecordHeader header = (RecordHeader)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(RecordHeader));
            handle.Free();//释放handle
            return header;
        }
        public GISLayer ReadShapeFile(string shpFileName)
        {
            FileStream fsr = new FileStream(shpFileName, FileMode.Open);//获取文件流
            BinaryReader br = new BinaryReader(fsr);//读取文件流的二进制数据
            ShapeFileHeader sfh = ReadFileHeadr (br);//从二进制数据获取文件头
            ShapeType shapeType = (ShapeType)Enum.Parse(typeof(ShapeType), sfh.ShapeType.ToString());//对应文件类型的枚举，获取文件类型数据
            GISExtent extent = new GISExtent(sfh.Ymax, sfh.Xmin, sfh.Ymin, sfh.Xmax);//从文件头中获取空间对象的边界
            GISLayer layer = new GISLayer(shpFileName,shapeType, extent);//定义绘制的图层
            // TODO 怎么获取到记录数据的起点的？======================================
            while (br.PeekChar() != -1)//br中没有可用字符或流不支持查找时返回-1
            {
                RecordHeader rh = ReadRecordHeader (br);//读取记录的文件
                int recordLength = FromBigToLittle(rh.RecordLength) * 2 - 4;//计算在记录中存储有效信息的字节数
                byte[] recordContent = br.ReadBytes(recordLength);//用字节组存储记录
                if (shapeType == ShapeType.point) //当文件类型为点时
                {
                    GISPoint onePoint = ReadPoint(recordContent);//获取一条记录中的点
                    GISFeature oneFeature = new GISFeature(onePoint,new GISAttribute());//构成Feature(还没读取属性数据)
                    layer.AddFeature(oneFeature);//向图层添加实体
                }
            }
            br.Close();//关闭二进制读取器，归还文件的操作权限
            fsr.Close();//关闭文件流，归还文件的操作权限
            return layer;
        }

        private GISPoint ReadPoint(byte[] recordContent)
        {
            //读取文件的点数据
            double x = BitConverter.ToDouble(recordContent, 0);//Little Double 横坐标
            double y = BitConverter.ToDouble(recordContent, 8);//Little Double 纵坐标
            return new GISPoint(new GISVertex(x, y));
        }

        int FromBigToLittle(int bigIntegerValue)
        {
            //转换Big Integer到Little Integer
            byte[] bigBytes = new byte[4];//获取BigInteger
            GCHandle handle = GCHandle.Alloc(bigBytes, GCHandleType.Pinned);//分配GCHandle
            Marshal.StructureToPtr(bigIntegerValue,handle.AddrOfPinnedObject(),false);//将数据体转换为指针
            handle.Free();//释放handle
            // TODO bigInteger和littleInteger的区别？======================================
            byte b2 = bigBytes[2];//进行数据交换
            byte b3 = bigBytes[3];
            bigBytes[3] = bigBytes[0];
            bigBytes[2] = bigBytes[1];
            bigBytes[1] = b2;
            bigBytes[0] = b3;
            return BitConverter.ToInt32(bigBytes,0);//将byte数据转换为int 32
        }
    }
    class GISLayer
    {
        //定义图层
        public string name;
        public GISExtent extent;
        public bool drawAttributeOrNot;
        public int labelIndex;//需要绘制的属性在GISAttribute中是第几个
        public ShapeType shapeType;
        List<GISFeature> features = new List<GISFeature>();

        /// <summary>
        /// 图层类，用于绘制实体
        /// </summary>
        /// <param name="name">图层的名称</param>
        /// <param name="shapeType">图层包含的实体类型</param>
        /// <param name="extent">图层边界</param>
        public GISLayer(string name,ShapeType shapeType,GISExtent extent)
        {
            //构造
            this.name = name;
            this.shapeType = shapeType;
            this.extent = extent;
        }

        public void draw(Graphics g,GISView view)
        {
            //绘制图层
            for (int i = 0; i < features.Count; i++)
                features[i].draw(g,drawAttributeOrNot,labelIndex,view);
        }

        /// <summary>
        /// 向layer添加实体
        /// </summary>
        public void AddFeature(GISFeature feature)
        {
            features.Add(feature);
        }

        /// <summary>
        /// 获取layer中实体的数量
        /// </summary>
        public int FeatureCount()
        {
            return features.Count;
        }
    }
    enum ShapeType
    {
        //从文件头读取的文件类型
        point = 1,
        line = 3,
        polygon = 5
    };
}
