using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Model
{
    public class WorkTime
    {
		private bool isMorning;
		/// <summary>
		/// 是否为早班
		/// </summary>
		public bool IsMorning
        {
			get { return isMorning; }
			set { isMorning = value; }
		}

		private int hours;
		/// <summary>
		/// 小时
		/// </summary>
		public int Hours
        {
			get { return hours; }
			set { hours = value; }
		}

		private int minutes;
		/// <summary>
		/// 分钟
		/// </summary>
		public int Minutes
		{
			get { return minutes; }
			set { minutes = value; }
		}

		private int seconds;
		/// <summary>
		/// 秒
		/// </summary>
		public int Seconds
		{
			get { return seconds; }
			set { seconds = value; }
		}

		private string statusName;
		/// <summary>
		/// 状态
		/// </summary>
		public string StatusName
		{
			get { return statusName; }
			set { statusName = value; }
		}


	}
}
