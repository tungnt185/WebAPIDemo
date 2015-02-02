using Tungnt.NET.WP8._1Silverlight.Resources;

namespace Tungnt.NET.WP8._1Silverlight
{
    /// <summary>
    /// Provides access to string resources.
    /// </summary>
    public class LocalizedStrings
    {
        private static AppResources _localizedResources = new AppResources();

        public AppResources LocalizedResources { get { return _localizedResources; } }
    }
}