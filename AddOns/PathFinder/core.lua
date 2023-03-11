
index="-1";
xmlName = "PathFinder"
xmlList = {}
xmlCurrent = "";
insertParam = ""
function CreateWindow()
    MainFrame = CreateFrame("Frame",nil,UIParent)
    MainFrame:SetWidth(140)  
    MainFrame:SetHeight(220)
    MainFrame:SetFrameStrata("HIGH");
    MainFrame:SetPoint("TOPRIGHT", Minimap, "BOTTOMLEFT", 0, -100);
    MainFrame:SetBackdropColor(0.75, 0.75, 0.75, 0.36);
    MainFrame:SetBackdropBorderColor(1, 1, 1, 1);
    MainFrame:SetBackdropColor(0.75, 0.75, 0.75, 1);
    MainFrame:SetBackdropBorderColor(1, 1, 1, 1);
    MainFrame:SetBackdrop({
            bgFile ="Interface\\Tooltips\\UI-Tooltip-Background",
            edgeFile ="Interface\\Tooltips\\UI-Tooltip-Border",
            tile = true,
            tileSize = 16,
            edgeSize = 16,
            insets = {left = 5, top = 5, right = 5, bottom = 5}
        })
    MainFrame:SetMovable(true);
    MainFrame:SetClampedToScreen(true);
    MainFrame:SetScript("OnMouseUp",function()
        MainFrame:StopMovingOrSizing();
    end)
    MainFrame:SetScript("OnMouseDown",function()
        MainFrame:StartMoving();
    end)
    

    btnClose = CreateFrame("Button","btnClose",MainFrame,"UIPanelButtonTemplate")
    btnClose:SetPoint("TOPRIGHT",MainFrame,"TOPRIGHT",-5,-5)
    btnClose:SetWidth(22)
    btnClose:SetHeight(22)
    btnClose:SetText("X")
    btnClose:SetScript("OnClick",function(self,button,down)
        txtPos:ClearFocus();
        MainFrame:Hide();
    end);

    btnAdd = CreateFrame("Button","btnAdd",MainFrame,"UIPanelButtonTemplate")
    btnAdd:SetPoint("TOPLEFT",MainFrame,"TOPLEFT",10,-25)
    btnAdd:SetWidth(100)
    btnAdd:SetHeight(22)
    btnAdd:SetText("新增节点")
    btnAdd:SetScript("OnClick",function(self,button,down)
        txtPos:ClearFocus();
        pe_add = not pe_add
    end);

    btnDel = CreateFrame("Button","btnDel",MainFrame,"UIPanelButtonTemplate")
    btnDel:SetPoint("TOPLEFT",btnAdd,"BOTTOMLEFT",0,-5)
    btnDel:SetWidth(100)
    btnDel:SetHeight(22)
    btnDel:SetText("删除节点")
    btnDel:SetScript("OnClick",function(self,button,down)
        txtPos:ClearFocus();
        pe_del = not pe_del
    end);

    txtPos = CreateFrame("EditBox","txtPos",MainFrame,"InputBoxTemplate")
    txtPos:SetPoint("TOPLEFT",btnDel,"BOTTOMLEFT",10,-5)
    txtPos:SetWidth(90)
    txtPos:SetHeight(22)
    txtPos:SetText("-1")
    if txtPos:IsAutoFocus() then
        txtPos:SetAutoFocus(false)
    end

    btnInsert = CreateFrame("Button","btnInsert",MainFrame,"UIPanelButtonTemplate")
    btnInsert:SetPoint("TOPLEFT",txtPos,"BOTTOMLEFT",-10,-5)
    btnInsert:SetWidth(50)
    btnInsert:SetHeight(22)
    btnInsert:SetText("主点")
    btnInsert:SetScript("OnClick",function(self,button,down)
        txtPos:ClearFocus();
        index = txtPos:GetText()
        pe_insert = not pe_insert
    end);

    btnInsertSecondary = CreateFrame("Button","btnInsertSecondary",MainFrame,"UIPanelButtonTemplate")
    btnInsertSecondary:SetPoint("TOPLEFT",btnInsert,"TOPRIGHT",5,0)
    btnInsertSecondary:SetWidth(50)
    btnInsertSecondary:SetHeight(22)
    btnInsertSecondary:SetText("副点")
    btnInsertSecondary:SetScript("OnClick",function(self,button,down)
        txtPos:ClearFocus();
        index = txtPos:GetText()
        pe_secondary = not pe_secondary
    end);

    btnShow = CreateFrame("Button","btnShow",MainFrame,"UIPanelButtonTemplate")
    btnShow:SetPoint("TOPLEFT",btnInsert,"BOTTOMLEFT",0,-5)
    btnShow:SetWidth(100)
    btnShow:SetHeight(22)
    btnShow:SetText("查看索引")
    btnShow:SetScript("OnClick",function(self,button,down)
        txtPos:ClearFocus();
        pe_showindex = not pe_showindex
    end);

    btnSave = CreateFrame("Button","btnSave",MainFrame,"UIPanelButtonTemplate")
    btnSave:SetPoint("TOPLEFT",btnShow,"BOTTOMLEFT",0,-5)
    btnSave:SetWidth(100)
    btnSave:SetHeight(22)
    btnSave:SetText("保存数据")
    btnSave:SetScript("OnClick",function(self,button,down)
        txtPos:ClearFocus();
        pe_save = not pe_save
    end);

    btnReload = CreateFrame("Button","btnSave",MainFrame,"UIPanelButtonTemplate")
    btnReload:SetPoint("TOPLEFT",btnSave,"BOTTOMLEFT",0,-5)
    btnReload:SetWidth(100)
    btnReload:SetHeight(22)
    btnReload:SetText("重载路径")
    btnReload:SetScript("OnClick",function(self,button,down)
        txtPos:ClearFocus();
        CreatePopupList();
    end);
    --[[
    btnTest = CreateFrame("Button","btnTest",MainFrame,"UIPanelButtonTemplate")
    btnTest:SetPoint("TOPLEFT",btnReload,"BOTTOMLEFT",0,-5)
    btnTest:SetWidth(100)
    btnTest:SetHeight(22)
    btnTest:SetText("测试")
    btnTest:SetScript("OnClick",function(self,button,down)
        txtPos:ClearFocus();
        --local str1 = petrigger()
        --SendChatMessage(str1,"SAY")
        --SendChatMessage(insertParam,"SAY")
        --SendChatMessage(xmlList[1],"SAY")
        CreatePopupList();
    end);
    ]]
end
function CreatePopupList()
    optionFrame = CreateFrame("Frame",nil,UIParent)
    optionFrame:SetWidth(200)  
    optionFrame:SetHeight(200)
    optionFrame:SetFrameStrata("HIGH");
    optionFrame:SetPoint("Center", 0, -100);
    optionFrame:SetBackdropColor(0.75, 0.75, 0.75, 0.36);
    optionFrame:SetBackdropBorderColor(1, 1, 1, 1);
    optionFrame:SetBackdropColor(0.75, 0.75, 0.75, 1);
    optionFrame:SetBackdropBorderColor(1, 1, 1, 1);
    optionFrame:SetBackdrop({
            bgFile ="Interface\\Tooltips\\UI-Tooltip-Background",
            edgeFile ="Interface\\Tooltips\\UI-Tooltip-Border",
            tile = true,
            tileSize = 16,
            edgeSize = 16,
            insets = {left = 5, top = 5, right = 5, bottom = 5}
        })
    optionFrame:SetMovable(true);
    optionFrame:SetClampedToScreen(true);
    optionFrame:SetScript("OnMouseUp",function()
        optionFrame:StopMovingOrSizing();
    end)
    optionFrame:SetScript("OnMouseDown",function()
        optionFrame:StartMoving();
    end)

    --xmlList
    for i=1, table.getn(xmlList) do      
        cb = CreateFrame("Button","Button",optionFrame,"UIPanelButtonTemplate");
        cb:SetPoint("TOPLEFT",optionFrame,"TOPLEFT",5,-5-i*25)
        cb:SetWidth(180)
        cb:SetHeight(22)
        cb:SetText(xmlList[i])
        cb:SetScript("OnClick",function(self,button,down)
            xmlCurrent = this:GetText()
            print("准备重载路径:"..xmlCurrent);
            pe_reload = not pe_reload
            optionFrame:Hide();
        end);
    end  
    optionFrame:Show()
end
function InsertXmlName(names)
    insertParam = names
    xmlList = Split(names,",")
end
function Split(str,reps)
    local resultStrList = {}
    string.gsub(str,'[^'..reps..']+',function (w)
        table.insert(resultStrList,w)
    end)
    return resultStrList
end
function print(msg)
    SendChatMessage(msg,"SAY");
end
function petrigger()
    if pe_add then
        pe_add = not pe_add
            return "pe_add"
        end
    if pe_del then
        pe_del = not pe_del
            return "pe_del"
        end
    if pe_new then
        pe_new = not pe_new
            return "pe_new"
        end
    if pe_insert then
        pe_insert = not pe_insert
            return "pe_insert("..index..")"
        end
    if pe_secondary then
        pe_secondary = not pe_secondary
            return "pe_secondary("..index..")"
        end
    if pe_reposition then
        pe_reposition = not pe_reposition
            return "pe_reposition"
        end
    if pe_minimap then
        pe_minimap = not pe_minimap
            return "pe_minimap"
        end
    if pe_showindex then
        pe_showindex = not pe_showindex
            return "pe_showindex"
        end
    if pe_mark then
        pe_mark = not pe_mark
            return "pe_mark"
        end
    if pe_save then
        pe_save = not pe_save
            return "pe_save"
        end
    if pe_reload then
        pe_reload = not pe_reload
        return "pe_reload("..xmlCurrent..")"
    end
end

----------------------------------------------------------------
--#regionID slash command
----------------------------------------------------------------
SLASH_PATHEDITOR1, SLASH_PATHEDITOR2 = '/pe', '/patheditor';
function SlashCmdList.PATHEDITOR(msg, editbox)
	--print("Hello, World!");
end
local function PathEditorCommands(msg, editbox)

    ----------------
    -- /pe <command>
    ----------------

    local _, _, arg1 = string.find(msg, "%s?(%w+)")
    -- add
    if arg1 == "add" then
        --print("executing " .. arg1)
        pe_add = not pe_add
        return
    end
    -- delete
    if arg1 == "del" then
        --print("executing " .. arg1)
        pe_del = not pe_del
        return
    end
    -- new
    if arg1 == "new" then
        --print("executing " .. arg1)
        pe_new = not pe_new
        return
    end
    -- insert
    if arg1 == "insert" then
        --print("executing " .. arg1)
        pe_insert = not pe_insert
        return
    end
    -- insert secondary node
    if arg1 == "secondary" then
        --print("executing " .. arg1)
        pe_secondary = not pe_secondary
        return
    end
    -- reposition
    if arg1 == "reposition" then
        --print("executing " .. arg1)
        pe_reposition = not pe_reposition
        return
    end
    -- toggle minimap display
    if arg1 == "minimap" then
        --print("executing " .. arg1)
        pe_minimap = not pe_minimap
        return
    end
    -- show current node index in list
    if arg1 == "showindex" then
        --print("executing " .. arg1)
        pe_showindex = not pe_showindex
        return
    end
    -- mark point as target
    if arg1 == "mark" then
        --print("executing" .. arg1)
        pe_mark = not pe_mark
        return 
    end
    -- show lua frame
    if arg1 == "win" then
        --print("executing " .. arg1)
        if not MainFrame:IsVisible() then
            MainFrame:Show()
        else 
            MainFrame:Hide()
        end
        return
    end
    -- save data in xml
    if arg1 == "save" then
        --print("executing ".. arg1)
        pe_save = not pe_save
        return
    end
    -- change xml file then reload
    if arg1 == "reload" then
        --print("executing "..arg1)
        pe_reload = not pe_reload
        return
    end
end
SLASH_PATHEDITOR1, SLASH_PATHEDITOR2 = '/pe', '/peditor'
SlashCmdList["PATHEDITOR"] = PathEditorCommands

----------------------------------------------------------------
-- execute code
----------------------------------------------------------------
CreateWindow()
--InsertXmlName("PathEdit.xml,DeadPosition.xml");
MainFrame:Show()