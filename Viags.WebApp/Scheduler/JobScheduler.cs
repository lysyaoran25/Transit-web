using Quartz;
using Quartz.Impl;
using System;
using Viags.WebApp.Scheduler;

namespace Viags.WebApp.Scheduler
{
    public class JobScheduler
    {
        public static void Start()
        {
            string onOffScheduler = System.Configuration.ConfigurationManager.AppSettings["OnOffScheduler"];
            var scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();

            #region [-----------------Send mail-------------------]
            var job = JobBuilder.Create<Mail>().Build();
            var trigger = TriggerBuilder.Create()
                .WithIdentity("Mail", "IDG")
                .WithSimpleSchedule(x => x
                //.WithIntervalInMinutes(5)
                .WithIntervalInSeconds(15)
                .RepeatForever())
                .StartAt(DateTime.UtcNow)
                .WithPriority(1)
                .Build();
            scheduler.ScheduleJob(job, trigger);//sendmail
            #endregion
            #region [-----------------Schedules-------------------]
            var jobSchedulesTypeRepeat = JobBuilder.Create<Schedules>().Build();
            var triggerSchedulesTypeRepeat = TriggerBuilder.Create()
                .WithIdentity("Schedules", "IDG")
                .WithSimpleSchedule(x => x
              .WithIntervalInSeconds(6)
                //.WithIntervalInMinutes(15)
                .RepeatForever())
                .StartAt(DateTime.UtcNow)
                .WithPriority(1)
                .Build();
            //đồng bộ dữ liệu ldap
            if (onOffScheduler == "1")
            {
                // scheduler.ScheduleJob(jobSchedulesTypeRepeat, triggerSchedulesTypeRepeat);
            }
            #endregion

            #region [-----------------Auto Add Notification Food Order-------------------]
            var addNoti = JobBuilder.Create<AddNotiFoodOrder>().Build();
            var triggerAddNoti = TriggerBuilder.Create()
                .WithIdentity("AddNotiFoodOrder", "IDG")
                .WithSimpleSchedule(x => x
                //.WithIntervalInSeconds(10)
                //.WithIntervalInMinutes(2)
                .WithIntervalInHours(24)
                .RepeatForever())
                .StartAt(DateTime.UtcNow)
                .WithPriority(1)
                .Build();
            scheduler.ScheduleJob(addNoti, triggerAddNoti);//sendmail
            #endregion

            #region[Add NVTT ngày chưa hoàn thành]
            var addNVTTNgay = JobBuilder.Create<AddNhiemVuTrongTamNgay>().Build();
            var triggeraddNVTTNgay = TriggerBuilder.Create()
                .WithIdentity("AddNhiemVuTrongTamNgay", "IDG")
                .WithCronSchedule("0 30 3-4 ? * MON-FRI")
                //.WithSimpleSchedule(x => x
                ////.WithIntervalInSeconds(10)
                ////.WithIntervalInMinutes(2)
                //.WithIntervalInHours(24)
                //.RepeatForever())
                .StartAt(DateTime.UtcNow)
                .WithPriority(1)
                .Build();
            scheduler.ScheduleJob(addNVTTNgay, triggeraddNVTTNgay);//sendmail
            #endregion
        }
    }
}