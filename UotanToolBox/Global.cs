using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UotanToolBox
{
    public class Global
    {
        //Mindows工具箱信息
        public static string drivelink1 = "";
        public static string drivelink2 = "";
        public static string drivelink3 = "";
        public static string imglink = "";
        public static string device = "";//设备型号
        public static string datasizeunit = "";//data分区大小单位
        public static string datastartunit = "";//data分区起始点单位
        public static string dataendunit = "";//data分区结束点单位
        public static int datasize = 0;//data分区大小
        public static int datastart = 0;//data起始点
        public static int dataend = 0;//data结束点
        public static int winsize = 0;//win分区大小
        public static string wimpath = "";//wim镜像路径
        public static string moreability = "";//传递给MindowsTool要执行的功能
        public static int sdanum = 0;//Sda盘标号
        public static string winletter = "C";//Windows盘符
        public static int uefisum = 0;//UEFI盘符
        public static bool mksharepart = false;//是否创建共享分区
        public static int sharepartsize = 0;//共享分区大小

        //机型信息
        public static bool warn = false;//是否弹出适配警告
        public static string boot = "boot";//boot位置
        public static bool devcfg = false;//是否需要刷入devcfg
        public static bool vbmeta = false;//是否需要禁用vbmeta
        public static bool bootrec = false;//是否为临时启动Rec
        public static bool removelimit = false;//是否需要移动分区
        public static bool havedrv = true;//是否需要安装驱动
        public static bool issda = true;//大容量模式是sda还是Linux

        //分区表储存
        public static string sdatable = "";
        public static string sdbtable = "";
        public static string sdctable = "";
        public static string sddtable = "";
        public static string sdetable = "";
        public static string sdftable = "";
        public static string emmcrom = "";
    }
}
