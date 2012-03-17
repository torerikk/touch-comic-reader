using System;
using System.ComponentModel;
using System.Reflection;

namespace TouchComic
{
	public enum ZoomMode
	{
		[Description("Fit")]
		Fit,
		[Description("Fit width")]
		FitWidth,
		[Description("Fit height")]
		FitHeight,
		[Description("100 %")]
		Original
		//Custom
		//Zoom50,
		//Zoom100,
		//Zoom150,
		//Zoom200
	}

	public enum OptionScrollOnNavigate : int
	{
		[Description("No scroll")]
		NoScroll = 0,
		[Description("Top left")]
		TopLeft = 1,
		//Top_Center = 2,
		[Description("Top right")]
		TopRight = 3,
		//Center_Left = 4,
		// Center = 5,
		// Center_Right = 6,
		[Description("Bottom left")]
		BottomLeft = 7,
		//BottomCenter = 8,
		[Description("Bottom right")]
		BottomRight = 9
	}

	public enum OptionOpenFilePath : int
	{
		[Description("Use current path")]
		UseWindowsCurrent = 0,
		[Description("Use default path")]
		UseDefaultPath = 1,
		[Description("Start with default path")]
		StartWithDefaultPath = 2,
		[Description("Remember last used")]
		RememberLastUsed = 3
	}

	public static class EnumExtensions
	{
		public static string ToDescription(this Enum en)
		{
			Type type = en.GetType();
			MemberInfo[] memInfo = type.GetMember(en.ToString());
			if (memInfo != null && memInfo.Length > 0)
			{
				object[] attrs = memInfo[0].GetCustomAttributes(
											  typeof(DescriptionAttribute),
											  false);
				if (attrs != null && attrs.Length > 0)
					return ((DescriptionAttribute)attrs[0]).Description;
			}
			return en.ToString();
		}
	}
}