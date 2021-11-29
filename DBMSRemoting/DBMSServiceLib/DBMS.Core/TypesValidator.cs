using System;
using System.Collections.Generic;
using System.Text;

namespace DBMS.Core
{
    public static class TypesValidator
    {
        private static readonly string pngExtension = ".png";
        public static bool IsValidValue(string customTypeName, string value)
        {
            switch (customTypeName)
            {
                case "Integer":
                    return ValidateInteger(value);

                case "Real":
                    return ValidateReal(value);
                
                case "Char":
                    return ValidateChar(value);

                case "String":
                    return ValidateString(value);

                case "Time":
                    return ValidateTime(value);

                case "TimeInvl":
                    return ValidateTimeInvl(value);

                default:
                    return false;
            }
        }

        private static bool ValidateChar(string value)
        {
            char buf;
            if (char.TryParse(value, out buf))
            {
                return true;
            }
            return false;
        }

        private static bool ValidateInteger(string value)
        {
            int buf;
            if (int.TryParse(value, out buf))
            {
                return true;
            }
            return false;
        }

        private static bool ValidateReal(string value)
        {
            double buf;
            if (double.TryParse(value, out buf))
            {
                return true;
            }
            return false;
        }


        private static bool ValidateString(string value)
        {
            return true;
        }

        private static bool ValidateTime(string value)
        {
            try
            {
                if (value.Length > 5 || value.Length < 4) return false;
                if (value[value.Length - 3] != ':') return false;
                string hh = value.Length == 4 ? value.Substring(0, 1) : value.Substring(0, 2);
                string mm = value.Substring(value.IndexOf(':') + 1);
                int h, m;
                if (!int.TryParse(hh, out h) || !int.TryParse(mm, out m)) return false;
                if (h > 23 || m > 59) return false;
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static bool ValidateTimeInvl(string value)
        {
            int f, t;
            string[] q = value.Split('-');
            if (q.Length != 2) return false;
            string start, end;
            start = q[0].Trim();
            end = q[1].Trim();

            if (!validateTime(start) || !validateTime(end)) return false;
            if (!compare(start, end)) return false;

            return true;
        }

        private static bool validateTime(string value)
        {
            try
            {
                if (value.Length > 5 || value.Length < 4) return false;
                if (value[value.Length - 3] != ':') return false;
                string hh = value.Length == 4 ? value.Substring(0, 1) : value.Substring(0, 2);
                string mm = value.Substring(value.IndexOf(':') + 1);
                int h, m;
                if (!int.TryParse(hh, out h) || !int.TryParse(mm, out m)) return false;
                if (h > 23 || m > 59) return false;
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static bool compare(string start, string end)
        {
            string h1, m1, h2, m2;
            h1 = start.Length == 4 ? start.Substring(0, 1) : start.Substring(0, 2);
            m1 = start.Substring(start.IndexOf(':') + 1);
            h2 = end.Length == 4 ? end.Substring(0, 1) : end.Substring(0, 2);
            m2 = end.Substring(end.IndexOf(':') + 1);

            int hh1, mm1, hh2, mm2;
            int.TryParse(h1, out hh1);
            int.TryParse(h2, out hh2);
            int.TryParse(m1, out mm1);
            int.TryParse(m2, out mm2);

            if (hh1 > hh2) return false;
            else if (hh1 == hh2)
            {
                if (mm1 > mm2) return false;
            }

            return true;
        }
    }
}
