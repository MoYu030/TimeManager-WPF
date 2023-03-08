using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TimeManager.Model
{
    public class HotSearch:ViewModelBase
    {
		private int count;

		public int Count
		{
			get { return count; }
			set { count = value;RaisePropertyChanged(); }
		}


		private string title;

		public string Title
		{
			get { return title; }
			set { title = value; RaisePropertyChanged(); }
		}

		private string hot;

		public string Hot
		{
			get { return hot; }
			set { hot = value; RaisePropertyChanged(); }
		}

		private string url;

		public string Url
		{
			get { return url; }
			set { url = value; RaisePropertyChanged(); }
		}

		private string updatetime;

		public string Updatetime
		{
			get { return updatetime; }
			set { updatetime = value; RaisePropertyChanged(); }
		}

        private Brush countBrush;

        public Brush CountBrush
        {
            get { return countBrush; }
            set { countBrush = value; RaisePropertyChanged(); }
        }
    }
}
