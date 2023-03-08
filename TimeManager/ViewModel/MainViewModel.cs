using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using TimeManager.Model;
using Brush = System.Windows.Media.Brush;

namespace TimeManager.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        #region Property
        private string nowStatus;
        /// <summary>
        /// 软件顶部文字：用于展示休息
        /// </summary>
        public string NowStatus
        {
            get { return nowStatus; }
            set { nowStatus = value; RaisePropertyChanged(); }
        }

        private string nowTimeSpan;
        /// <summary>
        /// 展示与软件顶部文字信息对应的倒计时
        /// </summary>
        public string NowTimeSpan
        {
            get { return nowTimeSpan; }
            set { nowTimeSpan = value; RaisePropertyChanged(); }
        }

        private string tipsInfo;
        /// <summary>
        /// 用于温馨提示文字
        /// </summary>
        public string TipsInfo
        {
            get { return tipsInfo; }
            set { tipsInfo = value; RaisePropertyChanged(); }
        }

        private Visibility showRest;
        /// <summary>
        /// 摸鱼功能的Visibility属性
        /// </summary>
        public Visibility ShowRest
        {
            get { return showRest; }
            set { showRest = value;RaisePropertyChanged(); }
        }

        private Visibility showCountDown;
        /// <summary>
        /// 摸鱼功能的Visibility属性
        /// </summary>
        public Visibility ShowCountDown
        {
            get { return showCountDown; }
            set { showCountDown = value; RaisePropertyChanged(); }
        }

        private Brush bgBrush;
        /// <summary>
        /// 统一字体颜色，使其跟随系统主题
        /// </summary>
        public Brush BgBrush
        {
            get { return bgBrush; }
            set { bgBrush = value; RaisePropertyChanged(); }
        }

        private bool isChecked;
        /// <summary>
        /// 区别早班(true)晚班(false)
        /// </summary>
        public bool IsChecked
        {
            get { return isChecked; }
            set { isChecked = value;RaisePropertyChanged(); }
        }

        private bool popIsOpen;
        /// <summary>
        /// 控制popup控件是否弹出
        /// </summary>
        public bool PopIsOpen
        {
            get { return popIsOpen; }
            set { popIsOpen = value; RaisePropertyChanged(); }
        }

        private string itemName;
        /// <summary>
        /// 自制类似combox控件的文本
        /// </summary>
        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; RaisePropertyChanged(); }
        }

        private string weekDay;
        /// <summary>
        /// 距离周末天数
        /// </summary>
        public string WeekDay
        {
            get { return timeManage.DistanceWeekDay()+"天"; }
            set { weekDay = value; RaisePropertyChanged(); }
        }

        private string endMonthDay;
        /// <summary>
        /// 距离月底天数
        /// </summary>
        public string EndMonthDay
        {
            get { return timeManage.DisTanceEndMonthDay()+"天"; }
            set { endMonthDay = value;RaisePropertyChanged(); }
        }

        private string paidDay;
        /// <summary>
        /// 距离发薪资的天数
        /// </summary>
        public string PaidDay
        {
            get { return timeManage.DistanceGetPaidDay();  }
            set { paidDay = value; RaisePropertyChanged(); }
        }

        private string festivalName;

        public string FestivalName
        {
            get { return timeManage.DistanceFestivalDay(true); }
            set { festivalName = value; RaisePropertyChanged(); }
        }


        private string festivalDay;
        /// <summary>
        /// 距离节假日天数
        /// </summary>
        public string FestivalDay
        {
            get { return timeManage.DistanceFestivalDay(false); }
            set { festivalDay = value; RaisePropertyChanged(); }
        }



        private ObservableCollection<HotSearch> hotSearches;
        /// <summary>
        /// 热搜榜信息集合
        /// </summary>
         public ObservableCollection<HotSearch> HotSearches
         {
            get { return hotSearches; }
            set { hotSearches = value;}
          }
        #endregion

        DispatcherTimer timer = new DispatcherTimer();
        TimeManage timeManage = new TimeManage();
        Dictionary<string, string> urlList;
        Dictionary<string, string[]> tipsInfoList;
        public MainViewModel()
        {
            HotSearches = new ObservableCollection<HotSearch>();
            //初始化属性
            IsChecked = true;
            ItemName = "微博";
            //热搜榜类型
            urlList = new Dictionary<string, string>
            {
                {"微博",@"https://api.gmit.vip/Api/WeiBoHot"},
                {"抖音",@"https://api.gmit.vip/Api/DouYinHot"},
                {"快手",@"https://api.gmit.vip/Api/KuaiShouHot"},
                {"知乎",@"https://api.gmit.vip/Api/ZhiHuHot"},
                {"哔哩哔哩",@"https://api.gmit.vip/Api/BiliBliHot"},
            };
            GetData("微博");
            //不同时刻的温馨提示(鸡汤)合集
            tipsInfoList = new Dictionary<string, string[]>
            {
                {"上班",new string[] { "犯困的话，喝杯咖啡吧", "上班啦！我猜你一定想下班吧", "今天也要努力摸y.......工作哦!", "无非就是换个地摸鱼，对吧" }},
                {"休息",new string[] { "现在是休息时间，好好休息吧！", "休息就别管工作的事啦", "又到了光明正大的摸鱼时间！", "有想好做点什么吗" } },
                {"休息结束", new string[] { "真快呀，就过去一半时间了！", "又到了思考晚饭吃啥的时间！", "加油！离下班还不远了", "还有不到4小时下班，坚持住！" }},
                {"下班",new string[]{ "是加班了吗？还是想我了呢？", "这么晚还在看我，怪害羞的", "别看我啦，记得早点休息哦", "工作了一天，休息休息吧" } },
                {"上班前", new string[] { "今天也要快乐的摸鱼哦^-^)*", "还没有上班哦，再休息一下吧", "快想想今天该怎么带薪摸鱼！", "早上好哦！昨晚有想我吗^-^" }}
            };
            ShowRest = Visibility.Collapsed;
            //实现颜色跟随系统主题
            BgBrush = SystemParameters.WindowGlassBrush;
            Microsoft.Win32.SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;
            //计时器
            timer.Tick += new EventHandler(TimerTick);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();

        }

        private void SystemEvents_UserPreferenceChanged(object sender, Microsoft.Win32.UserPreferenceChangedEventArgs e)
        {
            BgBrush = SystemParameters.WindowGlassBrush;
            HotSearches.ToList().ForEach(t => t.CountBrush = BgBrush);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            var restTime = timeManage.GetWorkTime(IsChecked, "开始休息");
            var endRestTime = timeManage.GetWorkTime(IsChecked, "结束休息");
            var workTime = timeManage.GetWorkTime(IsChecked, "上班");
            var endWorkTime = timeManage.GetWorkTime(IsChecked, "下班");
            DateTime nowtime;
            if (DateTime.Now < (nowtime = restTime) && DateTime.Now > workTime)
            {
                GetTipsInfo("上班", "距离休息还有");
            }
            else if (DateTime.Now < (nowtime = endRestTime) && DateTime.Now > restTime)
            {
                GetTipsInfo("休息", "距离休息结束还有");
            }
            else if (DateTime.Now < (nowtime = endWorkTime) && DateTime.Now > endRestTime)
            {
                GetTipsInfo("休息结束", "距离下班还有");
            }
            else
            {

                if (DateTime.Now.Hour <= workTime.Hour)
                    nowtime = workTime;
                else
                    nowtime = workTime.AddDays(1);
                //判断是下班后还是第二天早上
                if ((nowtime - DateTime.Now).Hours > workTime.Hour)
                {
                   
                    GetTipsInfo("下班", "距离上班还有");
                }
                else
                {
                    GetTipsInfo("上班前", "距离上班还有");
                }
            }
            TimeSpan timeSpan = nowtime - DateTime.Now;
            NowTimeSpan = $"{AddZero(timeSpan.Hours)}:{AddZero(timeSpan.Minutes)}:{AddZero(timeSpan.Seconds)}";

        }
        private int GetRandom() => new Random().Next(0, 4);
        /// <summary>
        /// 获取温馨提示和该时段的标题信息
        /// </summary>
        /// <param name="key">存放温馨提示语的字典的Key</param>
        /// <param name="status">标题</param>
        private void GetTipsInfo(string key, string status)
        {
            NowStatus = status;
            if (!tipsInfoList[key].Any(t => t == TipsInfo))
                TipsInfo = tipsInfoList[key][GetRandom()];
        }
        //补零
        private string AddZero(int num) => num < 10 ? "0" + num : num.ToString();
        #region Commands
        /// <summary>
        /// 打开视频网页
        /// </summary>
        public ICommand VideoCommand => new RelayCommand<string>(t=>OpenVideo(t));
        /// <summary>
        /// 用于控制摸鱼功能的显示与否
        /// </summary>
        public ICommand RestCommand => new RelayCommand(IsShowRest);
        /// <summary>
        /// 控制popup控件
        /// </summary>
        public ICommand OpenPopCommand => new RelayCommand(OpenPop);
        /// <summary>
        /// 查找对应的平台的热搜榜信息
        /// </summary>
        public ICommand SearchCommand => new RelayCommand<string>(t=>Search(t));
        /// <summary>
        /// 打开网址
        /// </summary>
        public ICommand OpenUrlCommand=>new RelayCommand<int>(t=>OpenUrl(t));
        /// <summary>
        /// 日期倒计时是否显示
        /// </summary>
        public ICommand CountDownCommand => new RelayCommand(IsShowCountDown);
        #endregion

        #region Command Functions
        public void OpenVideo(string name)
        {
            switch (name) 
            {
                case "tencent":
                    Process.Start(@"https://v.qq.com/");
                    break;
                case "mangGuo":
                    Process.Start(@"https://www.mgtv.com/");
                    break;
                default:
                    Process.Start(@"https://www.iqiyi.com/");
                    break;
            }
        }

        bool isRest=false;
        public void IsShowRest()
        {
            if (!isRest)
                ShowRest = Visibility.Visible;
            else
                ShowRest = Visibility.Collapsed;
            isRest = !isRest;
        }
        bool isCountDown = true;
        private void IsShowCountDown()
        {
            if (!isCountDown)
                ShowCountDown = Visibility.Visible;
            else
                ShowCountDown = Visibility.Collapsed;
            isCountDown = !isCountDown;
        }
        public void OpenPop() =>PopIsOpen=!PopIsOpen;

        public void Search(string key)
        {
           ItemName= key;
           HotSearches.Clear();
            GetData(key);
            OpenPop();
        }
        public async void GetData(string key)
        {
            int num = 1;
            HttpRequest request = new HttpRequest();
            var data = await request.Get(urlList[key]);
            if (data != null)
            {
                var Search = JsonConvert.DeserializeObject<JsonInfo>(data);
                foreach (var item in Search.Data)
                {
                    HotSearches.Add(new HotSearch()
                    {
                        Count = num++,
                        Hot = item.Hot,
                        Title = item.Title,
                        Updatetime = item.Updatetime,
                        Url = item.Url,
                        CountBrush = BgBrush
                    });
                }
            }
        }

        private void OpenUrl(int count)
        {
            Process.Start(HotSearches[count].Url);
        }
        #endregion
    }
}