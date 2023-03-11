using robotManager.Helpful;
using robotManager.Products;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.ComponentModel;
using System.IO;
using System.Drawing.Design;

[Serializable]
public class PluginSettings : Settings
{
    [Setting]
    [Category("Lists")]
    [DisplayName("Object List")]
    [Description("List of game objects.")]
    [Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
    public List<string> ObjectsList { get; set; }

    [Setting]
    [Category("Lists")]
    [DisplayName("NPC List")]
    [Description("List of NPC units.")]
    [Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
    public List<string> NPCList { get; set; }

    [Setting]
    [Category("Lists")]
    [DisplayName("Rare Spawn List")]
    [Description("List of Rare Spawn units.")]
    [Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
    public List<string> RareSpawnList { get; set; }

    [Setting]
    [Category("Lists")]
    [DisplayName("Friends List")]
    [Description("List of Bot-friendly units.")]
    [Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
    public List<string> FriendsList { get; set; }

    [Setting]
    [Category("Lists")]
    [DisplayName("Path")]
    [Description("Store Path.")]
    [Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
    public List<Vector3> Path { get; set; }

    [Setting]
    [DefaultValue(true)]
    [Category("Options")]
    [DisplayName("OLD Draw Object Lines")]
    [Description("Will draw lines to nearby found objects/players on screen. [Default=True]")]
    public bool DrawObjectLines { get; set; }

    [Setting]
    [DefaultValue(true)]
    [Category("Options")]
    [DisplayName("OLD Draw Text")]
    [Description("Will draw the text of the Objects/ NPCs names as well as enemy level and class on screen. [Default=True]")]
    public bool DrawObjectNames { get; set; }

    [Setting]
    [DefaultValue(true)]
    [Category("Options")]
    [DisplayName("OLD Hide Radar In Combat")]
    [Description("Will stop drawing radar elements to the screen if you are in combat. [Default=True]")]
    public bool HideRadarInCombat { get; set; }

    [Setting]
    [DefaultValue(true)]
    [Category("Options")]
    [DisplayName("OLD Play Sound File")]
    [Description("Will play the \"alert.wav\" file inside Plugins folder when a rare spawn is located. [Default=True]")]
    public bool PlaySound { get; set; }

    [Setting]
    [DefaultValue(true)]
    [Category("Options")]
    [DisplayName("OLD Show Enemy Players")]
    [Description("Will show enemy players. (Disabled for public) [Default=False]")]
    public bool ShowEnemyPlayers { get; set; }

    [Setting]
    [DefaultValue(true)]
    [Category("Options")]
    [DisplayName("Hide Radar in Combat")]
    [Description("Hide Radar in Combat")]
    public bool HideInCombat { get; set; }

    [Setting]
    [DefaultValue(true)]
    [Category("Options")]
    [DisplayName("Enable Radar")]
    [Description("Enable Radar")]
    public bool EnableRadar { get; set; }

    [Setting]
    [DefaultValue(true)]
    [Category("Players")]
    [DisplayName("Draw Player UI")]
    [Description("Draw Player UI")]
    public bool PlayerDrawUI { get; set; }

    [Setting]
    [DefaultValue(true)]
    [Category("Players")]
    [DisplayName("Play Player Sound")]
    [Description("Play Player Sound")]
    public bool PlayerSound { get; set; }

    [Setting]
    [DefaultValue(true)]
    [Category("Players")]
    [DisplayName("Draw Player Corpses")]
    [Description("Draw flightlines to player corpses when out of combat")]
    public bool PlayerCorpses { get; set; }

    [Setting]
    [DefaultValue(true)]
    [Category("NPCs")]
    [DisplayName("Draw NPC UI")]
    [Description("Draw NPC UI")]
    public bool NPCsDrawUI { get; set; }

    [Setting]
    [DefaultValue(true)]
    [Category("NPCs")]
    [DisplayName("Play NPC Sound")]
    [Description("Play NPC Sound")]
    public bool NPCsSound { get; set; }

    [Setting]
    [DefaultValue(true)]
    [Category("Objects")]
    [DisplayName("Draw Object UI")]
    [Description("Draw Object UI")]
    public bool ObjectsDrawUI { get; set; }

    [Setting]
    [DefaultValue(true)]
    [Category("Objects")]
    [DisplayName("Play Object Sound")]
    [Description("Play Object Sound")]
    public bool ObjectsSound { get; set; }

    [Setting]
    [DefaultValue(true)]
    [Category("PvP")]
    [DisplayName("Draw PvP UI")]
    [Description("Draw PvP UI")]
    public bool PvPDrawUI { get; set; }

    [Setting]
    [DefaultValue(true)]
    [Category("PvP")]
    [DisplayName("Play PvP Sound")]
    [Description("Play PvP Sound")]
    public bool PvPSound { get; set; }

    [Setting]
    [DefaultValue(true)]
    [Category("Map")]
    [DisplayName("Display Me")]
    [Description("Display Me")]
    public bool Map3DMe { get; set; }
    [Setting]
    [DefaultValue(true)]
    [Category("Map")]
    [DisplayName("Display Target")]
    [Description("Display Target")]
    public bool Map3DTarget { get; set; }
    [Setting]
    [DefaultValue(true)]
    [Category("Map")]
    [DisplayName("Display Target Line")]
    [Description("Display line to Target")]
    public bool Map3DTargetLine { get; set; }
    [Setting]
    [DefaultValue(true)]
    [Category("Map")]
    [DisplayName("Display Path")]
    [Description("Display Path")]
    public bool Map3DPath { get; set; }
    [Setting]
    [DefaultValue(true)]
    [Category("Map")]
    [DisplayName("Display NPCs")]
    [Description("Display NPCs")]
    public bool Map3DNPCs { get; set; }
    [Setting]
    [DefaultValue(true)]
    [Category("Map")]
    [DisplayName("Display Players")]
    [Description("Display Players")]
    public bool Map3DPlayers { get; set; }
    [Setting]
    [DefaultValue(true)]
    [Category("Map")]
    [DisplayName("Display Objects")]
    [Description("Display Objects")]
    public bool Map3DObjects { get; set; }


    public PluginSettings()
    {
        ObjectsList = new List<string>();
        NPCList = new List<string>();
        RareSpawnList = new List<string>();
        FriendsList = new List<string>();

        Path = new List<Vector3>();

        this.DrawObjectLines = true;
        this.DrawObjectNames = true;
        this.HideRadarInCombat = true;
        this.PlaySound = true;
        this.ShowEnemyPlayers = true;

        this.EnableRadar = true;
        this.HideInCombat = true;
        this.PlayerDrawUI = true;
        this.PlayerSound = true;
        this.PlayerCorpses = true;
        this.NPCsDrawUI = true;
        this.NPCsSound = true;
        this.ObjectsDrawUI = true;
        this.ObjectsSound = true;
        this.PvPDrawUI = true;
        this.PvPSound = true;

        this.Map3DMe = true;
        this.Map3DTarget = true;
        this.Map3DTargetLine = true;
        this.Map3DPath = true;
        this.Map3DNPCs = true;
        this.Map3DPlayers = true;
        this.Map3DObjects = true;

        //this.ConfigWinForm(new Point(600, 650), "Radar" + Translate.Get(" - Settings"), false);
        ConfigWinForm(new System.Drawing.Point(800, 600));
    }

    public static PluginSettings CurrentSetting { get; set; }

    public bool Save()
    {
        try
        {
            return Save(AdviserFilePathAndName("CustomPlugin-PathEditor", ObjectManager.Me.Name + "." + Usefuls.RealmName));
        }
        catch (Exception e)
        {
            Logging.WriteError("CustomPlugin-PathEditor > Save(): " + (object)e, true);
            return false;
        }
    }

    public static bool Load()
    {
        try
        {
            if (File.Exists(AdviserFilePathAndName("CustomPlugin-PathEditor", ObjectManager.Me.Name + "." + Usefuls.RealmName)))
            {
                CurrentSetting =
                    Load<PluginSettings>(AdviserFilePathAndName("CustomPlugin-PathEditor", ObjectManager.Me.Name + "." + Usefuls.RealmName));
                return true;
            }
            CurrentSetting = new PluginSettings();
        }
        catch (Exception e)
        {
            Logging.Write("CustomPlugin-PathEditor > Load(): " + e);
        }
        return false;
    }
}