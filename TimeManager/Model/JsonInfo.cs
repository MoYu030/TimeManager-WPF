using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TimeManager.Model
{
    public class JsonInfo
    {
        private int code;

        public int Code
        {
            get { return code; }
            set { code = value;  }
        }

        private string msg;

        public string Msg
        {
            get { return msg; }
            set { msg = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private List<HotSearch> data;

        public List<HotSearch> Data
        {
            get { return data; }
            set { data = value;  }
        }

    }
}
