﻿using System.ComponentModel;
using System.Text.RegularExpressions;

using Adress_TestWork.Resource;

namespace Adress_TestWork.Models
{
    public sealed class AddressUser : IDataErrorInfo
    {
        public string FirstName { get; set; }
        public uint Id { get; set; }
        public string SecondName { get; set; }
        public string Telephone { get; set; }
        public string TreeName { get; set; }

        private string NamesValidationError(string value)
        {
            if (value is null) return string.Empty;
            if (value.Length is < MinLengthString or > MaxLengthString || Regex.IsMatch
                    (value, @"\d+", RegexOptions.Compiled))
                return Localize.ErrorName;

            return string.Empty;
        }

        private string TelephoneValidationError(string value)
        {
            if (value is null) return string.Empty;
            if (!Regex.IsMatch
                (
                    value, @"\+7-\d{3}-\d{3}-\d{2}-\d{2}",
                    RegexOptions.Compiled | RegexOptions.IgnoreCase
                ))
                return Localize.ErrorTelephoneNumber;

            return string.Empty;
        }

        private const int MinLengthString = 2;
        private const int MaxLengthString = 50;

#region Implementation of IDataErrorInfo

        /// <inheritdoc />
        public string Error { get; private set; }

        /// <inheritdoc />
        public string this[string columnName]
        {
            get
            {
                Error = columnName switch
                {
                    nameof(FirstName)  => NamesValidationError(FirstName),
                    nameof(SecondName) => NamesValidationError(SecondName),
                    nameof(TreeName)   => NamesValidationError(TreeName),
                    nameof(Telephone)  => TelephoneValidationError(Telephone), _ => string.Empty
                };

                return Error;
            }
        }

#endregion
    }
}