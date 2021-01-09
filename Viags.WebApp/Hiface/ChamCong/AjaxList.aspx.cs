using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viags.Base;
using Viags.Simple;
using Viags.Utils;
using Viags.Data;
using System.Web.Services;
using System.Web.Script.Services;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Viags.WebApp.Hiface.ChamCong
{
    public partial class AjaxList : Base.BaseWebPage
    {
        //private string TIME_START_WORK = "0800";
        //private string TIME_END_WORK = "1730";
        //private string TIME_START_FREE = "1200";
        //private string TIME_END_FREE = "1330";
        //private string START_WORK_LIMIT_START = "15";
        //private string START_WORK_LIMIT_END = "15";


        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<CalendarEvents> GenerateCalendar(string datajson, int viewtype)
        {
            var listevent = new List<CalendarEvents>();
            JArray jsonArray = JArray.Parse(datajson);
            int EventId = 0;
            foreach (var item in jsonArray)
            {
                EventId++;
                #region [type 0][xem theo công] 
                if (viewtype == 0)
                {
                    var cdEvent = new CalendarEvents();
                    cdEvent.EventId = EventId;

                    if ((int)item["clock_out"] == 0 && (int)item["clock_in"] == 0)
                    {
                        cdEvent.Title = "0";
                        cdEvent.color = "#ff3b3b";
                        var timeIn = UnixTimeStampToDateTime((int)item["date"]);
                        cdEvent.EventStartDate = timeIn.ToString("yyyy-MM-dd 00:00");
                        cdEvent.EventEndDate = timeIn.ToString("yyyy-MM-dd 23:59");
                    }
                    else
                    {
                        if ((int)item["clock_out"] == 0 || (int)item["clock_in"] == 0)
                        {
                            cdEvent.Title = "Quên chấm công";
                            cdEvent.color = "blueviolet";
                        }
                        else
                        {
                            cdEvent.Title = "1";
                            cdEvent.color = "#4bf14b";
                        }

                    }

                    if (item["check_in_time"] != null)
                    {
                        var timeIn = UnixTimeStampToDateTime((int)item["check_in_time"]);
                        item["check_in_time"] = timeIn.ToString("yyyy-MM-dd HH:mm");
                        item["timeIn"] = timeIn.ToString("HH:mm");
                        cdEvent.EventStartDate = timeIn.ToString("yyyy-MM-dd HH:mm");
                        cdEvent.TimeIn = timeIn.ToString("HH:mm");
                    }
                    if (item["check_out_time"] != null)
                    {
                        var timeOut = UnixTimeStampToDateTime((int)item["check_out_time"]);
                        item["check_out_time"] = timeOut.ToString("yyyy-MM-dd HH:mm");
                        item["timeOut"] = timeOut.ToString("HH:mm");
                        cdEvent.EventEndDate = timeOut.ToString("yyyy-MM-dd HH:mm");
                        cdEvent.TimeOut = timeOut.ToString("HH:mm");
                    }
                    cdEvent.EventDescription = "Event Description 1";
                    cdEvent.AllDayEvent = false;
                    listevent.Add(cdEvent);
                }
                #endregion
                #region [type 1][đi làm - vắng] 
                if (viewtype == 1)
                {
                    var cdEvent = new CalendarEvents();
                    cdEvent.EventId = EventId;
                    
                    if ((int)item["clock_out"] == 0 && (int)item["clock_in"] == 0)
                    {
                        cdEvent.Title = "Vắng";
                        cdEvent.color = "#ff3b3b";
                        var timeIn = UnixTimeStampToDateTime((int)item["date"]);
                        cdEvent.EventStartDate = timeIn.ToString("yyyy-MM-dd 00:00");
                        cdEvent.EventEndDate = timeIn.ToString("yyyy-MM-dd 23:59");
                    }
                    else
                    {
                        if ((int)item["clock_out"] == 0 || (int)item["clock_in"] == 0)
                        {
                            cdEvent.Title = "Quên chấm công";
                            cdEvent.color = "blueviolet";
                        }
                        else
                        {
                            cdEvent.Title = "Đi làm";
                            cdEvent.color = "#4bf14b";
                        }
                       
                    }

                    if (item["check_in_time"] != null)
                    {
                        var timeIn = UnixTimeStampToDateTime((int)item["check_in_time"]);
                        item["check_in_time"] = timeIn.ToString("yyyy-MM-dd HH:mm");
                        item["timeIn"] = timeIn.ToString("HH:mm");
                        cdEvent.EventStartDate = timeIn.ToString("yyyy-MM-dd HH:mm");
                        cdEvent.TimeIn = timeIn.ToString("HH:mm");
                    }
                    if (item["check_out_time"] != null)
                    {
                        var timeOut = UnixTimeStampToDateTime((int)item["check_out_time"]);
                        item["check_out_time"] = timeOut.ToString("yyyy-MM-dd HH:mm");
                        item["timeOut"] = timeOut.ToString("HH:mm");
                        cdEvent.EventEndDate = timeOut.ToString("yyyy-MM-dd HH:mm");
                        cdEvent.TimeOut = timeOut.ToString("HH:mm");
                    }
                    cdEvent.EventDescription = "Event Description 1";
                    cdEvent.AllDayEvent = false;
                    listevent.Add(cdEvent);
                }
                #endregion
                #region [type 2][đi trễ - về sớm] 
                if (viewtype == 2)
                {
                    var cdEvent = new CalendarEvents();
                    cdEvent.EventId = EventId;
                    
                    if ((int)item["clock_out"] == 0 && (int)item["clock_in"] == 0)
                    {
                        cdEvent.Title = "Vắng";
                        cdEvent.color = "#ff3b3b";
                        var timeIn = UnixTimeStampToDateTime((int)item["date"]);
                        cdEvent.EventStartDate = timeIn.ToString("yyyy-MM-dd 00:00");
                        cdEvent.EventEndDate = timeIn.ToString("yyyy-MM-dd 23:59");
                    }
                    else
                    {
                        if ((int)item["clock_out"] == 0 || (int)item["clock_in"] == 0)
                        {
                            cdEvent.Title = "Quên chấm công";
                            cdEvent.color = "blueviolet";
                            var timeIn = UnixTimeStampToDateTime((int)item["date"]);
                            cdEvent.EventStartDate = timeIn.ToString("yyyy-MM-dd 00:00");
                            cdEvent.EventEndDate = timeIn.ToString("yyyy-MM-dd 23:59");
                        }
                        else
                        {
                            var datework = UnixTimeStampToDateTime((int)item["date"]);
                            var timeIn = UnixTimeStampToDateTime((int)item["check_in_time"]);
                            var timeOut = UnixTimeStampToDateTime((int)item["check_out_time"]);
                            var TIME_START_WORK = datework.AddHours(8).AddMinutes(45);
                            var TIME_END_WORK = datework.AddHours(17).AddMinutes(45);
                            if (TIME_START_WORK < timeIn || timeOut < TIME_END_WORK)
                            {
                                cdEvent.Title = "Đi trể + Về sớm";
                                cdEvent.color = "yellow";
                            }
                            else if (TIME_START_WORK > timeIn || timeOut > TIME_END_WORK)
                            {
                                cdEvent.Title = "Đúng giờ";
                                cdEvent.color = "#4bf14b";
                            }
                            else if (TIME_START_WORK < timeIn || timeOut > TIME_END_WORK)
                            {
                                cdEvent.Title = "Đi trể";
                                cdEvent.color = "yellow";
                            }
                            else if (TIME_START_WORK > timeIn || timeOut < TIME_END_WORK)
                            {
                                cdEvent.Title = "Về sớm";
                                cdEvent.color = "yellow";
                            }
                            // check vào trễ
                            // check về sớm
                            // check vào trễ về sớm
                            // check đúng giờ
                            //cdEvent.Title = "Đi làm";
                            //cdEvent.color = "#4bf14b";
                        }



                    }

                    if (item["check_in_time"] != null)
                    {
                        var timeIn = UnixTimeStampToDateTime((int)item["check_in_time"]);
                        item["check_in_time"] = timeIn.ToString("yyyy-MM-dd HH:mm");
                        item["timeIn"] = timeIn.ToString("HH:mm");
                        cdEvent.EventStartDate = timeIn.ToString("yyyy-MM-dd HH:mm");
                        cdEvent.TimeIn = timeIn.ToString("HH:mm");
                    }
                    if (item["check_out_time"] != null)
                    {
                        var timeOut = UnixTimeStampToDateTime((int)item["check_out_time"]);
                        item["check_out_time"] = timeOut.ToString("yyyy-MM-dd HH:mm");
                        item["timeOut"] = timeOut.ToString("HH:mm");
                        cdEvent.EventEndDate = timeOut.ToString("yyyy-MM-dd HH:mm");
                        cdEvent.TimeOut = timeOut.ToString("HH:mm");
                    }
                    cdEvent.EventDescription = "Event Description 1";
                    cdEvent.AllDayEvent = false;
                    listevent.Add(cdEvent);
                }
                #endregion
              
            }
            //foreach (var item in jsonArray)
            //{
            //    EventId++;
            //    #region [type 0][đi làm - vắng] 
            //    if (0 == 0)
            //    {
            //        var cdEvent = new CalendarEvents();
            //        cdEvent.EventId = EventId;

            //        if ((int)item["clock_out"] == 0 && (int)item["clock_in"] == 0)
            //        {
            //            cdEvent.Title = "0";
            //            cdEvent.TypeCong = "0";
            //            var timeIn = UnixTimeStampToDateTime((int)item["date"]);
            //            cdEvent.EventStartDate = timeIn.ToString("yyyy-MM-dd 00:00");
            //            cdEvent.EventEndDate = timeIn.ToString("yyyy-MM-dd 23:59");
            //        }
            //        else
            //        {
            //            if ((int)item["clock_out"] == 0 || (int)item["clock_in"] == 0)
            //            {
            //                cdEvent.Title = "???";
            //                cdEvent.TypeCong = "???";
            //            }
            //            else
            //            {
            //                cdEvent.Title = "1";
            //                cdEvent.TypeCong = "1";
            //            }

            //        }

            //        if (item["check_in_time"] != null)
            //        {
            //            cdEvent.EventStartDate = item["check_in_time"].ToString();
            //            cdEvent.TimeIn = item["timeIn"].ToString();
            //        }
            //        if (item["check_out_time"] != null)
            //        {
            //            cdEvent.EventEndDate = item["check_out_time"].ToString();
            //            cdEvent.TimeOut = item["timeOut"].ToString();
            //        }
            //        cdEvent.color = "white";
            //        cdEvent.EventDescription = "Event Description 1";
            //        cdEvent.AllDayEvent = false;
            //        listevent.Add(cdEvent);
            //    }
            //    #endregion
                

            //}

            return listevent;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string AttendanceList(string timefilter)
        {
            var client = new RestClient("http://hiface.tinhvan.com/attendance/stats?size=99999999&date="+ timefilter);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "b990b346-e791-41d5-9e07-590764708819");
            IRestResponse response = client.Execute(request);
            var ct = response.Content;
            return ct;
        }
        private static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }






        /* this is an example method that creates sample data to show in FullCalendar.
            * instead of this, you will simply reuqire to replace this code to actually fetch data from database
            * */

        public class CalendarEvents
        {
            public Int64 EventId { get; set; }
            public string EventStartDate { get; set; }
            public string EventEndDate { get; set; }
            public string TimeIn { get; set; }
            public string TimeOut { get; set; }
            public string color { get; set; }
            public string EventDescription { get; set; }
            public string Title { get; set; }
            public bool AllDayEvent { get; set; }

            public string TypeCong { get; set; }
        }

    }


}