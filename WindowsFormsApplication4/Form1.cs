using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public HTuple hv_AcqHandle = null;//定义相机句柄
        public   HObject img = null;//定义图像变量
        HalconDotNet.HalconAPI.HFramegrabberCallback delegateCallback;//定义一个委托
        private void Form1_Load(object sender, EventArgs e)//窗体加载的时候委托绑定及开启相机等操作
        {
            //hSmartWindowControl1.MouseWheel += this.hSmartWindowControl1.HSmartWindowControl_MouseWheel;//注册控件滚轮事件,该控件双击自适应显示
            try
            {
               
                //给委托绑定
                delegateCallback = MyCallbackFunction;
                //开启相机
                HOperatorSet.OpenFramegrabber("GigEVision2", 0, 0, 0, 0, 0, 0, "progressive",
           -1, "default", -1, "false", "default", "A1", 0, -1, out hv_AcqHandle);//GigEVision2表示接口类型，Mv1表示相机名，不要用海康提供的第三方接口MVision（不支持回调)
                HOperatorSet.SetFramegrabberParam(hv_AcqHandle, "TriggerMode", "On");//硬件触发开
                HOperatorSet.SetFramegrabberParam(hv_AcqHandle, "AcquisitionMode", "SingleFrame");//采集模式，单帧模式
                HOperatorSet.SetFramegrabberParam(hv_AcqHandle, "TriggerSource", "Line1");//触发线为Line0
                //HOperatorSet.SetFramegrabberParam(hv_AcqHandle, "ExposureTime", 5000.0);//曝光时间
                //HOperatorSet.SetFramegrabberParam(hv_AcqHandle, "ExposureAuto", "Off");//关闭自动曝光
                // HOperatorSet.SetFramegrabberParam(hv_AcqHandle, "EventSelector", "ExposureEnd");//选择曝光结束事件有效---这里要和注册时的名字一致（如"EventExposureEnd")
                HOperatorSet.SetFramegrabberParam(hv_AcqHandle, "EventSelector", "Line1RisingEdge");//选择上升沿事件有效---这里要和注册时的名字一致（如"EventLine0RisingEdge")
                HOperatorSet.SetFramegrabberParam(hv_AcqHandle, "EventNotification", "On");//事件通知开关打开
                //HOperatorSet.SetFramegrabberParam(hv_AcqHandle, "grab_timeout", 5000);//采集超时时间---因为海康的暂时不支持EventExposureEnd，事件触发的时候图像还没有准备好，超时时间要设置较长
                HOperatorSet.SetFramegrabberParam(hv_AcqHandle, "grab_timeout", -1);//永不超时
               // HOperatorSet.GrabImageStart(hv_AcqHandle, -1);//异步采集开启
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);//在输出命令符窗口输出错误消息
                try
                {
                    HOperatorSet.CloseFramegrabber(hv_AcqHandle);
                }
                catch (Exception)
                {

                   
                }
               
            }
         
        }
        private int test = 1;//随便定义的一个变量，后面会取其地址带入回调函数的user_context
       
        public  int MyCallbackFunction(IntPtr handle, IntPtr context, IntPtr user_context)//回调函数
        {
            try
            {
               // HOperatorSet.GrabImageAsync(out img, hv_AcqHandle, -1);//异步采集一帧
                HOperatorSet.GrabImage(out img, hv_AcqHandle);//这里是同步采集一帧
                if (this.hSmartWindowControl1.InvokeRequired)//线程亲和性判定
                {
                    this.Invoke(new MethodInvoker(() => { HOperatorSet.DispObj(img, this.hSmartWindowControl1.HalconWindow); img.Dispose(); }));//把图像显示出来（这里是委托方式显示)
                }
                else
                {
                    HOperatorSet.DispObj(img, this.hSmartWindowControl1.HalconWindow);//把图像显示出来
                    img.Dispose();
                }
                return 0;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);//在输出命令符窗口输出错误消息
                return -1;
            }
          
        }
        private void btnReg_Click(object sender, EventArgs e)//这里注册回调
        {
            try
            {
                IntPtr ptr = Marshal.GetFunctionPointerForDelegate(delegateCallback);//取回调函数的地址
                IntPtr ptr1 = GCHandle.Alloc(test, GCHandleType.Pinned).AddrOfPinnedObject();//取test变量的地址
                //Marshal.GetDelegateForFunctionPointer(ptr, typeof(HalconDotNet.HalconAPI.HFramegrabberCallback));
                //因为Basler的相机不支持"transfer_end"等模式，查询了下支持 "ExposureEnd"作演示
                //EventExposureEnd事件海康的需要调用HOperatorSet.GrabImage后才能触发，不满足要求，所以这里选择EventLine0RisingEdge测试，后续也许海康会升级Fw对应
                //异步采集支持EventExposureEnd
                //HOperatorSet.SetFramegrabberCallback(hv_AcqHandle, "EventExposureEnd", ptr, ptr1);//注册回调函数--这里与前面的"EventSelector"对应的要多Event前缀，海康的这样的
                HOperatorSet.SetFramegrabberCallback(hv_AcqHandle, "EventLine1RisingEdge", ptr, ptr1);//注册回调函数--这里与前面的"EventSelector"对应的要多Event前缀，海康的这样的
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);//在输出命令符窗口输出错误消息
                try
                {
                    HOperatorSet.CloseFramegrabber(hv_AcqHandle);
                }
                catch (Exception)
                {


                }
            }
        }
        private void btnGetPara_Click(object sender, EventArgs e)//返回支持available_callback_types的列表参数
        {
            try
            {
                HTuple Value = null;
                //下面返回支持回调的列表
                HOperatorSet.GetFramegrabberParam(hv_AcqHandle, "available_callback_types", out Value);
                int l = Value.Length;
                for (long i = 0; i < l; i++)
                {
                    this.listBox1.Items.Add(Value[i].S);
                }
            }
            catch (Exception ex)
            {

                Trace.WriteLine(ex.Message);//在输出命令符窗口输出错误消息
            }
          
         }
        private void btnCloseCamera_Click(object sender, EventArgs e)//关闭相机
        {
            if (hv_AcqHandle == null) return;
            HOperatorSet.CloseFramegrabber(hv_AcqHandle);
        }
        public static void Delay(double t)//精确延时
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Restart();
            while (stopWatch.Elapsed.TotalMilliseconds < t)
            {
                Application.DoEvents();
            }
        }
        //-------以下是循环方式采集图像--------------------------------------
        private bool exitloop = false;//推出循环命令
        private void btnLoop_Click(object sender, EventArgs e)//采用循环的方式去取图
        {
            exitloop = false;
            btnExitLoop.Focus();
            Delay(50);
            while(exitloop==false)
            {
                Application.DoEvents();
                try
                {
                      HOperatorSet.GrabImage(out img, hv_AcqHandle);
                      HOperatorSet.DispObj(img, this.hSmartWindowControl1.HalconWindow);
                      Delay(50);
                   
                }
                catch (Exception)
                {
                    Delay(50);
                    continue;
                }
            }
            MessageBox.Show("退出了");
        }

        private void btnExitLoop_Click(object sender, EventArgs e)//退出循环
        {
            exitloop = true;
        }
        private void hSmartWindowControl1_Load(object sender, EventArgs e)
        {
           

        }
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = "";
            for(int i=0;i<listBox1.Items.Count;i++)
            {
                str += listBox1.Items[i] + "\r\n";
            }
            System.IO.File.WriteAllText("D:\\test\\txt.txt", str);
        }
    }
}
