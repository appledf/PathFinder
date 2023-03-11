using robotManager.Helpful;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using wManager;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

internal class UserInterface
{
    // Version Header
    //public static string productName = "Radar";
    //public static string productVersion = "0.0";

    public static void InjectLuaFunctions()
    {
        Lua.LuaDoString(string.Format(@"
function petrigger()
    if pe_add then
        pe_add = not pe_add
            return ""pe_add""
        end
    if pe_del then
        pe_del = not pe_del
            return ""pe_del""
        end
    if pe_new then
        pe_new = not pe_new
            return ""pe_new""
        end
    if pe_insert then
        pe_insert = not pe_insert
            return ""pe_insert""
        end
    if pe_secondary then
        pe_secondary = not pe_secondary
            return ""pe_secondary""
        end
    if pe_reposition then
        pe_reposition = not pe_reposition
            return ""pe_reposition""
        end
    if pe_minimap then
        pe_minimap = not pe_minimap
            return ""pe_minimap""
        end
    if pe_showindex then
        pe_showindex = not pe_showindex
            return ""pe_showindex""
        end
    if pe_mark then
        pe_mark = not pe_mark
            return ""pe_mark""
        end
    if pe_save then
        pe_save = not pe_save
            return ""pe_save""
        end
end
function CreateWindow()
    local f = CreateFrame(""Frame"",nil,UIParent)
    f:SetFrameStrata(""BACKGROUND"")
    f:SetWidth(140)  
    f:SetHeight(64)
    f:SetPoint(""RIGHT"", Minimap, ""LEFT"", -90, -90);
    f:SetBackdropColor(0.75, 0.75, 0.75, 0.36);
    f:SetBackdropBorderColor(1, 1, 1, 1);
    f:SetPoint(""CENTER"",0,0);

    btnClose = CreateFrame(""Button"",""btnClose"",f,""UIPanelButtonTemplate"")
    btnClose:SetPoint(""TOPRIGHT"",f,""TOPRIGHT"",-5,-5)
    btnClose:SetWidth(22)
    btnClose:SetHeight(22)
    btnClose:SetText(""X"")
    btnClose:SetScript(""OnClick"",function(self,button,down)
        HideUIPanel(f);
    end);

    btnAdd = CreateFrame(""Button"",""btnAdd"",f,""UIPanelButtonTemplate"")
    btnAdd:SetPoint(""TOPLEFT"",f,""TOPLEFT"",10,-25)
    btnAdd:SetWidth(100)
    btnAdd:SetHeight(22)
    btnAdd:SetText(""新增节点"")
    btnAdd:SetScript(""OnClick"",function(self,button,down)
        pe_add = not pe_add
    end);

    btnDel = CreateFrame(""Button"",""btnDel"",f,""UIPanelButtonTemplate"")
    btnDel:SetPoint(""TOPLEFT"",btnAdd,""BOTTOMLEFT"",0,-5)
    btnDel:SetWidth(100)
    btnDel:SetHeight(22)
    btnDel:SetText(""删除节点"")
    btnDel:SetScript(""OnClick"",function(self,button,down)
        pe_del = not pe_del
    end);

    btnShow = CreateFrame(""Button"",""btnShow"",f,""UIPanelButtonTemplate"")
    btnShow:SetPoint(""TOPLEFT"",btnDel,""BOTTOMLEFT"",0,-5)
    btnShow:SetWidth(100)
    btnShow:SetHeight(22)
    btnShow:SetText(""查看索引"")
    btnShow:SetScript(""OnClick"",function(self,button,down)
        pe_showindex = not pe_showindex
    end);

    btnInsert = CreateFrame(""Button"",""btnInsert"",f,""UIPanelButtonTemplate"")
    btnInsert:SetPoint(""TOPLEFT"",btnShow,""BOTTOMLEFT"",0,-5)
    btnInsert:SetWidth(50)
    btnInsert:SetHeight(22)
    btnInsert:SetText(""主点"")
    btnInsert:SetScript(""OnClick"",function(self,button,down)
        pe_insert = not pe_insert
    end);

    btnInsertSecondary = CreateFrame(""Button"",""btnInsertSecondary"",f,""UIPanelButtonTemplate"")
    btnInsertSecondary:SetPoint(""left"",btnInsert,""TOPRIGHT"",5,0)
    btnInsertSecondary:SetWidth(50)
    btnInsertSecondary:SetHeight(22)
    btnInsertSecondary:SetText(""副点"")
    btnInsertSecondary:SetScript(""OnClick"",function(self,button,down)
        pe_secondary = not pe_secondary
    end);

    btnSave = CreateFrame(""Button"",""btnSave"",f,""UIPanelButtonTemplate"")
    btnSave:SetPoint(""TOPLEFT"",btnInsert,""BOTTOMLEFT"",0,-5)
    btnSave:SetWidth(100)
    btnSave:SetHeight(22)
    btnSave:SetText(""保存数据"")
    btnSave:SetScript(""OnClick"",function(self,button,down)
        pe_save = not pe_save
    end);
    
    f:Show()
end
"
        ));
    }

    public static void SlashCommands()
    {
        // Universal Hotkey: https://wowwiki.fandom.com/wiki/Creating_a_slash_command

        Lua.LuaDoString(string.Format(@"
SLASH_PATHEDITOR1, SLASH_PATHEDITOR2 = '/pe', '/patheditor';

function SlashCmdList.PATHEDITOR(msg, editbox)
	--print(""Hello, World!"");
end


local function PathEditorCommands(msg, editbox)

    ----------------
    -- /pe <command>
    ----------------

    local _, _, arg1 = string.find(msg, ""%s?(%w+)"")

    -- add

    if arg1 == ""add"" then
        --print(""executing "" .. arg1)
        pe_add = not pe_add
        return
    end

    -- delete

    if arg1 == ""del"" then
        --print(""executing "" .. arg1)
        pe_del = not pe_del
        return
    end

    -- new

    if arg1 == ""new"" then
        --print(""executing "" .. arg1)
        pe_new = not pe_new
        return
    end

    -- insert

    if arg1 == ""insert"" then
        --print(""executing "" .. arg1)
        pe_insert = not pe_insert
        return
    end

    -- insert secondary node

    if arg1 == ""secondary"" then
        --print(""executing "" .. arg1)
        pe_secondary = not pe_secondary
        return
    end


    -- reposition

    if arg1 == ""reposition"" then
        --print(""executing "" .. arg1)
        pe_reposition = not pe_reposition
        return
    end

    -- toggle minimap display

    if arg1 == ""minimap"" then
        --print(""executing "" .. arg1)
        pe_minimap = not pe_minimap
        return
    end

    -- show current node index in list

    if arg1 == ""showindex"" then
        --print(""executing "" .. arg1)
        pe_showindex = not pe_showindex
        return
    end

    -- mark point as target

    if arg1 == ""mark"" then
        --print(""executing"" .. arg1)
        pe_mark = not pe_mark
        return 
    end

    -- show lua frame
    if arg1 == ""win"" then
        --print(""executing "" .. arg1)
        CreateWindow()
        return
    end

    -- save data in xml
    if arg1 == ""save"" then
        --print(""executing "".. arg1)
        pe_save = not pe_save
        return
    end
end

SLASH_PATHEDITOR1, SLASH_PATHEDITOR2 = '/pe', '/peditor'
SlashCmdList[""PATHEDITOR""] = PathEditorCommands
CreateWindow()
"
        ));
    }
}