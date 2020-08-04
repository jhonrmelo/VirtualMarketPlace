using Microsoft.AspNetCore.Http;

namespace Service.Session
{
    public class SessionHelper
    {

        IHttpContextAccessor _contextAcessor;
        public SessionHelper(IHttpContextAccessor icontextAcessor)
        {
            _contextAcessor = icontextAcessor;
        }
        public void Put(string key, string value)
        {
            _contextAcessor.HttpContext.Session.SetString(key, value);
        }

        public void Update(string key, string value)
        {
            if (HasKey(key))
                _contextAcessor.HttpContext.Session.Remove(key);

            _contextAcessor.HttpContext.Session.SetString(key, value);
        }
        public void Remove(string key)
        {
            _contextAcessor.HttpContext.Session.Remove(key);
        }
        public string Get(string key)
        {
            return _contextAcessor.HttpContext.Session.GetString(key);
        }
        public bool HasKey(string key)
        {
            return _contextAcessor.HttpContext.Session.GetString(key) != null;
        }
        public void RemoveAll(string key)
        {
            _contextAcessor.HttpContext.Session.Clear();
        }
    }
}
