using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using JulMar.Windows.Mvvm;

namespace TouchComic.ViewModel
{
	public class CheckValues<T> : SimpleViewModel where T : struct, IConvertible
	{
		private bool _IsChecked = false;
		private T _Value;
		private string _Text;

		public T Value
		{
			get { return _Value; }
			set
			{
				_Value = value;
				_Text = (value as Enum).ToDescription();
			}
		}

		public string Text { get { return _Text; } }

		public bool IsChecked
		{
			get { return _IsChecked; }
			set
			{
				_IsChecked = value;
				OnPropertyChanged("IsChecked");
			}
		}

		public ICommand Command { get; set; }
	}
}