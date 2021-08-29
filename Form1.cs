using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using IniParser;
using IniParser.Model;

namespace UnrealQT
{


  public partial class Form1 : Form
  {
    public IniData data;
    public FileIniDataParser parser = new FileIniDataParser();

    public string projectName;
    public string projectIncludesName;

    public Form1()
    {
      InitializeComponent();
      
      // Load user config
      if (File.Exists("config.ini"))
      {
        var parser = new FileIniDataParser();
        data = parser.ReadFile("config.ini");

        TXT_UE_Engine_Path.Text = data["PATHS"]["EnginePath"];
        TXT_VS_Path.Text = data["PATHS"]["VSPath"];
      } else
      {
        string[] configBoilerplate =
        {
          "[PATHS]", "EnginePath=", "VSPath="
        };

        File.WriteAllLines("config.ini", configBoilerplate);
        data = parser.ReadFile("config.ini");
      }
    }

    private void BTN_Quit_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void BTN_Engine_Path_Click(object sender, EventArgs e)
    {
      FolderBrowserDialog diag = new FolderBrowserDialog();
      diag.ShowDialog();

      if (diag.SelectedPath != String.Empty)
      {
        TXT_UE_Engine_Path.Text = diag.SelectedPath;
        data["PATHS"]["EnginePath"] = diag.SelectedPath;
        parser.WriteFile("config.ini", data);
      }
    }

    private void BTN_Save_Configuration_Click(object sender, EventArgs e)
    {
      data["PATHS"]["EnginePath"] = TXT_UE_Engine_Path.Text;
      data["PATHS"]["VSPath"] = TXT_VS_Path.Text;
      parser.WriteFile("config.ini", data);
    }

    private void BTN_VS_Path_Click(object sender, EventArgs e)
    {
      FolderBrowserDialog diag = new FolderBrowserDialog();
      diag.ShowDialog();

      if (diag.SelectedPath != String.Empty)
      {
        TXT_VS_Path.Text = diag.SelectedPath;
        data["PATHS"]["VSPath"] = diag.SelectedPath;
        parser.WriteFile("config.ini", data);
      }
    }

    private void BTN_Project_Path_Click(object sender, EventArgs e)
    {
      FolderBrowserDialog diag = new FolderBrowserDialog();
      diag.ShowDialog();

      if (diag.SelectedPath != String.Empty)
      {
        TXT_Project_Path.Text = diag.SelectedPath;

        string[] files = Directory.GetFiles(diag.SelectedPath, "*.uproject");
        if (files.Length == 1)
        {
          LBL_Project_Name.Text = Path.GetFileNameWithoutExtension(files[0]);
          projectName = Path.GetFileNameWithoutExtension(files[0]);

          LBL_Project_Includes_Name.Text = Path.GetFileNameWithoutExtension(files[0]) + "Editor";
          projectIncludesName = Path.GetFileNameWithoutExtension(files[0]) + "Editor";
        }
      }
    }

    private void BTN_Generate_Click(object sender, EventArgs e)
    {
      string[] defines =
      {
        "DEFINES += \"$(NMakePreprocessorDefinitions)\"",
        "DEFINES += \"UE_GAME=1\"",
        "DEFINES += \"IS_PROGRAM=0\"",
        "DEFINES += \"UE_ROCKET=1\"",
        "DEFINES += \"UNICODE\"",
        "DEFINES += \"_UNICODE\"",
        "DEFINES += \"__UNREAL__\"",
        "DEFINES += \"IS_MONOLITHIC=1\"",
        "DEFINES += \"WITH_ENGINE=1\"",
        "DEFINES += \"WITH_UNREAL_DEVELOPER_TOOLS=1\"",
        "DEFINES += \"WITH_COREUOBJECT=1\"",
        "DEFINES += \"USE_STATS_WITHOUT_ENGINE=0\"",
        "DEFINES += \"WITH_PLUGIN_SUPPORT=0\"",
        "DEFINES += \"USE_LOGGING_IN_SHIPPING=0\"",
        "DEFINES += \"UE_BUILD_MINIMAL=1\"",
        "DEFINES += \"WITH_EDITOR=1\"",
        "DEFINES += \"WITH_EDITORONLY_DATA=0\"",
        "DEFINES += \"WITH_SERVER_CODE=1\"",
        "DEFINES += \"UBT_COMPILED_PLATFORM=Win64\"",
        "DEFINES += \"WIN32=1\"",
        "DEFINES += \"_WIN32_WINNT=0x0600\"",
        "DEFINES += \"WINVER=0x0600\"",
        "DEFINES += \"PLATFORM_WINDOWS=1\"",
        "DEFINES += \"NDEBUG=1\"",
        "DEFINES += \"UE_BUILD_DEVELOPMENT=1\"",
        "DEFINES += \"UE_ENGINE_DIRECTORY=$$UNREAL_PATH/Engine/\"",
        "DEFINES += \"ORIGINAL_FILE_NAME=\"" + projectName + ".exe\"\"",
        "DEFINES += \"YourProject_API=\"",
        "DEFINES += \"UE_ENABLE_ICU=1\"",
        "DEFINES += \"WITH_STEAMWORKS=0\"",
        "DEFINES += \"WITH_DIRECTXMATH=0\"",
        "DEFINES += \"CORE_API=\"",
        "DEFINES += \"COREUOBJECT_API=\"",
        "DEFINES += \"WITH_PHYSX=1\"",
        "DEFINES += \"WITH_APEX=1\"",
        "DEFINES += \"WITH_RECAST=1\"",
        "DEFINES += \"WITH_SPEEDTREE=0\"",
        "DEFINES += \"ENGINE_API=\"",
        "DEFINES += \"SLATE_API=\"",
        "DEFINES += \"INPUTCORE_API=\"",
        "DEFINES += \"SLATECORE_API=\"",
        "DEFINES += \"MESSAGING_API=\"",
        "DEFINES += \"RENDERCORE_API=\"",
        "DEFINES += \"RHI_API=\"",
        "DEFINES += \"SHADERCORE_API=\"",
        "DEFINES += \"ASSETREGISTRY_API=\"",
        "DEFINES += \"ENGINEMESSAGES_API=\"",
        "DEFINES += \"ENGINESETTINGS_API=\"",
        "DEFINES += \"SYNTHBENCHMARK_API=\"",
        "DEFINES += \"RENDERER_API=\"",
        "DEFINES += \"UE_EDITOR=1\"",
        "DEFINES += \"GITSOURCECONTROL_API=\"",
        "DEFINES += \"EDITORSTYLE_API=\"",
        "DEFINES += \"SOURCECONTROL_API=\"",
        "DEFINES += \"USE_NETWORK_PROFILER=1\"",
        "DEFINES += \"WITH_SIMPLYGON=0\"",
        "DEFINES += \"UNREALED_API=\"",
        "DEFINES += \"BSPMODE_API=\"",
        "DEFINES += \"DOCUMENTATION_API=\"",
        "DEFINES += \"PROJECTS_API=\"",
        "DEFINES += \"SANDBOXFILE_API=\"",
        "DEFINES += \"UNREALEDMESSAGES_API=\"",
        "DEFINES += \"BLUEPRINTGRAPH_API=\"",
        "DEFINES += \"XAUDIO2_API=\"",
        "DEFINES += \"USERFEEDBACK_API=\"",
        "DEFINES += \"COLLECTIONMANAGER_API=\""
      };

      string[] includes =
      {
        "# Engine include path",
        "INCLUDEPATH += \"$(NMakeIncludeSearchPath)\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Core\\Public\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Core\\Public\\Internationalization\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Core\\Public\\Async\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Core\\Public\\Concurrency\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Core\\Public\\Containers\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Core\\Public\\Delegates\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Core\\Public\\GenericPlatform\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Core\\Public\\HAL\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Core\\Public\\Math\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Core\\Public\\Misc\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Core\\Public\\Modules\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Core\\Public\\Modules\\Boilerplate\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Core\\Public\\ProfilingDebugging\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Core\\Public\\Serialization\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Core\\Public\\Serialization\\Json\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Core\\Public\\Stats\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Core\\Public\\Templates\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Core\\Public\\UObject\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Core\\Public\\Windows\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\CoreUObject\\Classes\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Intermediate\\Build\\Win64\\Inc\\CoreUObject\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\CoreUObject\\Public\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\CoreUObject\\Public\\Blueprint\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\CoreUObject\\Public\\Misc\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\CoreUObject\\Public\\Serialization\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\CoreUObject\\Public\\Templates\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\CoreUObject\\Public\\UObject\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Engine\\Classes\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Intermediate\\Build\\Win64\\Inc\\Engine\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Engine\\Public\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Engine\\Public\\AI\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Engine\\Public\\Landscape\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Engine\\Public\\Net\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Engine\\Public\\Slate\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Engine\\Public\\Tests\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Intermediate\\Build\\Win64\\Inc\\Slate\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Slate\\Public\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Slate\\Public\\Framework\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Slate\\Public\\Widgets\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Slate\\Public\\Framework\\Application\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Slate\\Public\\Framework\\Commands\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Slate\\Public\\Framework\\Docking\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Slate\\Public\\Framework\\Layout\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Slate\\Public\\Framework\\MultiBox\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Slate\\Public\\Framework\\Notifications\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Slate\\Public\\Framework\\Styling\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Slate\\Public\\Framework\\Text\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Slate\\Public\\Framework\\Views\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Slate\\Public\\Widgets\\Colors\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Slate\\Public\\Widgets\\Docking\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Slate\\Public\\Widgets\\Images\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Slate\\Public\\Widgets\\Input\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Slate\\Public\\Widgets\\Layout\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Slate\\Public\\Widgets\\Navigation\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Slate\\Public\\Widgets\\Notifications\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Slate\\Public\\Widgets\\Testing\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Slate\\Public\\Widgets\\Text\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Slate\\Public\\Widgets\\Tutorials\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Slate\\Public\\Widgets\\Views\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\InputCore\\Classes\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Intermediate\\Build\\Win64\\Inc\\InputCore\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\InputCore\\Public\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Intermediate\\Build\\Win64\\Inc\\SlateCore\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\SlateCore\\Public\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\SlateCore\\Public\\Animation\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\SlateCore\\Public\\Application\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\SlateCore\\Public\\Brushes\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\SlateCore\\Public\\Fonts\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\SlateCore\\Public\\Input\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\SlateCore\\Public\\Layout\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\SlateCore\\Public\\Logging\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\SlateCore\\Public\\Rendering\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\SlateCore\\Public\\Sound\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\SlateCore\\Public\\Styling\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\SlateCore\\Public\\Textures\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\SlateCore\\Public\\Types\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\SlateCore\\Public\\Widgets\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Intermediate\\Build\\Win64\\Inc\\Messaging\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Messaging\\Public\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Messaging\\Public\\Common\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Messaging\\Public\\Interfaces\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Intermediate\\Build\\Win64\\Inc\\RenderCore\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\RenderCore\\Public\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Intermediate\\Build\\Win64\\Inc\\RHI\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\RHI\\Public\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Intermediate\\Build\\Win64\\Inc\\ShaderCore\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\ShaderCore\\Public\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Intermediate\\Build\\Win64\\Inc\\AssetRegistry\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\AssetRegistry\\Public\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\EngineMessages\\Classes\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Intermediate\\Build\\Win64\\Inc\\EngineMessages\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\EngineMessages\\Public\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\EngineSettings\\Classes\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Intermediate\\Build\\Win64\\Inc\\EngineSettings\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\EngineSettings\\Public\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Intermediate\\Build\\Win64\\Inc\\SynthBenchmark\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Developer\\SynthBenchmark\\Public\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Intermediate\\Build\\Win64\\Inc\\Renderer\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Renderer\\Public\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Intermediate\\Build\\Win64\\Inc\\EditorStyle\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Editor\\EditorStyle\\Public\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Editor\\EditorStyle\\Public\\Classes\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Editor\\EditorStyle\\Public\\Interfaces\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Intermediate\\Build\\Win64\\Inc\\SourceControl\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Developer\\SourceControl\\Public\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Programs\\UnrealLightmass\\Public\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Editor\\UnrealEd\\Classes\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Intermediate\\Build\\Win64\\Inc\\UnrealEd\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Editor\\UnrealEd\\Public\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Editor\\UnrealEd\\Public\\Commandlets\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Editor\\UnrealEd\\Public\\Dialogs\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Editor\\UnrealEd\\Public\\DragAndDrop\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Editor\\UnrealEd\\Public\\Features\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Editor\\UnrealEd\\Public\\Kismet2\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Editor\\UnrealEd\\Public\\Layers\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Editor\\UnrealEd\\Public\\Toolkits\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Intermediate\\Build\\Win64\\Inc\\BspMode\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Editor\\BspMode\\Public\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Intermediate\\Build\\Win64\\Inc\\Documentation\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Editor\\Documentation\\Public\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Intermediate\\Build\\Win64\\Inc\\Projects\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Projects\\Public\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Projects\\Public\\Interfaces\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Intermediate\\Build\\Win64\\Inc\\SandboxFile\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\SandboxFile\\Public\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Editor\\UnrealEdMessages\\Classes\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Intermediate\\Build\\Win64\\Inc\\UnrealEdMessages\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Editor\\UnrealEdMessages\\Public\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Editor\\BlueprintGraph\\Classes\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Intermediate\\Build\\Win64\\Inc\\BlueprintGraph\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Editor\\BlueprintGraph\\Public\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Intermediate\\Build\\Win64\\Inc\\XAudio2\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Runtime\\Windows\\XAudio2\\Public\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Intermediate\\Build\\Win64\\Inc\\UserFeedback\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Editor\\UserFeedback\\Public\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Intermediate\\Build\\Win64\\Inc\\CollectionManager\"",
        "INCLUDEPATH += \"$$UNREAL_PATH\\Engine\\Source\\Developer\\CollectionManager\\Public\"",
        "INCLUDEPATH += \"$$VISUAL_PATH\\VC\\INCLUDE\"",
        "INCLUDEPATH += \"C:\\Program Files (x86)\\Windows Kits\\8.1\\include\\shared\"",
        "INCLUDEPATH += \"C:\\Program Files (x86)\\Windows Kits\\8.1\\include\\um\"",
        "INCLUDEPATH += \"C:\\Program Files (x86)\\Windows Kits\\8.1\\include\\winrt\""
      };

      string[] proFile =
      {
        "TEMPLATE = app",
        "CONFIG += console",
        "CONFIG -= app_bundle",
        "CONFIG -= qt",
        "# Declare and assign specific variable, you may change this path to work (do not add \\ at the end of path !)",
        "UNREAL_PATH = " + TXT_UE_Engine_Path.Text,
        "VISUAL_PATH = " + TXT_VS_Path.Text,
        "# Will define all unreal defines",
        "include(defines.pri)",
        "# Project source path (you may complete this)",
        "HEADERS += Source\\" + projectName + "\\*.h",
        "SOURCES += Source\\" + projectName + "\\*.cpp",
        "# Project include path (you also may complete this)",
        "INCLUDEPATH += Source\\" + projectName,
        "# include path for generated files",
        "INCLUDEPATH += Intermediate\\Build\\Win64\\Inc\\" + projectIncludesName + "\\Development",
        "# Will add all unreal include path",
        "include(includes.pri)"
      };

      try
      {
        File.WriteAllLines(TXT_Project_Path.Text + "\\defines.pri", defines);
        File.WriteAllLines(TXT_Project_Path.Text + "\\includes.pri", includes);
        File.WriteAllLines(TXT_Project_Path.Text + "\\" + projectName + ".pro", proFile);

        MessageBox.Show("Done! Your project file can be found at '" + TXT_Project_Path.Text + "\\" + projectName + ".pro'", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
      } catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "There was an error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void TXT_Project_Path_TextChanged(object sender, EventArgs e)
    {

    }
  }
}
