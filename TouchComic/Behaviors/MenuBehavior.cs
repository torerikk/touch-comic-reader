using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace TouchComic.Behaviors
{
	public class MenuItemExtensions : DependencyObject
	{
		public static Dictionary<MenuItem, String> ElementToGroupNames = new Dictionary<MenuItem, String>();

		public static readonly DependencyProperty GroupNameProperty = DependencyProperty.RegisterAttached("GroupName",
										 typeof(String),
										 typeof(MenuItemExtensions),
										 new PropertyMetadata(String.Empty, OnGroupNameChanged));

		public static void SetGroupName(MenuItem element, String value)
		{
			element.SetValue(GroupNameProperty, value);
		}

		public static String GetGroupName(MenuItem element)
		{
			return element.GetValue(GroupNameProperty).ToString();
		}

		private static void OnGroupNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			//Add an entry to the group name collection
			var menuItem = d as MenuItem;

			if (menuItem != null)
			{
				String newGroupName = e.NewValue.ToString();
				String oldGroupName = e.OldValue.ToString();
				if (String.IsNullOrEmpty(newGroupName))
				{
					//Removing the toggle button from grouping
					RemoveCheckboxFromGrouping(menuItem);
				}
				else
				{
					//Switching to a new group
					if (newGroupName != oldGroupName)
					{
						if (!String.IsNullOrEmpty(oldGroupName))
						{
							//Remove the old group mapping
							RemoveCheckboxFromGrouping(menuItem);
						}
						ElementToGroupNames.Add(menuItem, e.NewValue.ToString());
						menuItem.Checked += MenuItemChecked;
					}
				}
			}
		}

		private static void RemoveCheckboxFromGrouping(MenuItem checkBox)
		{
			ElementToGroupNames.Remove(checkBox);
			checkBox.Checked -= MenuItemChecked;
		}

		private static void MenuItemChecked(object sender, RoutedEventArgs e)
		{
			var menuItem = e.OriginalSource as MenuItem;
			foreach (var item in ElementToGroupNames)
			{
				if (item.Key != menuItem && item.Value == GetGroupName(menuItem))
				{
					item.Key.IsChecked = false;
				}
			}
		}
	}

	// A more advanced solution but I couldn't get it to keep just one item checked.
	//
	//public static class MenuBehavior
	//{
	//    [AttachedPropertyBrowsableForType(typeof(MenuItem))]
	//    public static string GetOptionGroupName(MenuItem obj)
	//    {
	//        return (string)obj.GetValue(OptionGroupNameProperty);
	//    }

	//    public static void SetOptionGroupName(MenuItem obj, string value)
	//    {
	//        obj.SetValue(OptionGroupNameProperty, value);
	//    }

	//    public static readonly DependencyProperty OptionGroupNameProperty =
	//    DependencyProperty.RegisterAttached(
	//          "OptionGroupName",
	//          typeof(string),
	//          typeof(MenuBehavior),
	//          new UIPropertyMetadata(
	//            null,
	//            OptionGroupNameChanged));

	//    private static void OptionGroupNameChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	//    {
	//        var menuItem = o as MenuItem;
	//        if (menuItem == null)
	//            return;

	//        var oldValue = (string)e.OldValue;
	//        var newValue = (string)e.NewValue;

	//        if (!string.IsNullOrEmpty(oldValue))
	//        {
	//            RemoveFromOptionGroup(menuItem);
	//        }
	//        if (!string.IsNullOrEmpty(newValue))
	//        {
	//            AddToOptionGroup(menuItem);
	//        }
	//    }

	//    private static Dictionary<string, HashSet<MenuItem>> GetOptionGroups(DependencyObject obj)
	//    {
	//        return (Dictionary<string, HashSet<MenuItem>>)obj.GetValue(OptionGroupsPropertyKey.DependencyProperty);
	//    }

	//    private static void SetOptionGroups(DependencyObject obj, Dictionary<string, HashSet<MenuItem>> value)
	//    {
	//        obj.SetValue(OptionGroupsPropertyKey, value);
	//    }

	//    private static readonly DependencyPropertyKey OptionGroupsPropertyKey =
	//    DependencyProperty.RegisterAttachedReadOnly("OptionGroups", typeof(Dictionary<string, HashSet<MenuItem>>), typeof(MenuBehavior), new UIPropertyMetadata(null));

	//    private static HashSet<MenuItem> GetOptionGroup(MenuItem menuItem, bool create)
	//    {
	//        string groupName = GetOptionGroupName(menuItem);
	//        if (groupName == null)
	//            return null;

	//        if (menuItem.Parent == null)
	//            return null;

	//        var optionGroups = GetOptionGroups(menuItem.Parent);
	//        if (optionGroups == null)
	//        {
	//            if (create)
	//            {
	//                optionGroups = new Dictionary<string, HashSet<MenuItem>>();
	//                SetOptionGroups(menuItem.Parent, optionGroups);
	//            }
	//            else
	//            {
	//                return null;
	//            }
	//        }

	//        HashSet<MenuItem> group;
	//        if (!optionGroups.TryGetValue(groupName, out group) && create)
	//        {
	//            group = new HashSet<MenuItem>();
	//            optionGroups[groupName] = group;
	//        }
	//        return group;
	//    }

	//    private static void AddToOptionGroup(MenuItem menuItem)
	//    {
	//        var group = GetOptionGroup(menuItem, true);
	//        if (group == null)
	//            return;

	//        if (group.Add(menuItem))
	//        {
	//            menuItem.Checked += menuItem_Checked;
	//            menuItem.Unchecked += menuItem_Unchecked;
	//        }
	//    }

	//    private static void RemoveFromOptionGroup(MenuItem menuItem)
	//    {
	//        var group = GetOptionGroup(menuItem, false);
	//        if (group == null)
	//            return;

	//        if (group.Remove(menuItem))
	//        {
	//            menuItem.Checked -= menuItem_Checked;
	//            menuItem.Unchecked -= menuItem_Unchecked;
	//        }
	//    }

	//    private static void menuItem_Checked(object sender, RoutedEventArgs e)
	//    {
	//        MenuItem menuItem = sender as MenuItem;
	//        if (menuItem == null)
	//            return;

	//        string groupName = GetOptionGroupName(menuItem);
	//        if (groupName == null)
	//            return;

	//        // More than 1 checked option is allowed
	//        if (groupName.EndsWith("*") || groupName.EndsWith("+"))
	//            return;

	//        var group = GetOptionGroup(menuItem, false);
	//        if (group == null)
	//            return;

	//        foreach (var item in group)
	//        {
	//            if (item != menuItem)
	//                item.IsChecked = false;
	//        }
	//    }

	//    private static void menuItem_Unchecked(object sender, RoutedEventArgs e)
	//    {
	//        MenuItem menuItem = sender as MenuItem;
	//        if (menuItem == null)
	//            return;

	//        string groupName = GetOptionGroupName(menuItem);
	//        if (groupName == null)
	//            return;

	//        // 0 checked option is allowed
	//        if (groupName.EndsWith("*") || groupName.EndsWith("?"))
	//            return;

	//        var group = GetOptionGroup(menuItem, false);
	//        if (group == null)
	//            return;

	//        if (!group.Any(item => item.IsChecked))
	//            menuItem.IsChecked = true;
	//    }
	//}
}