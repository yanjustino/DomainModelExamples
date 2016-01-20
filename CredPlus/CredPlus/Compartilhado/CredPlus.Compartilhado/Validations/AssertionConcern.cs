using System;
using System.Text.RegularExpressions;

namespace CredPlus.Compartilhado.Validations
{
    public static class AssertionConcern
    {
        public static Notification AssertLength(string stringValue, int minimum, int maximum, string message)
        {
            var length = stringValue?.Trim().Length;

            return (length < minimum || length > maximum)
                ? new Notification(message)
                : null;
        }

        public static Notification AssertMatches(string pattern, string stringValue, string message)
        {
            var regex = new Regex(pattern);

            return (!regex.IsMatch(stringValue))
                ? new Notification(message)
                : null;
        }

        public static Notification AssertNotEmpty(string stringValue, string message)
        {
            return (string.IsNullOrEmpty(stringValue))
                ? new Notification(message)
                : null;
        }

        public static Notification AssertNotNull(object object1, string message)
        {
            return (object1 == null)
                ? new Notification(message)
                : null;
        }

        public static Notification AssertIsNull(object object1, string message)
        {
            return (object1 != null)
                ? new Notification(message)
                : null;
        }

        public static Notification AssertTrue(bool boolValue, string message)
        {
            return (!boolValue)
                ? new Notification(message)
                : null;
        }

        public static Notification AssertAreEquals(string value, string match, string message)
        {
            return (!(value == match))
                ? new Notification(message)
                : null;
        }

        public static Notification AssertIsGreaterThan(int value1, int value2, string message)
        {
            return (!(value1 > value2))
                ? new Notification(message)
                : null;
        }

        public static Notification AssertIsGreaterThan(decimal value1, decimal value2, string message)
        {
            return (!(value1 > value2))
                ? new Notification(message)
                : null;
        }

        public static Notification AssertIsGreaterOrEqualThan(int value1, int value2, string message)
        {
            return (!(value1 >= value2))
                ? new Notification(message)
                : null;
        }

        public static Notification AssertRegexMatch(string value, string regex, string message)
        {
            return (!Regex.IsMatch(value, regex, RegexOptions.IgnoreCase))
                ? new Notification(message)
                : null;
        }

        public static Notification AssertEmailIsValid(string email, string message)
        {
            var emailRegex =
                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

            return (!Regex.IsMatch(email, emailRegex, RegexOptions.IgnoreCase))
                ? new Notification(message)
                : null;
        }

        public static Notification AssertUrlIsValid(string url, string message)
        {
            // Do not validate if no URL is provided
            // You can call AssertNotEmpty before this if you want
            if (String.IsNullOrEmpty(url))
                return null;

            var regex = @"^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$";

            return (!Regex.IsMatch(url, regex, RegexOptions.IgnoreCase))
                ? new Notification(message)
                : null;
        }

    }
}
