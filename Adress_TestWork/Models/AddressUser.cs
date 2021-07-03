using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

using Adress_TestWork.Resource;

namespace Adress_TestWork.Models
{
	[Serializable]
	public sealed class AddressUser : IDataErrorInfo
	{
		private const int MinLengthString = 2;
		private const int MaxLengthString = 50;

		[XmlElement] public uint Id { get; set; }

		[XmlElement(IsNullable = true)] public string FirstName { get; set; }

		[XmlElement(IsNullable = true)] public string SecondName { get; set; }

		[XmlElement(IsNullable = true)] public string TreeName { get; set; }

		[XmlElement(IsNullable = true)] public string Telephone { get; set; }


		private string NamesValidationError(string value)
		{
			if (value is null || value.Length is < MinLengthString or > MaxLengthString || Regex.IsMatch
					(value, @"\d+", RegexOptions.Compiled))
				return Localize.ErrorName;

			return string.Empty;
		}

		private string TelephoneValidationError(string value)
		{
			if (value is null || !Regex.IsMatch
				(
					value, @"\+7-\d{3}-\d{3}-\d{2}-\d{2}",
					RegexOptions.Compiled | RegexOptions.IgnoreCase
				))
				return Localize.ErrorTelephoneNumber;

			return string.Empty;
		}



		#region Implementation of IDataErrorInfo

		public string Error { get; private set; }

		/// <inheritdoc />
		public string this[string columnName]
		{
			get
			{
				Error = columnName switch
				{
					nameof(FirstName) => NamesValidationError(FirstName),
					nameof(SecondName) => NamesValidationError(SecondName),
					nameof(TreeName) => NamesValidationError(TreeName),
					nameof(Telephone) => TelephoneValidationError(Telephone),
					_ => string.Empty
				};

				return Error;
			}
		}

		#endregion
	}
}