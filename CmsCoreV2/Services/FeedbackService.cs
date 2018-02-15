using CmsCoreV2.Data;
using CmsCoreV2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using SaasKit.Multitenancy;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CmsCoreV2.Services
{
    public interface IFeedbackService
    {
        IEnumerable<Form> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
    
        bool FeedbackPost(IFormCollection collection, string ip, string appTenantId, IFormFile[] upload);
        void FeedbackPostMail(string body, long id, IFormFile[] upload);
        Form GetForm(long id);
        Form GetForm(string name);
        void DeleteForm(long id);
        long FormCount();
        List<FormField> GetFormFieldsByFormId(long id);
        void SaveForm();
        void FeedbackSendUserMail(Form form, Feedback feedback);
        void FeedbackSendUserSMS(Form form, Feedback feedback);
    }

    public class FeedbackService:IFeedbackService
    {
        private readonly DbSet<Feedback> dbSet;
        private ApplicationDbContext DbContext;
        protected readonly AppTenant tenant;
        public FeedbackService(ApplicationDbContext context, ITenant<AppTenant> tenant)
        {
            DbContext = context;
            this.tenant = tenant?.Value;
            this.dbSet = DbContext.Feedbacks;
        }

        public bool FeedbackPost(IFormCollection collection, string ip, string appTenantId, IFormFile[] upload)
        {
            Feedback feed_back = new Feedback();
            feed_back.IP = ip;
            feed_back.AppTenantId = appTenantId;
            var formId = Convert.ToInt64(collection["Id"]);
            if (formId == 0) {
                formId = Convert.ToInt64(collection["FormId"]);
            }
            var form = GetForm(formId);
            var body = "";
            foreach (var item in GetFormFieldsByFormId(formId))
            {
                var feedBackValue = new FeedbackValue();

                feedBackValue.FormFieldName = item.Name;
                feedBackValue.FieldType = item.FieldType;
                feedBackValue.FormFieldId = (int)item.Id;
                feedBackValue.Position = item.Position;
                feedBackValue.CreatedBy = "username";
                feedBackValue.CreateDate = DateTime.Now;
                feedBackValue.UpdatedBy = "username";
                feedBackValue.UpdateDate = DateTime.Now;
                feedBackValue.AppTenantId = appTenantId;

                foreach (var item2 in collection)
                {
                    if (item.Name == item2.Key)
                    {
                        if (item.Required && string.IsNullOrEmpty(item2.Value))
                        {
                            return false;
                        }
                        feedBackValue.Value = item2.Value;
                        body = body + item2.Key + " : " + item2.Value + "<br/>";
                    }
                }

                feed_back.FeedbackValues.Add(feedBackValue);
            }
            //feedBack.IP = GetUserIP();  // gönderen ip method u eklenecek

            //var remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;


            feed_back.FormId = (int)form.Id;
            feed_back.FormName = form.FormName;

            //feed_back.IP = remoteIpAddress.ToString();
            feed_back.SentDate = DateTime.Now;
            feed_back.UserName = "username";
            feed_back.CreatedBy = "username";
            feed_back.CreateDate = DateTime.Now;
            feed_back.UpdateDate = DateTime.Now;
            feed_back.UpdatedBy = "username";
         
            CreateFeedback(feed_back);
            SaveFeedback();
            if (form.SendMailToUser)
            {
                FeedbackSendUserMail(form, feed_back);
            }
            if (form.SendSMS1ToUser)
            {
                FeedbackSendUserSMS(form, feed_back);
            }
            if (form.SendSMS2ToUser)
            {
                FeedbackSendUserSMS2(form, feed_back);
            }

            body = body + "<br>" + "Gönderilme Tarihi : " + DateTime.Now;
            FeedbackPostMail(body, form.Id,upload);
            //return feed_back.FeedbackValues.ToList();
            return true;
        }

        public void CreateFeedback(Feedback Feedback)
        {
            DbContext.Add(Feedback);
        }

        public void SaveFeedback()
        {
            Commit();
        }
        // kullanıcıya e-posta gönderimi
        public void FeedbackSendUserMail(Form form, Feedback feedback)
        {
            var message = new MailMessage();
            string toEmail = feedback.FeedbackValues.OrderBy(o => o.Position).FirstOrDefault(f => f.FieldType == FieldType.email)?.Value;
            if (!String.IsNullOrEmpty(toEmail)) {
                message.To.Add(new MailAddress(toEmail));
                message.ReplyToList.Add(new MailAddress("bilgi@bilgikoleji.com"));
                message.Body = form.UserMailContent;
                message.Subject = form.UserMailSubject;
                message.IsBodyHtml = true;
                var setting = DbContext.Settings.FirstOrDefault();
                message.From = new MailAddress(setting.SmtpUserName, tenant.Name);
                try
                {
                    using (var client = new SmtpClient(setting.SmtpHost, Convert.ToInt32(setting.SmtpPort)))
                    {
                        client.EnableSsl = setting.SmtpUseSSL;
                        client.Credentials = new System.Net.NetworkCredential(setting.SmtpUserName, setting.SmtpPassword);
                        client.Send(message);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
        public void FeedbackSendUserSMS(Form form, Feedback feedback)
        {
            var setting = DbContext.Settings.FirstOrDefault();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://api.216bilisim.com/sms/send/single?key=" + setting.SmsApiToken + "&secret=" + setting.SmsApiScreet);

            request.Method = "POST";
            request.UserAgent = "global_sms";
            request.ContentType = "application/x-www-form-urlencoded";

            dynamic obj = new ExpandoObject();
            obj.turkish_character = "1";
            string number = feedback.FeedbackValues.OrderBy(o => o.Position).FirstOrDefault(f => f.FieldType == FieldType.telephone)?.Value.ToString();
            if (number.IndexOf(' ') >= 0)
            {
                number = number.Remove(number.IndexOf(' '), 1);
            }
            if (number.IndexOf(',')>=0) { 
            number = number.Remove(number.IndexOf(','), 1);
            }
            number = number.Remove(0, 1);
            obj.numbers = number;
            obj.text = form.UserSMS1;
            obj.originator = "BILGIKOLEJI";
            obj.time = "now";

            string json_string = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            string postData = System.Web.HttpUtility.UrlEncode(json_string);

            byte[] data = Encoding.ASCII.GetBytes("data=" + postData);

            request.ContentLength = data.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            requestStream.Close();

            WebResponse resp = request.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);

            string s = sr.ReadToEnd();

            sr.Close();

            
            dynamic json = JObject.Parse(s);

            if (json.result == false)
            {
                foreach (var error in json.errors)
                {
                    throw new Exception(error.error_text.ToString() + "(" + error.error_code.ToString() + ")");
                }

            }
            else if (json.result == true)
            {
               // başarılı
            }
        }
        public void FeedbackSendUserSMS2(Form form, Feedback feedback)
        {
            var setting = DbContext.Settings.FirstOrDefault();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://api.216bilisim.com/sms/send/single?key=" + setting.SmsApiToken + "&secret=" + setting.SmsApiScreet);

            request.Method = "POST";
            request.UserAgent = "global_sms";
            request.ContentType = "application/x-www-form-urlencoded";

            dynamic obj = new ExpandoObject();
            obj.turkish_character = "1";
            string number = feedback.FeedbackValues.OrderBy(o => o.Position).FirstOrDefault(f => f.FieldType == FieldType.telephone)?.Value.ToString();
            if (number.IndexOf(' ') >= 0)
            {
                number = number.Remove(number.IndexOf(' '), 1);
            }
            if (number.IndexOf(',') >= 0)
            {
                number = number.Remove(number.IndexOf(','), 1);
            }
            number = number.Remove(0, 1);
            var parameter = feedback.FeedbackValues.FirstOrDefault(f => f.FormFieldName == "Sınav Tarihi").Value;
            string date = "";
            string time = "";
            if (parameter.IndexOf(" Saat")>=0)
            {
                date = parameter.Substring(0, parameter.IndexOf(" Saat"));
                time = parameter.Substring(parameter.Length - 5);
            }
            DateTime datetime;
            DateTime.TryParseExact(date + " " + time, "dd MMMM yyyy HH:mm", new CultureInfo("tr-TR"), DateTimeStyles.None, out datetime);

            obj.numbers = number;
            obj.text = string.Format(form.UserSMS2,datetime.ToString("dd MMMM yyyy dddd"), datetime.ToString("HH:mm"));
            obj.originator = "BILGIKOLEJI";
            obj.time = datetime.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss");

            string json_string = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            string postData = System.Web.HttpUtility.UrlEncode(json_string);

            byte[] data = Encoding.ASCII.GetBytes("data=" + postData);

            request.ContentLength = data.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            requestStream.Close();

            WebResponse resp = request.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);

            string s = sr.ReadToEnd();

            sr.Close();


            dynamic json = JObject.Parse(s);

            if (json.result == false)
            {
                foreach (var error in json.errors)
                {
                    throw new Exception(error.error_text.ToString() + "(" + error.error_code.ToString() + ")");
                }

            }
            else if (json.result == true)
            {
                // başarılı
            }
        }
        // geri bildirim için e-posta gönderimi
        public void FeedbackPostMail(string body, long id, IFormFile[] upload)
        {
            var form = GetForm(id);
            if (form.EmailBcc != null || form.EmailCc != null || form.EmailTo != null)
            {
                var message = new MailMessage();
                if (form.EmailCc != null)
                {
                    var email_cc_list = form.EmailCc.Split(',');
                    foreach (var item2 in email_cc_list)
                    {
                        message.CC.Add(new MailAddress(item2.Trim(), item2.Trim()));
                    }
                }
                if (form.EmailBcc != null)
                {
                    var email_bcc_list = form.EmailBcc.Split(',');
                    foreach (var item2 in email_bcc_list)
                    {
                        message.Bcc.Add(new MailAddress(item2.Trim(), item2.Trim()));
                    }
                }
                if (form.EmailTo != null)
                {
                    var email_to_list = form.EmailTo.Split(',');
                    foreach (var item2 in email_to_list)
                    {
                        message.To.Add(new MailAddress(item2.Trim(), item2.Trim()));
                    }
                }
                var setting = DbContext.Settings.FirstOrDefault();
                message.From = new MailAddress(setting.SmtpUserName, tenant.Name);
                
                
                message.Subject = tenant.Name + " " + form.FormName;
                // foreach (var item in feed_back.FeedbackValues)
                //{
                //message.Body += EmailString(item).ToString() + "<br/>";
                message.Body += body;
                message.IsBodyHtml = true;
                //}
                //foreach (var file in upload)
                //{
                //    if (upload != null)
                //    {
                          //using (var fileStream = file.OpenReadStream())
                          //  using (var ms = new MemoryStream())
                          //  {
                          //      fileStream.CopyTo(ms);
                          //      var fileBytes = ms.ToArray();
                          //      string s = Convert.ToBase64String(fileBytes);
                          //      // act on the Base64 data
                          //  }
                        foreach (var attachment in upload)
                        {
                            message.Attachments.Add(new Attachment(attachment.OpenReadStream(),attachment.FileName, attachment.ContentType));
                        }
                //    }
                //}
               
                try
                {
                    using (var client = new SmtpClient(setting.SmtpHost, Convert.ToInt32(setting.SmtpPort)))
                    {
                        client.EnableSsl = setting.SmtpUseSSL;
                        client.Credentials = new System.Net.NetworkCredential(setting.SmtpUserName, setting.SmtpPassword);
                        client.Send(message);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public IEnumerable<Form> FormSearch(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');


            var query = this.DbContext.Forms.AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {

                    query = query.Where(c => c.FormName.Contains(sSearch) || c.Id.ToString().Contains(sSearch));
                }
            }
            var allForms = query;

            IEnumerable<Form> filteredForms = allForms;
            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredForms = filteredForms.OrderBy(c => c.Id);
                        break;
                    case 2:
                        filteredForms = filteredForms.OrderBy(c => c.FormName);
                        break;
                    default:
                        filteredForms = filteredForms.OrderBy(c => c.Id);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {

                    case 1:
                        filteredForms = filteredForms.OrderByDescending(c => c.Id);
                        break;
                    case 2:
                        filteredForms = filteredForms.OrderByDescending(c => c.FormName);
                        break;
                    default:
                        filteredForms = filteredForms.OrderByDescending(c => c.Id);
                        break;
                }
            }

            var displayedForms = filteredForms.Skip(displayStart);
            if (displayLength > 0)
            {
                displayedForms = displayedForms.Take(displayLength);
            }
            totalRecords = allForms.Count();
            totalDisplayRecords = filteredForms.Count();
            return displayedForms.ToList();
        }
        public IEnumerable<Form> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            var forms = FormSearch(search, sortColumnIndex, sortDirection, displayStart, displayLength, out totalRecords, out totalDisplayRecords);

            return forms;
        }
        public IEnumerable<Feedback> GetAll(params string[] navigations)
        {
            var set = DbContext.Feedbacks.AsQueryable();
            foreach (string nav in navigations)
                set = set.Include(nav);
            return set.AsEnumerable();
        }
        public IEnumerable<Feedback> GetForms()
        {
            var forms = GetAll(); // içerde FormField yazıyordu
            return forms;
        }
        public Feedback GetById(long id, params string[] navigations)
        {
            var set = DbContext.Feedbacks.AsQueryable();
            foreach (string nav in navigations)
                set = set.Include(nav);

            return set.FirstOrDefault(f => f.Id == id);
        }
        public Form GetFormById(long id, params string[] navigations)
        {
            var set = DbContext.Forms.AsQueryable();
            foreach (string nav in navigations)
                set = set.Include(nav);

            return set.FirstOrDefault(f => f.Id == id);
        }
        public Form GetForm(long id)
        {
            var form = GetFormById(id, "FormFields");
            return form;
        }
        public Feedback Get(Expression<Func<Feedback, bool>> where, params string[] navigations)
        {
            var set = DbContext.Feedbacks.AsQueryable();
            foreach (string nav in navigations)
                set = set.Include(nav);
            return set.Where(where).FirstOrDefault<Feedback>();
        }
        public Form GetForm(string name)
        {
            name = name.ToLower();
            var form = DbContext.Forms.AsQueryable().Include("FormFields").Where(f => f.FormName.ToLower() == name).FirstOrDefault();
            return form;
        }
        public List<FormField> GetFormFieldsByFormId(long id)
        {
            Form form = GetFormById(id, "FormFields");
            return form.FormFields.OrderBy(c => c.Position).ToList();
        }
        public virtual void Add(Feedback entity)
        {
            var date = DateTime.Now;
            entity.CreatedBy = "username";
            entity.CreateDate = date;
            entity.UpdatedBy = "username";
            entity.UpdateDate = date;
            entity.AppTenantId = tenant.AppTenantId;
            DbContext.Add(entity);
        }

        public virtual void Update(Feedback entity)
        {
            entity.UpdatedBy = "username";
            entity.UpdateDate = DateTime.Now;
            entity.AppTenantId = tenant.AppTenantId;
            dbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(Feedback entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<Feedback, bool>> where)
        {
            IEnumerable<Feedback> objects = dbSet.Where<Feedback>(where).AsEnumerable();
            foreach (Feedback obj in objects)
                dbSet.Remove(obj);
        }
        public void CreateForm(Feedback feedback)
        {
            Add(feedback);
        }
        public void UpdateForm(Feedback feedback)
        {
            Update(feedback);
        }
        public void DeleteForm(long id)
        {
            Delete(f => f.Id == id);
        }
        

        public void Commit()
        {
            try
            {
                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void SaveForm()
        {
            Commit();
        }
        public long FormCount()
        {
            return GetAll().Count();
        }
    }
}
