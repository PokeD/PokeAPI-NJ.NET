﻿using System.Text.RegularExpressions;

namespace PokeApi.NET.Tests
{
    public static class Extensions
    {

        /// <summary>
        /// Generates the slug. http://predicatet.blogspot.com.es/2009/04/improved-c-slug-generator-or-how-to.html
        /// </summary>
        /// <param name="phrase">The phrase.</param>
        /// <returns></returns>
        public static string GenerateSlug(this string phrase)
        {
            var str = phrase.RemoveAccent().ToLower();

            str = Regex.Replace(str, @"[^a-z0-9\s-]", ""); // invalid chars
            str = Regex.Replace(str, @"\s+", " ").Trim(); // convert multiple spaces into one space
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim(); // cut and trim it
            str = Regex.Replace(str, @"\s", "-"); // hyphens

            return str;
        }

        public static string RemoveAccent(this string txt)
        {
            var bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(txt);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }
    }
}