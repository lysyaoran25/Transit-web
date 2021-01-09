using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viags.Base;
using System.Web;
using Viags.Utils;
using WebFormsUtilities;

using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;
namespace Viags.Data
{
    public class BaseDA : IDisposable
    {
        public string IPAddress { get; set; }
        /// <summary>
        /// Đối tượng Request từ web
        /// </summary>
        public HttpRequest Request
        {
            get
            {
                return HttpContext.Current.Request;
            }
        }
        public List<int> ListFileScanId { get; set; }
        public Message objMessage { get; set; }
        public List<int> LtsChucNangID { get; set; }
        public List<int> LtsVanBanDenLienQuan { get; set; }
        public List<int> LtsVanBanDiLienQuan { get; set; }
        /// <summary>
        /// Ngày văn bản
        /// </summary>
        public DateTime? NgayVanBan { get; set; }
        private FoldioContext _FoldioDB;
        /// <summary>
        /// Database
        /// </summary>
        public FoldioContext FoldioDB { get { return _FoldioDB; } }
        public int RowPerPage { get; set; }
        /// <summary>
        /// Số trang hiển thị
        /// </summary>
        public int PageStep { get; set; }
        /// <summary>
        /// Tổng số bản ghi
        /// </summary>
        public int TotalRecord = 0;
        public int TotalRecordList = 0;
        public int countChuaThucHienItem = 0;
        public int countDangThucHienItem = 0;
        public int countDaHoanThanhItem = 0;
        public int countTreHanItem = 0;
        public int countcvgiao = 0;
        public int countcvthuchen = 0;
        public int countcvphoihop = 0;
        public int countcvgiaogiantiep = 0;
        public string Field { get; set; }
        public bool FieldOption { get; set; }
        public Utils.TypeOfAction Action
        {
            get;
            set;
        }
        /// <summary>
        /// List File Attachment
        /// </summary>
        List<FileAttach> listFileAttachAdd = new List<FileAttach>();
        /// <summary>
        /// List File Attachment
        /// </summary>
        public List<FileAttach> ListFileAttachAdd
        {
            get { return listFileAttachAdd; }
            set { listFileAttachAdd = value; }
        }
        List<FileAttach> listFileAttachAddoption = new List<FileAttach>();
        public List<FileAttach> ListFileAttachAddoption
        {
            get { return listFileAttachAdd; }
            set { listFileAttachAdd = value; }
        }
        public List<FileAttach> ListFileAttachAddoption1
        {
            get { return listFileAttachAdd; }
            set { listFileAttachAdd = value; }
        }
        List<FileAttach> listFileAttachAddYKien = new List<FileAttach>();
        public List<FileAttach> ListFileAttachAddYKien
        {
            get { return listFileAttachAddYKien; }
            set { listFileAttachAddYKien = value; }
        }
        List<FileAttach> listFileAttach = new List<FileAttach>();
        /// <summary>
        /// List File Attachment
        /// </summary>
        public List<FileAttach> ListFileAttach
        {
            get { return listFileAttach; }
            set { listFileAttach = value; }
        }
        /// <summary>
        /// List File Attach Remove
        /// </summary>
        List<int> _ListFileRemove = new List<int>();
        public List<int> ListFileRemove
        {
            get { return _ListFileRemove; }
            set { _ListFileRemove = value; }
        }
        public int CurrentPage { get; set; }
        public int HoSoCongViecID { get; set; }
        public List<string> SearchInFiled { get; set; }
        public string TenTruyCap { get; set; }
        /// <summary>
        /// Từ khóa tìm kiếm
        /// </summary>
        public string Keyword { get; set; }
        /// <summary>
        /// Tự động map tất cả thuộc tính của object thông qua các parrams post
        /// </summary>
        /// <param name="model">Obecj cần update</param>
        /// <modified>
        /// Author				    created date					comments
        /// QuangNĐ					05/07/2013				        Tạo mới
        ///</modified>
        public void UpdateModel<TModel>(TModel model)
        {
            WFPageUtilities.UpdateModel(HttpContext.Current.Request, model);
        }
        public List<int> ListID { get; set; }
        public int NguoiDungID { get; set; }
        public int DonViID { get; set; }

        public Simple.NguoiDungSession CurrentUser { get; set; }
        public BaseDA(HttpContext context)
        {
            CurrentUser = new Simple.NguoiDungSession();
            GetCurrentUser();

            DateTimeFormatInfo dtfiParser;
            dtfiParser = new DateTimeFormatInfo();
            dtfiParser.ShortDatePattern = "dd/MM/yyyy";
            dtfiParser.DateSeparator = "/";

            #region Lấy thông tin ID
            ListID = new List<int>();
            try
            {

                if (!string.IsNullOrEmpty(HttpContext.Current.Request["ItemId"]))
                {
                    string arrID = HttpContext.Current.Request["ItemId"].Trim();
                    if (arrID.Contains(','))
                    {
                        ListID = arrID.Split(',').Select(o => Convert.ToInt32(o.Trim())).ToList();
                    }
                    else
                        ListID.Add(Convert.ToInt32(arrID));
                }
                if (!string.IsNullOrEmpty(HttpContext.Current.Request["DanhMucGiaTriID"]))
                {
                    LtsChucNangID = String2Array(HttpContext.Current.Request["DanhMucGiaTriID"]);
                }
                else
                {
                    LtsChucNangID = new List<int>();
                }
                if (!string.IsNullOrEmpty(HttpContext.Current.Request["TenTruyCap"]))
                {
                    TenTruyCap = HttpContext.Current.Request["TenTruyCap"];
                }
                //lấy về danh sách danh mục sử dụng trên các form văn bản....

                if (!string.IsNullOrEmpty(HttpContext.Current.Request["NguoiDungID"]))
                {
                    NguoiDungID = Convert.ToInt32(HttpContext.Current.Request["NguoiDungID"]);
                }
                else
                {
                    NguoiDungID = 0;
                }
                if (!string.IsNullOrEmpty(HttpContext.Current.Request["DonViID"]))
                {
                    DonViID = Convert.ToInt32(HttpContext.Current.Request["DonViID"]);
                }
                else
                {
                    DonViID = 0;
                }
                if (!string.IsNullOrEmpty(HttpContext.Current.Request["HoSoCongViecID"]))
                {
                    HoSoCongViecID = Convert.ToInt32(HttpContext.Current.Request["HoSoCongViecID"]);
                }
                if (!string.IsNullOrEmpty(HttpContext.Current.Request["VanBanDenLienQuan"]))
                {
                    LtsVanBanDenLienQuan = String2Array(HttpContext.Current.Request["VanBanDenLienQuan"]);
                }
                else
                {
                    LtsVanBanDenLienQuan = new List<int>();
                }
                if (!string.IsNullOrEmpty(HttpContext.Current.Request["VanBanDiLienQuan"]))
                {
                    LtsVanBanDiLienQuan = String2Array(HttpContext.Current.Request["VanBanDiLienQuan"]);
                }
                else
                {
                    LtsVanBanDiLienQuan = new List<int>();
                }
                #region Lấy thông tin action

                string actionName = string.Empty;
                if (!string.IsNullOrEmpty(HttpContext.Current.Request["do"]))
                {
                    actionName = HttpContext.Current.Request["do"].ToLower().Trim();
                    switch (actionName)
                    {
                        case "add":
                            Action = Utils.TypeOfAction.Add;
                            break;

                        case "quickadd":
                            Action = Utils.TypeOfAction.QuickAdd;
                            break;

                        case "edit":
                            Action = Utils.TypeOfAction.Edit;
                            break;

                        case "approved":
                            Action = Utils.TypeOfAction.Approved;
                            break;

                        case "delete":
                            Action = Utils.TypeOfAction.Delete;
                            break;

                        case "hide":
                            Action = Utils.TypeOfAction.Hide;
                            break;

                        case "reject":
                            Action = Utils.TypeOfAction.Reject;
                            break;

                        case "show":
                            Action = Utils.TypeOfAction.Show;
                            break;
                        case "pending":
                            Action = Utils.TypeOfAction.Pending;
                            break;
                        case "send":
                            Action = Utils.TypeOfAction.Send;
                            break;
                        case "butphe":
                            Action = Utils.TypeOfAction.ButPhe;
                            break;
                        case "ykien":
                            Action = Utils.TypeOfAction.YKien;
                            break;
                        case "dongbo":
                            Action = Utils.TypeOfAction.DongBo;
                            break;
                        case "order":
                        case "sort":
                            Action = Utils.TypeOfAction.Order;
                            break;

                        default:
                        case "view":
                            Action = Utils.TypeOfAction.View;
                            break;
                    }
                }
                else
                    Action = Utils.TypeOfAction.View;
                if (!string.IsNullOrEmpty(HttpContext.Current.Request["Keyword"]))
                {
                    Keyword = HttpContext.Current.Request["Keyword"].Trim();
                    Keyword = Regex.Replace(Keyword, @"\s+", " ");
                }
                if (!string.IsNullOrEmpty(HttpContext.Current.Request["SearchIn"]))
                {
                    if (HttpContext.Current.Request["SearchIn"].Contains(","))
                        SearchInFiled = HttpContext.Current.Request["SearchIn"].Split(',').ToList();
                    else
                    {
                        SearchInFiled = new List<string>();
                        SearchInFiled.Add(HttpContext.Current.Request["SearchIn"].ToString());
                    }
                }
                else
                    SearchInFiled = new List<string>();

                if (!string.IsNullOrEmpty(HttpContext.Current.Request["RowPerPage"]))
                    RowPerPage = Convert.ToInt32(HttpContext.Current.Request["RowPerPage"]);
                else
                    RowPerPage = 10;
                if (!string.IsNullOrEmpty(HttpContext.Current.Request["PageStep"]))
                    PageStep = Convert.ToInt32(HttpContext.Current.Request["PageStep"]);
                else
                    PageStep = 3;

                if (!string.IsNullOrEmpty(HttpContext.Current.Request["Page"]))
                    CurrentPage = Convert.ToInt32(HttpContext.Current.Request["Page"]);
                else
                    CurrentPage = 1;

                if (!string.IsNullOrEmpty(HttpContext.Current.Request["Field"]))
                    Field = HttpContext.Current.Request["Field"];
                else
                    Field = "ID";

                if (!string.IsNullOrEmpty(HttpContext.Current.Request["FieldOption"]))
                    FieldOption = (Convert.ToInt32(HttpContext.Current.Request["FieldOption"]) == 1) ? false : true;
                else
                    FieldOption = true;

                #endregion

                #region Get IP
                IPAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (IPAddress == "" || IPAddress == null)
                    IPAddress = Request.ServerVariables["REMOTE_ADDR"];
                #endregion
                #region lấy về file

                //lấy về danh sách file đính kèm
                if (!string.IsNullOrEmpty(HttpContext.Current.Request["listValueFileAttach"]))
                {
                    this.ListFileAttachAdd = new List<Utils.FileAttach>();
                    string strListFileAttach = HttpContext.Current.Request["listValueFileAttach"];
                    System.Web.Script.Serialization.JavaScriptSerializer oSerializer =
                        new System.Web.Script.Serialization.JavaScriptSerializer();
                    List<Utils.FileAttachFrom> ltsFileForm =
                        oSerializer.Deserialize<List<Utils.FileAttachFrom>>(strListFileAttach);

                    Utils.FileAttach fileAttach;

                    string filePath = "~/ajaxUpload/";

                    UploadFileServices.UploadFile uploadFile = new UploadFileServices.UploadFile();
                    foreach (Utils.FileAttachFrom fileForm in ltsFileForm)
                    {
                        fileAttach = new Utils.FileAttach();
                        fileAttach.Ten = fileForm.FileName;
                        fileAttach.FileData =
                        Utility.ReadFile(HttpContext.Current.Server.MapPath(filePath + fileForm.FileServer));

                        fileAttach.Url = HttpContext.Current.Server.MapPath(filePath + fileForm.FileServer);
                        fileAttach.FileServer = "ajaxUpload/" + fileForm.FileServer;
                        fileAttach.FileLink = "ajaxUpload/" + fileForm.FileServer;

                        this.ListFileAttachAdd.Add(fileAttach);
                    }

                }
                if (!string.IsNullOrEmpty(HttpContext.Current.Request["listValueFileAttachoption"]))
                {
                    ListFileAttachAddoption = new List<Utils.FileAttach>();
                    string strListFileAttach = HttpContext.Current.Request["listValueFileAttachoption"];
                    System.Web.Script.Serialization.JavaScriptSerializer oSerializer =
                        new System.Web.Script.Serialization.JavaScriptSerializer();
                    List<Utils.FileAttachFrom> ltsFileForm =
                        oSerializer.Deserialize<List<Utils.FileAttachFrom>>(strListFileAttach);

                    Utils.FileAttach fileAttach;
                    string filePath = "~/ajaxUpload/";
                    UploadFileServices.UploadFile uploadFile = new UploadFileServices.UploadFile();
                    foreach (Utils.FileAttachFrom fileForm in ltsFileForm)
                    {
                        fileAttach = new Utils.FileAttach();
                        fileAttach.Ten = fileForm.FileName;
                        fileAttach.FileData =
                        Utility.ReadFile(HttpContext.Current.Server.MapPath(filePath + fileForm.FileServer));

                        fileAttach.Url = HttpContext.Current.Server.MapPath(filePath + fileForm.FileServer);
                        fileAttach.FileServer = "ajaxUpload/" + fileForm.FileServer;


                        fileAttach.FileLink = "ajaxUpload/" + fileForm.FileServer;

                        this.ListFileAttachAddoption.Add(fileAttach);

                    }

                }
                if (!string.IsNullOrEmpty(HttpContext.Current.Request["listValueFileAttachYKien"]))
                {
                    this.ListFileAttachAddYKien = new List<Utils.FileAttach>();
                    string strListFileAttach = HttpContext.Current.Request["listValueFileAttachYKien"];
                    System.Web.Script.Serialization.JavaScriptSerializer oSerializer =
                        new System.Web.Script.Serialization.JavaScriptSerializer();
                    List<Utils.FileAttachFrom> ltsFileForm =
                        oSerializer.Deserialize<List<Utils.FileAttachFrom>>(strListFileAttach);

                    Utils.FileAttach fileAttach;

                    string filePath = "~/ajaxUpload/";

                    UploadFileServices.UploadFile uploadFile = new UploadFileServices.UploadFile();
                    foreach (Utils.FileAttachFrom fileForm in ltsFileForm)
                    {
                        fileAttach = new Utils.FileAttach();
                        fileAttach.Ten = fileForm.FileName;
                        fileAttach.FileData =
                        Utility.ReadFile(HttpContext.Current.Server.MapPath(filePath + fileForm.FileServer));

                        fileAttach.Url = HttpContext.Current.Server.MapPath(filePath + fileForm.FileServer);
                        fileAttach.FileServer = "ajaxUpload/" + fileForm.FileServer;
                        fileAttach.FileLink = "ajaxUpload/" + fileForm.FileServer;

                        this.ListFileAttachAddYKien.Add(fileAttach);
                    }

                }
                //lấy về danh sách file đính kèm
                if (!string.IsNullOrEmpty(HttpContext.Current.Request["listValueFileAttachoption1"]))
                {
                    ListFileAttachAddoption1 = new List<Utils.FileAttach>();
                    string strListFileAttach = HttpContext.Current.Request["listValueFileAttachoption1"];
                    System.Web.Script.Serialization.JavaScriptSerializer oSerializer =
                        new System.Web.Script.Serialization.JavaScriptSerializer();
                    List<Utils.FileAttachFrom> ltsFileForm =
                        oSerializer.Deserialize<List<Utils.FileAttachFrom>>(strListFileAttach);

                    Utils.FileAttach fileAttach;
                    string filePath = "~/ajaxUpload/";
                    UploadFileServices.UploadFile uploadFile = new UploadFileServices.UploadFile();
                    foreach (Utils.FileAttachFrom fileForm in ltsFileForm)
                    {
                        fileAttach = new Utils.FileAttach();
                        fileAttach.Ten = fileForm.FileName;
                        fileAttach.FileData =
                        Utility.ReadFile(HttpContext.Current.Server.MapPath(filePath + fileForm.FileServer));

                        fileAttach.Url = HttpContext.Current.Server.MapPath(filePath + fileForm.FileServer);
                        fileAttach.FileServer = "ajaxUpload/" + fileForm.FileServer;


                        fileAttach.FileLink = "ajaxUpload/" + fileForm.FileServer;

                        this.ListFileAttachAddoption1.Add(fileAttach);

                    }

                }
                //Lấy về danh sách file xóa
                if (!string.IsNullOrEmpty(HttpContext.Current.Request["listValueFileAttachRemove"]) && HttpContext.Current.Request["listValueFileAttachRemove"] != "null")
                {
                    string[] tempLinkList = HttpContext.Current.Request["listValueFileAttachRemove"].Trim().Split('#');
                    for (int indexLink = 0; indexLink < tempLinkList.Length; indexLink++)
                    {
                        if (!string.IsNullOrEmpty(tempLinkList[indexLink]))
                            this.ListFileRemove.Add(Convert.ToInt32(tempLinkList[indexLink]));
                    }
                }
                ListFileScanId = new List<int>();
                if (!string.IsNullOrEmpty(Request["listFileScan"]) && !string.IsNullOrWhiteSpace(Request["listFileScan"]))
                {
                    string[] arr = Request["listFileScan"].Split(',');
                    foreach (var x in arr)
                        ListFileScanId.Add(int.Parse(x));
                }

                #endregion Lấy về file đính kèm
            }
            catch (Exception ex)
            {
                objMessage = new Message()
                {
                    Title = "Có lỗi dữ liệu liên quan đến thẻ HTML, XSS",
                    Error = true,
                    Obj = ex
                };
            }

            #endregion
        }
        /// <summary>
        /// Convert xâu có dạng 1,2,3,4 sang list int
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        /// <modified>
        /// Author				    created date					comments
        /// QuangNĐ					05/07/2013				        Tạo mới
        ///</modified>
        public List<int> String2Array(string source)
        {
            try
            {
                var ltsValue = new List<int>();
                if (string.IsNullOrEmpty(source)) return ltsValue;
                if (source.EndsWith(","))
                    source = source.Substring(0, source.LastIndexOf(",", StringComparison.Ordinal));
                if (source.Contains(','))
                {
                    foreach (var item in source.Split(','))
                    {
                        int id;
                        if (int.TryParse(item, out id))
                            ltsValue.Add(id);
                    }
                }
                else
                    ltsValue.Add(Convert.ToInt32(source));
                return ltsValue;
            }
            catch
            {
                return new List<int>();
            }
        }
        public List<string> String2ArrayString(string source)
        {
            try
            {
                if (source.EndsWith(","))
                    source = source.Substring(0, source.LastIndexOf(",", System.StringComparison.Ordinal));
                var ltsValue = new List<string>();
                if (string.IsNullOrEmpty(source)) return ltsValue;
                if (source.Contains(','))
                {
                    ltsValue = source.Split(',').Select(Convert.ToString).ToList();
                }
                else
                    ltsValue.Add(Convert.ToString(source));
                return ltsValue;
            }
            catch
            {
                var ltsValuenull = new List<string>();
                return ltsValuenull;
            }
        }
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        public BaseDA()
        {
            try
            {

                if (HttpContext.Current.Session != null && HttpContext.Current.Session["VIAG2016"] != null)
                    CurrentUser = (Viags.Simple.NguoiDungSession)HttpContext.Current.Session["VIAG2016"];
            }
            catch (Exception ex)
            { }

            DateTimeFormatInfo dtfiParser;
            dtfiParser = new DateTimeFormatInfo();
            dtfiParser.ShortDatePattern = "dd/MM/yyyy";
            dtfiParser.DateSeparator = "/";
            #region Lấy thông tin ID
            ListID = new List<int>();
            LtsChucNangID = new List<int>();
            try
            {
                if (!string.IsNullOrEmpty(HttpContext.Current.Request["ItemId"]))
                {
                    string arrID = HttpContext.Current.Request["ItemId"].Trim();
                    if (arrID.Contains(','))
                    {
                        ListID = arrID.Split(',').Select(o => Convert.ToInt32(o.Trim())).ToList();
                    }
                    else
                        ListID.Add(Convert.ToInt32(arrID));
                }



                if (!string.IsNullOrEmpty(HttpContext.Current.Request["NgayVanBan"]))
                    NgayVanBan = Convert.ToDateTime(HttpContext.Current.Request["NgayVanBan"], dtfiParser);
                else
                    NgayVanBan = null;
                //lấy về danh sách danh mục sử dụng trên các form văn bản....
                LtsChucNangID = !string.IsNullOrEmpty(HttpContext.Current.Request["DanhMucGiaTriID"]) ? String2Array(HttpContext.Current.Request["DanhMucGiaTriID"]) : new List<int>();
                if (!string.IsNullOrEmpty(HttpContext.Current.Request["TenTruyCap"]))
                {
                    TenTruyCap = HttpContext.Current.Request["TenTruyCap"];
                }

                NguoiDungID = !string.IsNullOrEmpty(HttpContext.Current.Request["NguoiDungID"]) ? Convert.ToInt32(HttpContext.Current.Request["NguoiDungID"]) : 0;
                DonViID = !string.IsNullOrEmpty(HttpContext.Current.Request["DonViID"]) ? Convert.ToInt32(HttpContext.Current.Request["DonViID"]) : 0;
                if (!string.IsNullOrEmpty(HttpContext.Current.Request["HoSoCongViecID"]))
                {
                    HoSoCongViecID = Convert.ToInt32(HttpContext.Current.Request["HoSoCongViecID"]);
                }
                LtsVanBanDenLienQuan = !string.IsNullOrEmpty(HttpContext.Current.Request["VanBanDenLienQuan"]) ? String2Array(HttpContext.Current.Request["VanBanDenLienQuan"]) : new List<int>();
                if (!string.IsNullOrEmpty(HttpContext.Current.Request["VanBanDiLienQuan"]))
                {
                    LtsVanBanDiLienQuan = String2Array(HttpContext.Current.Request["VanBanDiLienQuan"]);
                }
                else
                {
                    LtsVanBanDiLienQuan = new List<int>();
                }
                #region Get IP
                IPAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (IPAddress == "" || IPAddress == null)
                    IPAddress = Request.ServerVariables["REMOTE_ADDR"];
                #endregion
                #region Lấy thông tin action

                string actionName = string.Empty;
                if (!string.IsNullOrEmpty(HttpContext.Current.Request["do"]))
                {
                    actionName = HttpContext.Current.Request["do"].ToLower().Trim();
                    switch (actionName)
                    {
                        case "add":
                            Action = Utils.TypeOfAction.Add;
                            break;

                        case "quickadd":
                            Action = Utils.TypeOfAction.QuickAdd;
                            break;

                        case "edit":
                            Action = Utils.TypeOfAction.Edit;
                            break;

                        case "approved":
                            Action = Utils.TypeOfAction.Approved;
                            break;

                        case "delete":
                            Action = Utils.TypeOfAction.Delete;
                            break;

                        case "hide":
                            Action = Utils.TypeOfAction.Hide;
                            break;

                        case "reject":
                            Action = Utils.TypeOfAction.Reject;
                            break;

                        case "show":
                            Action = Utils.TypeOfAction.Show;
                            break;
                        case "pending":
                            Action = Utils.TypeOfAction.Pending;
                            break;
                        case "send":
                            Action = Utils.TypeOfAction.Send;
                            break;
                        case "butphe":
                            Action = Utils.TypeOfAction.ButPhe;
                            break;
                        case "ykien":
                            Action = Utils.TypeOfAction.YKien;
                            break;
                        case "dongbo":
                            Action = Utils.TypeOfAction.DongBo;
                            break;
                        case "order":
                        case "sort":
                            Action = Utils.TypeOfAction.Order;
                            break;

                        default:
                        case "view":
                            Action = Utils.TypeOfAction.View;
                            break;
                    }
                }
                else
                    Action = Utils.TypeOfAction.View;
                if (!string.IsNullOrEmpty(HttpContext.Current.Request["Keyword"]))
                {
                    Keyword = HttpContext.Current.Request["Keyword"].Trim();
                    Keyword = Regex.Replace(Keyword, @"\s+", " ");
                }
                if (!string.IsNullOrEmpty(HttpContext.Current.Request["SearchIn"]))
                {
                    if (HttpContext.Current.Request["SearchIn"].Contains(","))
                        SearchInFiled = HttpContext.Current.Request["SearchIn"].Split(',').ToList();
                    else
                    {
                        SearchInFiled = new List<string>();
                        SearchInFiled.Add(HttpContext.Current.Request["SearchIn"].ToString());
                    }
                }
                else
                    SearchInFiled = new List<string>();

                if (!string.IsNullOrEmpty(HttpContext.Current.Request["RowPerPage"]))
                    RowPerPage = Convert.ToInt32(HttpContext.Current.Request["RowPerPage"]);
                else
                    RowPerPage = 10;
                if (!string.IsNullOrEmpty(HttpContext.Current.Request["PageStep"]))
                    PageStep = Convert.ToInt32(HttpContext.Current.Request["PageStep"]);
                else
                    PageStep = 3;

                if (!string.IsNullOrEmpty(HttpContext.Current.Request["Page"]))
                    CurrentPage = Convert.ToInt32(HttpContext.Current.Request["Page"]);
                else
                    CurrentPage = 1;

                if (!string.IsNullOrEmpty(HttpContext.Current.Request["Field"]))
                    Field = HttpContext.Current.Request["Field"];
                else
                    Field = "ID";

                if (!string.IsNullOrEmpty(HttpContext.Current.Request["FieldOption"]))
                    FieldOption = (Convert.ToInt32(HttpContext.Current.Request["FieldOption"]) == 1) ? false : true;
                else
                    FieldOption = true;

                #endregion

                #region lấy về file
                //lấy về danh sách file đính kèm
                if (!string.IsNullOrEmpty(HttpContext.Current.Request["listValueFileAttach"]))
                {
                    this.ListFileAttachAdd = new List<Utils.FileAttach>();
                    var strListFileAttach = HttpContext.Current.Request["listValueFileAttach"];

                    var ltsFileForm1 = new List<FileAttachFrom>();

                    var oSerializer =
                        new System.Web.Script.Serialization.JavaScriptSerializer();
                    var ltsFileForm =
                        oSerializer.Deserialize<List<Utils.FileAttachFrom>>(strListFileAttach);

                    Utils.FileAttach fileAttach;
                    string filePath = "~/ajaxUpload";
                    UploadFileServices.UploadFile uploadFile = new UploadFileServices.UploadFile();
                    foreach (Utils.FileAttachFrom fileForm in ltsFileForm)
                    {

                        fileAttach = new Utils.FileAttach();
                        fileAttach.Ten = fileForm.FileName;
                        fileAttach.FileData =
                        Utility.ReadFile(HttpContext.Current.Server.MapPath(filePath + fileForm.FileServer));

                        fileAttach.Url = HttpContext.Current.Server.MapPath(filePath + fileForm.FileServer);
                        fileAttach.FileServer = "ajaxUpload/" + fileForm.FileServer;
                        fileAttach.FileLink = "ajaxUpload/" + fileForm.FileServer;
                        this.ListFileAttachAdd.Add(fileAttach);
                    }

                }
                if (!string.IsNullOrEmpty(HttpContext.Current.Request["listValueFileAttachoption"]))
                {
                    ListFileAttachAddoption = new List<Utils.FileAttach>();
                    string strListFileAttach = HttpContext.Current.Request["listValueFileAttachoption"];
                    var oSerializer =
                        new System.Web.Script.Serialization.JavaScriptSerializer();
                    var ltsFileForm =
                        oSerializer.Deserialize<List<Utils.FileAttachFrom>>(strListFileAttach);

                    Utils.FileAttach fileAttach;

                    string filePath = "~/ajaxUpload";
                    UploadFileServices.UploadFile uploadFile = new UploadFileServices.UploadFile();
                    foreach (Utils.FileAttachFrom fileForm in ltsFileForm)
                    {
                        fileAttach = new Utils.FileAttach();
                        fileAttach.Ten = fileForm.FileName;
                        fileAttach.FileData =
                        Utility.ReadFile(HttpContext.Current.Server.MapPath(filePath + fileForm.FileServer));

                        fileAttach.Url = HttpContext.Current.Server.MapPath(filePath + fileForm.FileServer);
                        fileAttach.FileServer = "ajaxUpload" + fileForm.FileServer;


                        fileAttach.FileLink = "ajaxUpload/" + fileForm.FileServer;

                        this.ListFileAttachAddoption.Add(fileAttach);
                    }

                }

                //Lấy về danh sách file xóa
                if (!string.IsNullOrEmpty(HttpContext.Current.Request["listValueFileAttachRemove"]) && !string.IsNullOrWhiteSpace(HttpContext.Current.Request["listValueFileAttachRemove"]))
                {
                    string[] tempLinkList = HttpContext.Current.Request["listValueFileAttachRemove"].Trim().Split('#');
                    for (int indexLink = 0; indexLink < tempLinkList.Length; indexLink++)
                    {
                        if (!string.IsNullOrEmpty(tempLinkList[indexLink]) && tempLinkList[indexLink] != "null")
                            this.ListFileRemove.Add(Convert.ToInt32(tempLinkList[indexLink]));
                    }
                }
                ListFileScanId = new List<int>();
                if (!string.IsNullOrEmpty(Request["listFileScan"]) && !string.IsNullOrWhiteSpace(Request["listFileScan"]))
                {
                    string[] arr = Request["listFileScan"].Split(',');
                    foreach (var x in arr)
                        ListFileScanId.Add(int.Parse(x));
                }

                #endregion Lấy về file đính kèm
            }
            catch (Exception ex)
            {
                objMessage = new Message()
                {
                    Title = "Có lỗi dữ liệu liên quan đến thẻ HTML, XSS",
                    Error = true,
                    Obj = ex
                };
            }

            #endregion
        }

        public void GetCurrentUser()
        {
            try
            {

                if (HttpContext.Current.Session != null && HttpContext.Current.Session["VIAG2016"] != null)
                    CurrentUser = (Viags.Simple.NguoiDungSession)HttpContext.Current.Session["VIAG2016"];
                else
                    CurrentUser = new Simple.NguoiDungSession();

            }
            catch (Exception)
            {
                CurrentUser = new Simple.NguoiDungSession();
            }


        }


        /// <summary>
        /// Kiểm tra xem người dùng có quyền 
        /// </summary>
        /// <param name="dsQuyen">danh sách quyền</param>
        /// <param name="idQuyen">id quyền</param>
        /// <returns>true or false</returns>
        public bool CheckQuyen(string dsQuyen, int idQuyen)
        {
            dsQuyen = "," + dsQuyen + ",";
            if (dsQuyen.Contains("," + idQuyen + ","))
                return true;
            return false;
        }


        #region cơ chế dọn rác
        private bool IsDisposed = false;
        public void Free()
        {
            if (IsDisposed)
            {
                throw new System.ObjectDisposedException("Object Name");

            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~BaseDA()
        {

            //Pass false as param because no need to free managed resources when you call finalize it
            //by GC itself as its work of finalize to manage managed resources.
            // Dispose(false);
        }

        //Implement dispose to free resources
        protected virtual void Dispose(bool disposedStatus)
        {
            if (!IsDisposed)
            {
                IsDisposed = true;
                //FoldioDB.Dispose(); // Released unmanaged Resources
                //EFileDB.Dispose();
                if (disposedStatus)
                {

                    //EFileDB.Dispose();
                    // Released managed Resources
                }
            }
        }
        #endregion


        #region [Sontt]
        public bool AddNotification_List(string NoiDung, string NoiDungTiengAnh, int ItemID, int KieuID, List<int> LtsNguoiNhanID, string Link, bool? IsSendEmail, bool? IsSendSMS, bool? NotCurrentUser, string NoiDungGoc = "")
        {
            using (var context = new FoldioContext())
            {
                try
                {
                    GetCurrentUser();
                    //Log to database
                    Base.Notification noti;
                    if (LtsNguoiNhanID.Any() && NotCurrentUser == true)
                    {
                        LtsNguoiNhanID.Distinct().Where(p => p != CurrentUser.ID).ToList();
                    }
                    else
                    {
                        LtsNguoiNhanID.Distinct().ToList();
                    }
                    foreach (var i in LtsNguoiNhanID)
                    {
                        noti = new Base.Notification();
                        noti.NoiDung = NoiDung;
                        noti.NoiDungTiengAnh = NoiDungTiengAnh;
                        noti.ItemID = ItemID;
                        noti.TrangThaiID = false;
                        noti.Link = Link;
                        noti.KieuID = KieuID;
                        noti.IsSendEmail = IsSendEmail.HasValue ? IsSendEmail.Value : false;
                        noti.IsSendSMS = IsSendSMS;
                        noti.NguoiGuiID = (CurrentUser.ID == 0) ? 1 : CurrentUser.ID;
                        noti.NguoiNhanID = i;
                        noti.FlagSendMail = 0;
                        noti.NgayTao = DateTime.Now;
                        //save
                        context.Notification.Add(noti);
                    }
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    //Log file system
                    return false;
                }
            }
        }
        public bool AddNotification(string NoiDung, string NoiDungTiengAnh, int ItemID, int KieuID, int NguoiNhanID, string Link, bool? IsSendEmail, bool? IsSendSMS, bool? NotCurrentUser, string NoiDungGoc = "", int? UserFromLogin = 0)
        {
            GetCurrentUser();
            if (NotCurrentUser == true)
            {
                if (CurrentUser.ID == NguoiNhanID)
                    return true;
            }
            using (var context = new FoldioContext())
            {
                try
                {
                    //Log to database
                    Base.Notification noti;
                    noti = new Base.Notification();
                    noti.NoiDung = NoiDung;
                    noti.NoiDungTiengAnh = NoiDungTiengAnh;
                    noti.ItemID = ItemID;
                    noti.TrangThaiID = false;
                    noti.Link = Link;
                    noti.KieuID = KieuID;
                    noti.IsSendEmail = IsSendEmail.HasValue ? IsSendEmail.Value : false;
                    noti.IsSendSMS = IsSendSMS;
                    noti.NguoiGuiID = UserFromLogin == 0 ? CurrentUser.ID : UserFromLogin;
                    noti.NguoiNhanID = NguoiNhanID;
                    noti.FlagSendMail = 0;
                    noti.NgayTao = DateTime.Now;
                    //save
                    context.Notification.Add(noti);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    //Log file system
                    return false;
                }
            }
        }
        #endregion

        #region hungnb
        /// <summary>
        /// Gửi thông báo cho phòng ban
        /// </summary>
        /// <param name="NoiDung"></param>
        /// <param name="NoiDungTiengAnh"></param>
        /// <param name="ItemID"></param>
        /// <param name="KieuID"></param>
        /// <param name="LtsNguoiNhanID"></param>
        /// <param name="Link"></param>
        /// <param name="IsSendEmail"></param>
        /// <param name="IsSendSMS"></param>
        /// <param name="NotCurrentUser"></param>
        /// <param name="NoiDungGoc"></param>
        /// <returns></returns>
        public bool AddNotification_List(string NoiDung, string NoiDungTiengAnh, int ItemID, int KieuID, List<int> LtsNguoiNhanID, string Link, bool? IsSendEmail, bool? IsSendSMS, bool? NotCurrentUser, List<int> LstDonViID, string NoiDungGoc = "")
        {
            using (var context = new FoldioContext())
            {
                try
                {
                    GetCurrentUser();
                    //Log to database
                    Base.Notification noti;
                    if (LtsNguoiNhanID != null)
                    {
                        foreach (var i in LtsNguoiNhanID)
                        {
                            noti = new Base.Notification();
                            noti.NoiDung = NoiDung;
                            noti.NoiDungTiengAnh = NoiDungTiengAnh;
                            noti.ItemID = ItemID;
                            noti.TrangThaiID = false;
                            noti.Link = Link;
                            noti.KieuID = KieuID;
                            noti.IsSendEmail = IsSendEmail.HasValue ? IsSendEmail.Value : false;
                            noti.IsSendSMS = IsSendSMS;
                            noti.NguoiGuiID = CurrentUser.ID;
                            noti.NguoiNhanID = i;
                            noti.FlagSendMail = 0;
                            noti.NgayTao = DateTime.Now;
                            noti.DonViID = null;
                            //save
                            context.Notification.Add(noti);
                        }
                    }
                    else
                    {
                        foreach (var i in LstDonViID)
                        {
                            noti = new Base.Notification();
                            noti.NoiDung = NoiDung;
                            noti.NoiDungTiengAnh = NoiDungTiengAnh;
                            noti.ItemID = ItemID;
                            noti.TrangThaiID = false;
                            noti.Link = Link;
                            noti.KieuID = KieuID;
                            noti.IsSendEmail = IsSendEmail.HasValue ? IsSendEmail.Value : false;
                            noti.IsSendSMS = IsSendSMS;
                            noti.NguoiGuiID = CurrentUser.ID;
                            noti.NguoiNhanID = null;
                            noti.FlagSendMail = 0;
                            noti.NgayTao = DateTime.Now;
                            noti.DonViID = i;
                            //save
                            context.Notification.Add(noti);
                        }
                    }
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    //Log file system
                    return false;
                }
            }
        }

        public string UnicodeToAscii(string Unicode)
        {
            Unicode = Regex.Replace(Unicode, "[á|à|ả|ã|ạ|â|ă|ấ|ầ|ẩ|ẫ|ậ|ắ|ằ|ẳ|ẵ|ặ]", "a", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[é|è|ẻ|ẽ|ẹ|ê|ế|ề|ể|ễ|ệ]", "e", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[ú|ù|ủ|ũ|ụ|ư|ứ|ừ|ử|ữ|ự]", "u", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[í|ì|ỉ|ĩ|ị]", "i", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[ó|ò|ỏ|õ|ọ|ô|ơ|ố|ồ|ổ|ỗ|ộ|ớ|ờ|ở|ỡ|ợ]", "o", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[đ|Đ]", "d", RegexOptions.IgnoreCase);
            Unicode = Regex.Replace(Unicode, "[ý|ỳ|ỷ|ỹ|ỵ|Ý|Ỳ|Ỷ|Ỹ|Ỵ]", "y", RegexOptions.IgnoreCase);
            return Unicode.ToLower().Replace(" ", "");
        }
        #endregion
    }


}
