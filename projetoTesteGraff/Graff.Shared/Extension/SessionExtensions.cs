using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graff.Shared.Extension
{
    public static class SessionExtensions
    {
        public static T GetValue<T>(this System.Web.SessionState.HttpSessionState obj, string value)
        {
            if (string.IsNullOrEmpty(value) || obj == null || obj[value] == null)
            {
                return default;
            }
            try
            {
                return (T)Convert.ChangeType(obj[value], typeof(T));
            }
            catch
            {
                return (T)obj[value];
            }
        }
    }
}
