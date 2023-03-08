using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TimeManager.Model
{
    public class HttpRequest
    {
        public async Task<string> Get(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";
                request.Timeout = 10;
                HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse;
                //获得Response的流
                Stream myResponseStream = response.GetResponseStream();
                //读取流数据
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();
                //读取完成  关闭数据流
                myStreamReader.Close();
                myResponseStream.Close();
                return retString;
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
                return default;
            }
        }
    }
}
