using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Model
{
    public class TimeManage
    {
        public TimeManage() 
        {
            InitWorkTimes();
            InitFestivalsDay();
        }

        BindingList<WorkTime> workTimes;
        Dictionary<string, DateTime> festivalsDay;
        private void InitWorkTimes()
        {
            workTimes = new BindingList<WorkTime>
            {
                //早班
                new WorkTime() { IsMorning = true, StatusName = "上班", Hours = 8, Minutes = 30, Seconds = 0 },
                new WorkTime() { IsMorning = true, StatusName = "开始休息", Hours = 12, Minutes = 0, Seconds = 0 },
                new WorkTime() { IsMorning = true, StatusName = "结束休息", Hours = 13, Minutes = 30, Seconds = 0 },
                new WorkTime() { IsMorning = true, StatusName = "下班", Hours = 18, Minutes = 00, Seconds = 0 },
                //晚班
                new WorkTime() { IsMorning = false, StatusName = "上班", Hours = 13, Minutes = 30, Seconds = 0 },
                new WorkTime() { IsMorning = false, StatusName = "开始休息", Hours = 18, Minutes = 0, Seconds = 0 },
                new WorkTime() { IsMorning = false, StatusName = "结束休息", Hours = 18, Minutes = 30, Seconds = 0 },
                new WorkTime() { IsMorning = false, StatusName = "下班", Hours = 21, Minutes = 30, Seconds = 0 }
            };
        }

        private void InitFestivalsDay()
        {
            festivalsDay = new Dictionary<string, DateTime>();
            festivalsDay.Add("妇女",new DateTime(year:DateTime.Now.Year,month:3,day:8)) ;
            festivalsDay.Add("植树", new DateTime(year: DateTime.Now.Year, month: 3, day: 12));
            festivalsDay.Add("愚人", new DateTime(year: DateTime.Now.Year, month: 4, day: 1));
            festivalsDay.Add("清明", new DateTime(year: DateTime.Now.Year, month: 4, day: 5));
            festivalsDay.Add("劳动", new DateTime(year: DateTime.Now.Year, month: 5, day: 1));
            festivalsDay.Add("母亲", new DateTime(year: DateTime.Now.Year, month: 5, day: 14));
            festivalsDay.Add("儿童", new DateTime(year: DateTime.Now.Year, month: 6, day: 1));
            festivalsDay.Add("父亲", new DateTime(year: DateTime.Now.Year, month: 5, day: 18));
            festivalsDay.Add("端午", new DateTime(year: DateTime.Now.Year, month: 5, day: 22));
            festivalsDay.Add("七夕", new DateTime(year: DateTime.Now.Year, month: 8, day:22));
            festivalsDay.Add("中元", new DateTime(year: DateTime.Now.Year, month: 8, day: 30));
            //有需求自行按上方样式添加（注：节日名称建议格式：不超过两个字   ）
        }
        /// <summary>
        /// 初始化发薪资日期
        /// </summary>
        /// <returns></returns>
        private DateTime InitPaidDay() => new DateTime(year: DateTime.Now.Year, month: DateTime.Now.Month, day: 1);//day设置数值建议不超过28

        #region 给外部调用的方法
        public DateTime GetWorkTime(bool ismorning, string status)
        {
            var work = workTimes.Single(t => t.StatusName == status && t.IsMorning == ismorning);
            return DateTime.Now.Date.AddHours(work.Hours).AddMinutes(work.Minutes).AddSeconds(work.Seconds);
        }
        /// <summary>
        /// 返回距离最近的节日天数或节日名称
        /// </summary>
        /// <param name="isName">是否返回节日名称</param>
        /// <returns></returns>
        public string DistanceFestivalDay(bool isName)
        {
            int day = 0;
            int year = 0;
            string name;
            day = GetFestivalsDay(day, year,out name);
            //如果今年节日已过完，则获取第二年的节日
            if (day == 0)
            {
                year++;
                day = GetFestivalsDay(day, year,out name);
            }
            return isName?name:day+"天";

        }
        private int GetFestivalsDay(int day, int year,out string name)
        {
            string festival="";
            foreach (var key in festivalsDay.Keys)
            {
                if (festivalsDay[key] > DateTime.Now)
                {
                    festival = key;
                    day = (festivalsDay[key] - DateTime.Now).Days;
                    break;
                }
            }
            name = festival;
            return day+1;
        }
        /// <summary>
        /// 距离周末时间
        /// </summary>
        /// <returns></returns>
        public int DistanceWeekDay() 
        {
            var week = (int)DateTime.Now.DayOfWeek;
            int day = 0;
            if (!(week == 0 || week == 6))
                day = 6 - week;
            return day;
        }
        /// <summary>
        /// 距离发工资时间
        /// </summary>
        /// <returns></returns>
        public string DistanceGetPaidDay()
        {
            //var paidDay=InitPaidDay();
            //if (paidDay.Date >= DateTime.Now.Date)
            //    return (paidDay - DateTime.Now.Date).Days + "天";
            //else
            //    return (paidDay.AddMonths(1) - DateTime.Now.Date).Days + "天";
            return DateTime.Now.DayOfWeek.ToString().Substring(0,3);
        }
        /// <summary>
        /// 距离月底时间
        /// </summary>
        /// <returns></returns>
        public int DisTanceEndMonthDay()
        {
            return DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)-DateTime.Now.Day;
        }
        #endregion
    }
}
