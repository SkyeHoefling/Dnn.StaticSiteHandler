# Dnn.StaticSiteHandler
⚡ Static Site ⚡ Handler 🤚 for DNN (Formerly DotNetNuke)

# What is this for
The ⚡ Static Site ⚡ Handler 🤚 is a special type of DNN Extension that installs HTTP Handlers that can properly read secured DNN files from the DNN File Management and render them as basic HTML files. This is useful if you have custom intranet html websites you want to lock down with DNN Permissions. 

This module was built specifically to allow DocFX to be hosted inside of a DNN Site as intranet documentation for internal tools at [Redacted] ✔.

# Getting Started
Before you can begin you need to update all of your routes in your static website to have the extension `.axd`, this is **VERY** important or nothing will work. Only update the references in your files, not the actual file extensions themselves.

Example of index.html
```
<a href="/second-page.html.axd">Second Page</a>
```
In this example the actual page is still `index.html`, once DNN secures the file it will be `index.html.resources`

## Upload Files to DNN
Once you have all of the routes configured, you will need to upload your static site to DNN. For this to work correctly you will need to create a secured folder in DNN. The secured folder and files in DNN locks all the files down so IIS will not serve the content. This will require all content to be routed through the ⚡🤚, which will handle permissions for you.

After securing your files just set the top level folder permission and you will be good to go!


# Supports DNN (Formerly DotNetNuke)
⚡🤚 was originally built for DNN 9.4 but does not leverage any new 9.x or 9.4.x features. The extension should work on any version of DNN that support HTTP Handlers. Below is a table of versions of DNN that it has been tested on and confirmed working

| ⚡ Static Site ⚡ Handler 🤚 | DNN (DotNetNuke) | Supported |
|-------------------------------|------------------|-----------|
| 1.0.0                         | 9.4.1            | Yes       |

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
