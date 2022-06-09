namespace WhatToCook.Application.Extensions
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static string Capitalize(this string value)
        {
            if(value.IsEmpty())
            {
                throw new ArgumentNullException(nameof(value));
            }

            var nameLowerCased = value.ToLower();
            return nameLowerCased[0].ToString().Trim().ToUpper() + nameLowerCased[1..];
        }
    }
}
