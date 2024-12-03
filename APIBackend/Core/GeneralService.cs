using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using APIBackend.DTOModels;
using APIBackend.Interface;
using System.Text;

namespace APIBackend.Core
{
    public class GeneralService
    {
        private DateTime today = DateTime.Now;
        private readonly IDomainService _domainService;

        public GeneralService(IDomainService domainService)
        {
            _domainService = domainService;
        }

        public string IDGenerator(string param)
        {
            string ret = string.Empty;
            string tmpToday = today.ToString("yyyyMMdd");

            if (!string.IsNullOrEmpty(param))
            {
                string tmpParam = param.Substring(0, 8);

                if (tmpParam == tmpToday)
                {
                    int numPar = Convert.ToInt32(Regex.Match(param, @"(.{4})\s*$").Value);
                    numPar = numPar + 1;
                    string tmpRet = numPar.ToString();

                    while (tmpRet.Length < 4)
                    {
                        tmpRet = "0" + tmpRet;
                    }

                    ret = tmpToday + tmpRet;
                }
                else
                {
                    ret = tmpToday + new String('0', 3) + AppConstant.first;
                }
            }
            else
            {
                ret = tmpToday + new String('0', 3) + AppConstant.first;
            }

            return ret;
        }

        public string SHA256Generator(string param)
        {
            SHA256 sha256Hash = SHA256.Create();
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(param));
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }

        public bool LoginCheck(string username, string token)
        {
            bool ret = false;
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");

            try
            {
                string tmpUser = rgx.Replace(username, "");
                string tmpToken = rgx.Replace(token, "");

                if(tmpUser == username &&  tmpToken == token)
                {
                    var getUser = _domainService.GetAllUsers().Where(x => x.Username == username).FirstOrDefault();

                    if(getUser != null)
                    {
                        var query = _domainService.GetAllSessions().Where(x => x.UserId == getUser.Id && x.Token == token).FirstOrDefault();

                        ret = query != null && query.DateExpired >= today ? true : false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Method: LoginCheck(), Username: {username}, Message: {ex.Message}");
            }

            return ret;
        }

        public void ExtendSession(string username, string token)
        {
            var transaction = _domainService.BeginTransaction();

            try
            {
                Regex rgx = new Regex("[^a-zA-Z0-9 -]");
                string tmpUser = rgx.Replace(username, "");
                string tmpToken = rgx.Replace(token, "");

                if (tmpUser == username && tmpToken == token)
                {
                    var getUser = _domainService.GetAllUsers().Where(x => x.Username == username).FirstOrDefault();

                    if (getUser != null)
                    {
                        var query = _domainService.GetAllSessions().Where(x => x.UserId == getUser.Id && x.Token == token).FirstOrDefault();
                        TimeSpan span = query.DateExpired.Subtract(today);

                        if(query != null && query.DateExpired >= today && span.TotalHours < AppConstant.timespan)
                        {
                            DateTime extend = query.DateExpired.AddHours(AppConstant.extSessionHours);
                            query.DateExpired = extend;

                            _domainService.UpdateSession(query);
                        }
                    }
                }

                transaction.Commit();
                _domainService.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Method: LoginCheck(), Username: {username}, Message: {ex.Message}");
            }
        }
    }
}
