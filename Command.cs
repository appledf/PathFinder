using robotManager.Helpful;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wManager.Wow.Helpers;


public class Command
{
    #region Properties
    public bool DisplayMiniMap { get; set; }
    public bool DrawObjectLines { get; set; }
    public bool DrawObjectNames { get; set; }
    public bool HideRadarInCombat { get; set; }
    public bool PlaySound { get; set; }
    public bool ShowEnemyPlayers { get; set; }
    public bool EnableRadar { get; set; }
    public bool HideInCombat { get; set; }
    public bool PlayerDrawUI { get; set; }
    public bool PlayerSound { get; set; }
    public bool PlayerCorpses { get; set; }
    public bool NPCsDrawUI { get; set; }
    public bool NPCsSound { get; set; }
    public bool ObjectsDrawUI { get; set; }
    public bool ObjectsSound { get; set; }
    public bool PvPDrawUI { get; set; }
    public bool PvPSound { get; set; }
    public bool Map3DMe { get; set; }
    public bool Map3DTarget { get; set; }
    public bool Map3DTargetLine { get; set; }
    public bool Map3DPath { get; set; }
    public bool Map3DNPCs { get; set; }
    public bool Map3DPlayers { get; set; }
    public bool Map3DObjects { get; set; }
    #endregion Properties

    #region Lua
    public bool GetLuaBool(string LuaVar)
    {
        string s = "return " + LuaVar + ";";
        return Lua.LuaDoString<bool>(s);
    }
    public int GetLuaInt(string LuaVar)
    {
        string s = "return " + LuaVar + ";";
        return Lua.LuaDoString<int>(s);
    }
    public string GetLuaString(string LuaVar)
    {
        string s = "return " + LuaVar + ";";
        return Lua.LuaDoString<string>(s);
    }
    public void SetLuaBool(string LuaVar, bool BoolVar)
    {
        string s = "";
        if (BoolVar)
        {
            s = LuaVar + " = true;";
        }
        else
        {
            s = LuaVar + " = false;";
        }
        Lua.LuaDoString(s);
    }
    public void SetLuaInt(string LuaVar, int IntVar)
    {
        string s = LuaVar + " = " + IntVar;
        Lua.LuaDoString(s);
    }
    #endregion Lua

    #region Methods
    public void SyncFcom()
    {
        //Methods.LuaPrint("SyncFcom executing..");
        string trigger = Lua.LuaDoString<string>("return petrigger()");
        //Logging.Write("trigger command:" + trigger);
        if (CheckCommand(trigger,"pe_add"))
        {
            //add node from endpoint
            //Methods.LuaPrint("pe_add invoked");
            Methods.CMD_Add();
        }
        if (CheckCommand(trigger, "pe_del"))
        {
            //delete closest node
            //Methods.LuaPrint("pe_del invoked");
            Methods.CMD_Delete();
        }
        if (CheckCommand(trigger, "pe_new"))
        {
            //initialize new path
            //Methods.LuaPrint("pe_new invoked");
            Methods.CMD_New();
        }
        if (CheckCommand(trigger, "pe_insert"))
        {
            //insert node betwen closest two adjoined nodes
            //Methods.LuaPrint("pe_insert invoked");
            string str1 = GetCommandArg(trigger);
            int index = -1;
            if (int.TryParse(str1,out index)) 
            {
                index = int.Parse(str1);
            }
            Methods.CMD_Insert(index, true);
        }
        if (CheckCommand(trigger, "pe_secondary"))
        {
            //insert node betwen closest two adjoined nodes
            //Methods.LuaPrint("pe_insert invoked");
            string str1 = GetCommandArg(trigger);
            int index = -1;
            if (int.TryParse(str1, out index))
            {
                index = int.Parse(str1);
            }
            Methods.CMD_Insert(index);
        }
        if (CheckCommand(trigger, "pe_reposition"))
        {
            //move closest node to your position
            //Methods.LuaPrint("pe_reposition invoked");
            Methods.CMD_Reposition();
        }
        if (CheckCommand(trigger, "pe_minimap"))
        {
            //move closest node to your position
            //Methods.LuaPrint("pe_reposition invoked");
            this.DisplayMiniMap = !(this.DisplayMiniMap);
            Methods.CMD_Minimap();
        }
        if (CheckCommand(trigger, "pe_showindex"))
        {
            //initialize new path
            //Methods.LuaPrint("pe_new invoked");
            Methods.CMD_ShowIndex();
        }
        if (CheckCommand(trigger, "pe_mark"))
        {
            //initialize new path
            //Methods.LuaPrint("pe_new invoked");
            Methods.CMD_Mark();
        }
        if (CheckCommand(trigger, "pe_save"))
        {
            //initialize new path
            //Methods.LuaPrint("pe_new invoked");
            Methods.CMD_Save();
        }
        if (CheckCommand(trigger, "pe_reload"))
        {
            //initialize new path
            //Methods.LuaPrint("pe_new invoked");
            string name = GetCommandArg(trigger);
            Methods.CMD_Reload(name);
        }
    }
    private bool CheckCommand(string value,string cmd)
    {
        if (value.StartsWith(cmd))
        {
            return true;
        }
        return false;
    }
    private string GetCommandArg(string cmd)
    {
        string re = "";
        try
        {
            string[] arr = cmd.Replace(")", "").Split('(');
            re = arr[1];
        }
        catch (Exception ex) { }
        return re;
    }
    #endregion Methods
}
