# Android Emulator Troubleshooting Script for Bit RPG

Write-Host "=== Android Emulator Diagnostic Tool ===" -ForegroundColor Cyan
Write-Host ""

# Check if Android SDK is installed
Write-Host "1. Checking Android SDK..." -ForegroundColor Yellow
$androidHome = $env:ANDROID_HOME
if (-not $androidHome) {
    $androidHome = $env:ANDROID_SDK_ROOT
}

if ($androidHome) {
    Write-Host "   ? Android SDK found at: $androidHome" -ForegroundColor Green
} else {
    Write-Host "   ? Android SDK not found!" -ForegroundColor Red
    Write-Host "   Install Android SDK through Visual Studio Installer:" -ForegroundColor Yellow
    Write-Host "   Tools ? Get Tools and Features ? Individual Components ? Android SDK" -ForegroundColor Yellow
    exit 1
}

# Check emulator installation
Write-Host ""
Write-Host "2. Checking Android Emulator..." -ForegroundColor Yellow
$emulatorPath = Join-Path $androidHome "emulator\emulator.exe"
if (Test-Path $emulatorPath) {
    Write-Host "   ? Emulator found" -ForegroundColor Green
} else {
    Write-Host "   ? Emulator not found!" -ForegroundColor Red
    Write-Host "   Install through Android SDK Manager in Visual Studio" -ForegroundColor Yellow
}

# List available AVDs
Write-Host ""
Write-Host "3. Available Android Virtual Devices (AVDs)..." -ForegroundColor Yellow
$avdManagerPath = Join-Path $androidHome "cmdline-tools\latest\bin\avdmanager.bat"
if (Test-Path $avdManagerPath) {
    & $avdManagerPath list avd
} else {
    Write-Host "   ? AVD Manager not found" -ForegroundColor Red
    Write-Host "   Using alternative method..." -ForegroundColor Yellow
    & $emulatorPath -list-avds
}

# Check if emulator is running
Write-Host ""
Write-Host "4. Checking running emulators..." -ForegroundColor Yellow
$adbPath = Join-Path $androidHome "platform-tools\adb.exe"
if (Test-Path $adbPath) {
    $devices = & $adbPath devices
    Write-Host $devices
    
    if ($devices -match "emulator-") {
        Write-Host "   ? Emulator is running" -ForegroundColor Green
    } else {
        Write-Host "   ? No running emulator detected" -ForegroundColor Yellow
    }
} else {
    Write-Host "   ? ADB not found!" -ForegroundColor Red
}

Write-Host ""
Write-Host "=== Recommended Actions ===" -ForegroundColor Cyan

Write-Host ""
Write-Host "Option A - Create/Start an Emulator:" -ForegroundColor Green
Write-Host "  1. In Visual Studio: Tools ? Android ? Android Device Manager" -ForegroundColor White
Write-Host "  2. Click 'New Device'" -ForegroundColor White
Write-Host "  3. Use these settings:" -ForegroundColor White
Write-Host "     - Base Device: Pixel 5" -ForegroundColor Gray
Write-Host "     - OS: Android 11.0 or higher (API 30+)" -ForegroundColor Gray
Write-Host "     - Memory: 2048 MB minimum" -ForegroundColor Gray
Write-Host "  4. Click 'Create' and wait for it to start" -ForegroundColor White

Write-Host ""
Write-Host "Option B - Use Physical Device (RECOMMENDED):" -ForegroundColor Green
Write-Host "  1. Enable Developer Mode on your phone" -ForegroundColor White
Write-Host "  2. Enable USB Debugging" -ForegroundColor White
Write-Host "  3. Connect via USB" -ForegroundColor White
Write-Host "  4. Select your device in Visual Studio toolbar" -ForegroundColor White

Write-Host ""
Write-Host "Option C - Quick Emulator Start:" -ForegroundColor Green
Write-Host "  Run this command to start the first available AVD:" -ForegroundColor White
Write-Host "  $emulatorPath -avd `$(& $emulatorPath -list-avds | Select-Object -First 1) &" -ForegroundColor Gray

Write-Host ""
Write-Host "=== Performance Tips ===" -ForegroundColor Cyan
Write-Host "• Enable Intel HAXM or AMD-V/Hyper-V for faster emulation" -ForegroundColor White
Write-Host "• Allocate at least 2GB RAM to the emulator" -ForegroundColor White
Write-Host "• Close other programs to free up resources" -ForegroundColor White
Write-Host "• Use x86_64 architecture for better performance" -ForegroundColor White

Write-Host ""
Write-Host "=== Common Issues ===" -ForegroundColor Cyan
Write-Host "Issue: 'Waiting for emulator to be ready...'" -ForegroundColor Yellow
Write-Host "Fix: Start emulator manually first, wait for full boot" -ForegroundColor White
Write-Host ""
Write-Host "Issue: 'Emulator is too slow'" -ForegroundColor Yellow
Write-Host "Fix: Enable hardware acceleration (HAXM/Hyper-V)" -ForegroundColor White
Write-Host ""
Write-Host "Issue: 'Build canceled'" -ForegroundColor Yellow
Write-Host "Fix: Increase deployment timeout in Visual Studio:" -ForegroundColor White
Write-Host "     Tools ? Options ? Xamarin ? Android Settings ? Deployment Timeout" -ForegroundColor Gray

Write-Host ""
