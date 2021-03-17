using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Viags.Base;
using Viags.Simple;
using Viags.Utils;

namespace Viags.Data
{
    public class Transit_TaiXeDA : BaseDA
    {
        public Transit_TaiXeDA() : base(HttpContext.Current) { }

        public Message Add()
        {
            GetCurrentUser();
            Message objMsg;
            //var itemID = string.IsNullOrEmpty(Request["itemID"]) ? 0 : int.Parse(Request["itemID"]);
    
            
            using (var context = new FoldioContext())
            {
                try
                {
                    var query = new TS_TaiXe();
                    UpdateModel(query);
               
                    context.TS_TaiXe.Add(query);
                    context.SaveChanges();            


                    objMsg = new Message
                    {
                        ID = 0,
                        Error = false,
                        Title = "Thêm thông tin tài xế thành công!",
                    };
                }
                catch (Exception ex)
                {
                    objMsg = new Message
                    {
                        ID = 0,
                        Error = true,
                        Title = ex.Message
                    };
                }
                return objMsg;
            }
        }

        public Message Edit()
        {
            return new Message();
        }

        public Message Delete()
        {
            return new Message();
        }

    }
}
