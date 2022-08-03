#define DotNetRuntimeExe  "windowsdesktop-runtime-6.0.7-win-x64.exe"
#define AppVersion "0.1"  
[Setup]
SignTool=MsSign $f
ArchitecturesAllowed=x64 
AppName=ImageLibrarian
AppVersion={#AppVersion}
DefaultDirName={commonpf64}\ImageLibrarian
DefaultGroupName=ImageLibrarian
LicenseFile="E:\Project Sync Folder\Projects\GitApps\ImageLibrarian\License.txt"
AppCopyright=Vijay Sridhara
AppPublisherURL=http://www.vijaysridhara.in
OutputDir=..\..\Project Output
CreateAppDir=yes
OutputBaseFilename=ImageLibrarian-Beta-0.1

[Types]
Name: "full"; Description: "Full installation"
[Files]
Source: "E:\Project Sync Folder\Projects\GitApps\ImageLibrarian\ImageLibrarian\bin\Release\net6.0-windows\ImageLibrarian.exe"; DestDir: "{app}"
Source: "E:\Project Sync Folder\Projects\GitApps\ImageLibrarian\ImageLibrarian\bin\Release\net6.0-windows\ImageLibrarian.dll"; DestDir: "{app}"
Source: "E:\Project Sync Folder\Projects\GitApps\ImageLibrarian\ImageLibrarian\bin\Release\net6.0-windows\ImageLibrarian.dll.config"; DestDir: "{app}"
Source: "E:\Project Sync Folder\Projects\GitApps\ImageLibrarian\ImageLibrarian\bin\Release\net6.0-windows\MetadataExtractor.dll"; DestDir: "{app}"
Source: "E:\Project Sync Folder\Projects\GitApps\ImageLibrarian\ImageLibrarian\bin\Release\net6.0-windows\XmpCore.dll"; DestDir: "{app}"
Source: "E:\Project Sync Folder\Projects\GitApps\ImageLibrarian\ImageLibrarian\bin\Release\net6.0-windows\System.Data.SQLite.dll"; DestDir: "{app}"
Source: "E:\Project Sync Folder\Projects\GitApps\ImageLibrarian\ImageLibrarian\bin\Release\net6.0-windows\ImageLibrarian.pdb"; DestDir: "{app}"
Source: "E:\Project Sync Folder\Projects\GitApps\ImageLibrarian\ImageLibrarian\bin\Release\net6.0-windows\runtimes\win-x64\native\*"; DestDir: "{app}\runtimes\win-x64\native" ; Flags: ignoreversion
Source: "E:\Project Sync Folder\Projects\GitApps\ImageLibrarian\ImageLibrarian\bin\Release\net6.0-windows\runtimes\win-x86\native\*"; DestDir: "{app}\runtimes\win-x86\native" ; Flags: ignoreversion
Source: "E:\Project Sync Folder\Projects\GitApps\ImageLibrarian\License.txt"; DestDir: "{app}"
Source: "E:\Project Sync Folder\Projects\GitApps\ImageLibrarian\ImageLibrarian\bin\Release\net6.0-windows\ImageLibrarian.deps.json"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\Project Sync Folder\Projects\GitApps\ImageLibrarian\ImageLibrarian\bin\Release\net6.0-windows\ImageLibrarian.runtimeconfig.json"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\Project Sync Folder\Projects\.NET\{#DotNetRuntimeExe}"; DestDir: {tmp}; Flags: deleteafterinstall; AfterInstall: InstallFramework;         
[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: checkedonce
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: checkedonce ; OnlyBelowVersion: 0,6.1

[Icons] 
Name: "{group}\ImageLibrarian"; Filename:"{app}\ImageLibrarian.exe"  
Name: "{group}\Uninstall"; Filename:"{app}\unins000.exe"  
    
[UninstallDelete]
Type: files; Name: "{app}\ImageLibrarian.runtimeconfig.json"
Type: files; Name: "{app}\ImageLibrarian.deps.json"
Type: files; Name: "{app}\runtimes\win-x64\*"
Type: files; Name: "{app}\runtimes\win-x86\*"
[Run]
Filename: "{app}\ImageLibrarian.exe"; WorkingDir: "{app}"; Flags: postinstall
[Code]
  procedure InstallFramework;
var
  ResultCode: Integer;
  Version: String;
  success:Boolean;
begin
  
  success:=RegQueryStringValue(HKEY_LOCAL_MACHINE, 'Software\dotnet\Setup\InstalledVersions\x64\sharedhost','Version',Version)   
  success:=success and (Version = '5.0.10')
  if not success then
      begin
        if not Exec(ExpandConstant('{tmp}\{#DotNetRuntimeExe}'), '/passive /norestart /showrmui /showfinalerror', '', SW_SHOW, ewWaitUntilTerminated, ResultCode) then
          begin
    { you can interact with the user that the installation failed }
          MsgBox('.NET installation failed with code: ' + IntToStr(ResultCode) + '.',
            mbError, MB_OK);
          end;
      end;
end;