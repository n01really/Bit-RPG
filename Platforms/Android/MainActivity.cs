using Android.App;
using Android.Content.PM;
using Android.OS;

namespace Bit_RPG
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("[MainActivity] OnCreate called");
                base.OnCreate(savedInstanceState);
                System.Diagnostics.Debug.WriteLine("[MainActivity] OnCreate completed successfully");
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[MainActivity] FATAL ERROR in OnCreate: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"[MainActivity] Stack trace: {ex.StackTrace}");
                if (ex.InnerException != null)
                {
                    System.Diagnostics.Debug.WriteLine($"[MainActivity] Inner exception: {ex.InnerException.Message}");
                    System.Diagnostics.Debug.WriteLine($"[MainActivity] Inner stack trace: {ex.InnerException.StackTrace}");
                }
                throw;
            }
        }
    }
}
