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
        /// ����������֣�����չʾ��Ϣ
        /// </summary>
        public string NowStatus
        {
            get { return nowStatus; }
            set { nowStatus = value; RaisePropertyChanged(); }
        }

        private string nowTimeSpan;
        /// <summary>
        /// չʾ���������������Ϣ��Ӧ�ĵ���ʱ
        /// </summary>
        public string NowTimeSpan
        {
            get { return nowTimeSpan; }
            set { nowTimeSpan = value; RaisePropertyChanged(); }
        }

        private string tipsInfo;
        /// <summary>
        /// ������ܰ��ʾ����
        /// </summary>
        public string TipsInfo
        {
            get { return tipsInfo; }
            set { tipsInfo = value; RaisePropertyChanged(); }
        }

        private Visibility showRest;
        /// <summary>
        /// ���㹦�ܵ�Visibility����
        /// </summary>
        public Visibility ShowRest
        {
            get { return showRest; }
            set { showRest = value;RaisePropertyChanged(); }
        }

        private Visibility showCountDown;
        /// <summary>
        /// ���㹦�ܵ�Visibility����
        /// </summary>
        public Visibility ShowCountDown
        {
            get { return showCountDown; }
            set { showCountDown = value; RaisePropertyChanged(); }
        }

        private Brush bgBrush;
        /// <summary>
        /// ͳһ������ɫ��ʹ�����ϵͳ����
        /// </summary>
        public Brush BgBrush
        {
            get { return bgBrush; }
            set { bgBrush = value; RaisePropertyChanged(); }
        }

        private bool isChecked;
        /// <summary>
        /// �������(true)���(false)
        /// </summary>
        public bool IsChecked
        {
            get { return isChecked; }
            set { isChecked = value;RaisePropertyChanged(); }
        }

        private bool popIsOpen;
        /// <summary>
        /// ����popup�ؼ��Ƿ񵯳�
        /// </summary>
        public bool PopIsOpen
        {
            get { return popIsOpen; }
            set { popIsOpen = value; RaisePropertyChanged(); }
        }

        private string itemName;
        /// <summary>
        /// ��������combox�ؼ����ı�
        /// </summary>
        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; RaisePropertyChanged(); }
        }

        private string weekDay;
        /// <summary>
        /// ������ĩ����
        /// </summary>
        public string WeekDay
        {
            get { return timeManage.DistanceWeekDay()+"��"; }
            set { weekDay = value; RaisePropertyChanged(); }
        }

        private string endMonthDay;
        /// <summary>
        /// �����µ�����
        /// </summary>
        public string EndMonthDay
        {
            get { return timeManage.DisTanceEndMonthDay()+"��"; }
            set { endMonthDay = value;RaisePropertyChanged(); }
        }

        private string paidDay;
        /// <summary>
        /// ���뷢н�ʵ�����
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
        /// ����ڼ�������
        /// </summary>
        public string FestivalDay
        {
            get { return timeManage.DistanceFestivalDay(false); }
            set { festivalDay = value; RaisePropertyChanged(); }
        }



        private ObservableCollection<HotSearch> hotSearches;
        /// <summary>
        /// ���Ѱ���Ϣ����
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
            //��ʼ������
            IsChecked = true;
            ItemName = "΢��";
            //���Ѱ�����
            urlList = new Dictionary<string, string>
            {
                {"΢��",@"https://api.gmit.vip/Api/WeiBoHot"},
                {"����",@"https://api.gmit.vip/Api/DouYinHot"},
                {"����",@"https://api.gmit.vip/Api/KuaiShouHot"},
                {"֪��",@"https://api.gmit.vip/Api/ZhiHuHot"},
                {"��������",@"https://api.gmit.vip/Api/BiliBliHot"},
            };
            GetData("΢��");
            //��ͬʱ�̵���ܰ��ʾ(����)�ϼ�
            tipsInfoList = new Dictionary<string, string[]>
            {
                {"�ϰ�",new string[] { "�����Ļ����ȱ����Ȱ�", "�ϰ������Ҳ���һ�����°��", "����ҲҪŬ����y.......����Ŷ!", "�޷Ǿ��ǻ��������㣬�԰�" }},
                {"��Ϣ",new string[] { "��������Ϣʱ�䣬�ú���Ϣ�ɣ�", "��Ϣ�ͱ�ܹ���������", "�ֵ��˹������������ʱ�䣡", "���������ʲô��" } },
                {"��Ϣ����", new string[] { "���ѽ���͹�ȥһ��ʱ���ˣ�", "�ֵ���˼������ɶ��ʱ�䣡", "���ͣ����°໹��Զ��", "���в���4Сʱ�°࣬���ס��" }},
                {"�°�",new string[]{ "�ǼӰ����𣿻����������أ�", "��ô���ڿ��ң��ֺ��ߵ�", "���������ǵ������ϢŶ", "������һ�죬��Ϣ��Ϣ��" } },
                {"�ϰ�ǰ", new string[] { "����ҲҪ���ֵ�����Ŷ^-^)*", "��û���ϰ�Ŷ������Ϣһ�°�", "������������ô��н���㣡", "���Ϻ�Ŷ��������������^-^" }}
            };
            ShowRest = Visibility.Collapsed;
            //ʵ����ɫ����ϵͳ����
            BgBrush = SystemParameters.WindowGlassBrush;
            Microsoft.Win32.SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;
            //��ʱ��
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
            var restTime = timeManage.GetWorkTime(IsChecked, "��ʼ��Ϣ");
            var endRestTime = timeManage.GetWorkTime(IsChecked, "������Ϣ");
            var workTime = timeManage.GetWorkTime(IsChecked, "�ϰ�");
            var endWorkTime = timeManage.GetWorkTime(IsChecked, "�°�");
            DateTime nowtime;
            if (DateTime.Now < (nowtime = restTime) && DateTime.Now > workTime)
            {
                GetTipsInfo("�ϰ�", "������Ϣ����");
            }
            else if (DateTime.Now < (nowtime = endRestTime) && DateTime.Now > restTime)
            {
                GetTipsInfo("��Ϣ", "������Ϣ��������");
            }
            else if (DateTime.Now < (nowtime = endWorkTime) && DateTime.Now > endRestTime)
            {
                GetTipsInfo("��Ϣ����", "�����°໹��");
            }
            else
            {

                if (DateTime.Now.Hour <= workTime.Hour)
                    nowtime = workTime;
                else
                    nowtime = workTime.AddDays(1);
                //�ж����°���ǵڶ�������
                if ((nowtime - DateTime.Now).Hours > workTime.Hour)
                {
                   
                    GetTipsInfo("�°�", "�����ϰ໹��");
                }
                else
                {
                    GetTipsInfo("�ϰ�ǰ", "�����ϰ໹��");
                }
            }
            TimeSpan timeSpan = nowtime - DateTime.Now;
            NowTimeSpan = $"{AddZero(timeSpan.Hours)}:{AddZero(timeSpan.Minutes)}:{AddZero(timeSpan.Seconds)}";

        }
        private int GetRandom() => new Random().Next(0, 4);
        /// <summary>
        /// ��ȡ��ܰ��ʾ�͸�ʱ�εı�����Ϣ
        /// </summary>
        /// <param name="key">�����ܰ��ʾ����ֵ��Key</param>
        /// <param name="status">����</param>
        private void GetTipsInfo(string key, string status)
        {
            NowStatus = status;
            if (!tipsInfoList[key].Any(t => t == TipsInfo))
                TipsInfo = tipsInfoList[key][GetRandom()];
        }
        //����
        private string AddZero(int num) => num < 10 ? "0" + num : num.ToString();
        #region Commands
        /// <summary>
        /// ����Ƶ��ҳ
        /// </summary>
        public ICommand VideoCommand => new RelayCommand<string>(t=>OpenVideo(t));
        /// <summary>
        /// ���ڿ������㹦�ܵ���ʾ���
        /// </summary>
        public ICommand RestCommand => new RelayCommand(IsShowRest);
        /// <summary>
        /// ����popup�ؼ�
        /// </summary>
        public ICommand OpenPopCommand => new RelayCommand(OpenPop);
        /// <summary>
        /// ���Ҷ�Ӧ��ƽ̨�����Ѱ���Ϣ
        /// </summary>
        public ICommand SearchCommand => new RelayCommand<string>(t=>Search(t));
        /// <summary>
        /// ����ַ
        /// </summary>
        public ICommand OpenUrlCommand=>new RelayCommand<int>(t=>OpenUrl(t));
        /// <summary>
        /// ���ڵ���ʱ�Ƿ���ʾ
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