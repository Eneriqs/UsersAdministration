using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAdmin.Helpers
{
    internal static  class Helper
    {
        /// <summary>
        /// Gets the type of the attribute of.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumVal">The enum value.</param>
        /// <returns></returns>
        public static T GetAttributeOfType<T>( Enum enumVal) where T : System.Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static bool ValidateControlIsEmpty(ErrorProvider epValid, Control control, string errorMessage, string startedMessage="")
        {
            bool validate = false;
            try
            {
                if (string.IsNullOrEmpty(control.Text) || (!string.IsNullOrEmpty(startedMessage) && control.Text.Equals(startedMessage)))
                {
                    epValid.SetError(control, errorMessage);
                }
                else
                {
                    validate = true;
                    epValid.SetError(control, "");
                }
               // control.Refresh();
            }
            catch { }
            return validate;
        }

        public static string UrlPathCombine(string path1, string path2)
        {
            path1 = path1.TrimEnd('/') + "/";
            path2 = path2.TrimStart('/');

            return Path.Combine(path1, path2)
                .Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        }

    }
}
