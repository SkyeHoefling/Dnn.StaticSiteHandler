# Dnn.StaticSiteHandler
⚡ Static Site ⚡ Handler 🤚 for DNN (Formerly DotNetNuke)

# What is this for
The ⚡ Static Site ⚡ Handler 🤚 is a special type of DNN Extension that installs HTTP Handlers that can properly read secured DNN files from the DNN File Management and render them as basic HTML files. This is useful if you have custom intranet html websites you want to lock down with DNN Permissions. 

This module was built specifically to allow DocFX to be hosted inside of a DNN Site as intranet documentation for internal tools at [Redacted] ✔.

# Changes to DNN
This module makes minor changes to the DNN web.config and adds a new assembly to the directory. Below documents what changes are going to occur to your DNN site so you can make approprate decisions on installing this

* New assembly: Dnn.StaticSiteHandler
* Web.config changes - HTTP Handlers for Secured Files
  * HTML Files
  * JS Files
  * SVG Files
  * Font Files
  * CSS Files

# Create Module Installer

Open Command Prompt with msbuild.exe in the path
```
D:\> git clone https://github.com/ahoefling/Dnn.StaticSiteHandler.git
D:\> cd Dnn.StaticSiteHandler
D:\Dnn.StaticSiteHandler> msbuild Dnn.StaticSiteHandler.sln /p:Configuration=Release /p:Platform="Any CPU"
```

Once the build finishes you can create the module installer

```
D:\Dnn.StaticSiteHandler> msbuild src/Dnn.StaticSiteHandler/BuildScripts/ModulePackage.targets /t:PackageModule /p:Configuration=Release /p:Platform="Any CPU"
```

In the root directory the generated zip file will be in the following folder
```
D:\Dnn.StaticSiteHandler\Module_Installers>
```