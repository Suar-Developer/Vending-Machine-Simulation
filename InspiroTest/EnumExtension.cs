using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace InspiroTest
{
    public static class EnumExtension
    {
        public static string ToDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static string ToDescription<T>(string strValue)
        {
            if (!string.IsNullOrEmpty(strValue) == true)
            {
                Type type = typeof(T);

                // Can't use generic type constraints on value types
                if (!type.IsEnum)
                    throw new InvalidCastException("T must be type of System.Enum");

                foreach (FieldInfo field in type.GetFields())
                {
                    DescriptionAttribute attribute = Attribute.GetCustomAttribute(field,
                        typeof(DescriptionAttribute)) as DescriptionAttribute;

                    if (attribute != null)
                    {
                        if (field.GetValue(null).ToString() == strValue)
                            return attribute.Description;
                    }
                    else
                    {
                        if (field.Name == strValue)
                            return field.Name;
                    }
                }

                throw new ArgumentException("Not found.", "description");

            }
            else
            {
                return strValue;
            }
        }

        public static T ToEnum<T>(this string description)
        {
            Type type = typeof(T);

            // Can't use generic type constraints on value types
            if (!type.IsEnum)
                throw new InvalidCastException("T must be type of System.Enum");

            foreach (FieldInfo field in type.GetFields())
            {
                DescriptionAttribute attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;

                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }

            throw new ArgumentException("Not found.", "description");
        }

        public static IEnumerable<T> EnumToList<T>()
        {
            Type enumType = typeof(T);

            // Can't use generic type constraints on value types
            if (enumType.BaseType != typeof(Enum))
                throw new InvalidCastException("T must be type of System.Enum");

            Array enumValArray = Enum.GetValues(enumType);
            List<T> enumValList = new List<T>(enumValArray.Length);

            foreach (int val in enumValArray)
            {
                enumValList.Add((T)Enum.Parse(enumType, val.ToString()));
            }

            return enumValList;
        }
    }
}
