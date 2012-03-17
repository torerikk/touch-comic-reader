using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TouchComic.ViewModel
{
	public class CheckValues<T> where T : struct, IConvertible
	{
		public T Value { get; set; }

		public string Text { get { return Value.ToString(); } }

		public bool IsChecked { get; set; }
	}

	public class ExclusiveCheckValues<T> where T : struct, IConvertible
	{
		public static T SelectedValue { get; set; }

		public T Value { get; set; }

		public string Text { get { return Value.ToString(); } }

		public bool IsChecked
		{
			get { return Value.Equals(SelectedValue); }
			set
			{
				if (value)
					SelectedValue = Value;
			}
		}
	}
}