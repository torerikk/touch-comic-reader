namespace TouchComic
{
	public enum ZoomMode
	{
		Fit,
		FitWidth,
		FitHeight,
		Original,
		Custom
		//Zoom50,
		//Zoom100,
		//Zoom150,
		//Zoom200
	}

	public enum OptionScrollOnNavigate : int
	{
		NoScroll = 0,
		TopLeft = 1,
		//TopCenter = 2,
		TopRight = 3,
		//CenterLeft = 4,
		// Center = 5,
		// CenterRight = 6,
		BottomLeft = 7,
		//BottomCenter = 8,
		BottomRight = 9
	}

	public enum OptionOpenFilePath : int
	{
		UseWindowsCurrent = 0,
		UseDefaultPath = 1,
		StartWithDefaultPath = 2,
		RememberLastUsed = 3
	}
}