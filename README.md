# Dnn.StaticSiteHandler
⚡ Static Site ⚡ Handler 🤚 for DNN (Formerly DotNetNuke)

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