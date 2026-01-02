using Android.App;
using Android.Runtime;
using Microsoft.Maui;

namespace Bit_RPG
{
    [Application]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }

        protected override MauiApp CreateMauiApp()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("[Android] Creating MauiApp...");
                var app = MauiProgram.CreateMauiApp();
                System.Diagnostics.Debug.WriteLine("[Android] MauiApp created successfully");
                return app;
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[Android] FATAL ERROR creating MauiApp: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"[Android] Stack trace: {ex.StackTrace}");
                throw;
            }
        }
    }
}
