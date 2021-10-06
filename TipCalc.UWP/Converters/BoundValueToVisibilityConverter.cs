using MvvmCross.Platforms.Uap.Converters;
using MvvmCross.Plugin.Visibility;

namespace TipCalc.UWP.Converters
{
    /// <summary>
    /// Converter for any databound value to Visibility using the built in plugin for MvX 
    /// <para>A non-null, non-empty string returns visible</para>
    /// <para>An int or double value >0 returns visible</para>
    /// <para>A true boolean returns visible</para>
    /// <para>Any other type with a non-null value returns visible</para>
    /// </summary>
    public class BoundValueToVisibilityConverter : MvxNativeValueConverter<MvxVisibilityValueConverter> { }
}
