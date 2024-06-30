using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection;

namespace repositorymanagerclient.Shared
{
    public static class ComponentHandlers
    {
        public static void HandleFilter(ChangeEventArgs args, out string filter)
        {
            if (args.Value is string value)
            {
                filter = value;
            }
            else
            {
                filter = string.Empty;
            }
        }

        public static void HandleClear(string _filter, out string filter)
        {
            if (string.IsNullOrWhiteSpace(_filter))
            {
                filter = string.Empty;
            }
            else
            {
                filter = string.Empty;
            }
        }

        public static void HandleRowFocus<T>(FluentDataGridRow<T> row = default!)
        {
            Debug.WriteLine($"[Custom comparer] Row focused: {row}");
        }

        public static string GetAttributeDisplayName(PropertyInfo property)
        {
            var atts = property.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.DisplayAttribute), true);
            if (atts.Length == 0) return default!;
            return ((DisplayAttribute)atts[0]).Name!;
        }

        public class StringLengthComparer : IComparer<string>
        {
            public static readonly StringLengthComparer Instance = new();

            public int Compare(string? x, string? y)
            {
                if (x is null)
                {
                    return y is null ? 0 : -1;
                }

                if (y is null)
                {
                    return 1;
                }

                return x.Length.CompareTo(y.Length);
            }
        }
    }
}
