--[[

This is the board. It is the main object in the game for now.

]]
Namespace = "wuemu.dev.items"
Name = "TheBoard"

function Item:Initialize()
    self:SetName("The Board")
    self:SetModel("model.sign.messageboard")
    self:SetIcon(ItemIcon.ICON_SCROLL_VILLAGE)
end

function Item:GetContextMenu(player)
    return {
        {Id=1000, Caption="Place"}        
    }
end

function Item:MenuItemClick(player, id)
    if id == 1000 then
        self:StartPlacing(player)
    end
end

function Item:Placed(player)
    player:RemoveItemFromInventory(self)
end
