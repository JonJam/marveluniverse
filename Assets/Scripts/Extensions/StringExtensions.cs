namespace MarvelUniverse.Extensions
{
    using System;
    using System.Text.RegularExpressions;
    using System.Web;

    /// <summary>
    /// The string extensions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// The HTML tag regular expression.
        /// </summary>
        private const string HTMLTagRegex = "<[^>]*>";

        /// <summary>
        /// Cleans a string.
        /// </summary>
        /// <param name="stringToClean">The string to clean.</param>
        /// <returns>A clean string.</returns>
        public static string Clean(this string stringToClean)
        {
            string cleanedString = null;

            if (!string.IsNullOrEmpty(stringToClean))
            {
                cleanedString = HttpUtility.HtmlDecode(stringToClean);

                cleanedString = Regex.Replace(cleanedString, StringExtensions.HTMLTagRegex, string.Empty);
            }
            else
            {
                cleanedString = stringToClean;
            }

            return cleanedString;
        }

        /// <summary>
        /// Converts a string representing a DateTime object to a formatted date.
        /// </summary>
        /// <param name="dateString">A string representing a DateTime object.</param>
        /// <returns>A formatted date.</returns>
        public static string ToDisplayDate(this string dateString)
        {
            DateTime date = DateTime.MinValue;

            string displayDate = null;

            if (!string.IsNullOrEmpty(dateString) &&
                DateTime.TryParse(dateString, out date))
            {
                displayDate = date.ToShortDateString();
            }

            return displayDate;
        }
    }
}
