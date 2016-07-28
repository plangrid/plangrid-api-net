// <copyright file="Date.cs" company="PlanGrid, Inc.">
//     Copyright (c) 2016 PlanGrid, Inc. All rights reserved.
// </copyright>
using System;
using System.Globalization;

namespace PlanGrid.Api
{
    public struct Date
    {
        public const string Format = "yyyy-MM-dd";

        private readonly DateTime when;

        public Date(DateTime when)
        {
            this.when = when.Date;
        }

        public Date(int year, int month, int day) : this(new DateTime(year, month, day))
        {
        }

        public static implicit operator DateTime(Date date)
        {
            return date.when;
        }

        public static implicit operator Date(DateTime dateTime)
        {
            return new Date(dateTime);
        }

        public override string ToString()
        {
            return when.ToString(Format, CultureInfo.InvariantCulture);
        }

        public static Date Parse(string s)
        {
            return DateTime.ParseExact(s, Format, CultureInfo.InvariantCulture);
        }

        public override int GetHashCode()
        {
            return when.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as Date?;
            return other != null && when.Equals(other.Value.when);
        }

        public static bool operator ==(Date left, Date right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Date left, Date right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(Date left, Date right)
        {
            return left.when < right.when;
        }

        public static bool operator >(Date left, Date right)
        {
            return left.when > right.when;
        }
    }
}
