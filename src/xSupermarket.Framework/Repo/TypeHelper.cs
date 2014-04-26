using System;

namespace xSupermarket.Framework.Repo
{
    public class TypeHelper
    {
        private static System.Globalization.CultureInfo provider = System.Globalization.CultureInfo.InvariantCulture;

        public static String ToString(object obj)
        {
            if (obj == null || obj is DBNull)
                return string.Empty;
            else
                return obj.ToString();
        }

        public static string ToString(float? value, string strType)
        {
            return value.HasValue ? value.Value.ToString(strType) : string.Empty;
        }

        public static string ToString(int? value, string strType)
        {
            return value.HasValue ? value.Value.ToString(strType) : string.Empty;
        }

        public static string ToString(DateTime? value, string strType)
        {
            return value.HasValue ? value.Value.ToString(strType) : string.Empty;
        }

        public static float? ToFloatNull(object obj)
        {
            return ToFloatNull(obj, false);
        }

        public static float? ToFloatNull(object obj, bool tag)
        {
            if (obj == null || obj is DBNull)
                return tag ? 0 : new float?();
            float p;
            if (float.TryParse(obj.ToString(), out p))
                return p;
            else
                return tag ? 0 : new float?();
        }

        public static int? ToInt32Null(object obj)
        {
            return ToInt32Null(obj, false);
        }

        public static int? ToInt32Null(object obj, bool tag)
        {
            if (obj == null || obj is DBNull)
                return tag ? 0 : new int?();
            int p;
            if (int.TryParse(obj.ToString(), out p))
                return p;
            else
                return tag ? 0 : new int?();
        }

        public static decimal? ToDecimalNull(object obj)
        {
            return ToDecimalNull(obj, false);
        }

        public static decimal? ToDecimalNull(object obj, bool tag)
        {
            if (obj == null || obj is DBNull)
                return tag ? 0 : new decimal?();
            decimal p;
            if (decimal.TryParse(obj.ToString(), out p))
                return p;
            else
                return tag ? 0 : new decimal?();
        }

        public static object ToDBValue(object obj)
        {
            if (obj == null)
            {
                return DBNull.Value;
            }
            else
            {
                return obj;
            }
        }
    }
}
