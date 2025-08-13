Namespace = "wuemu.dev.items"
Name = "DevWand"

function Item:Initialize()
    self:SetName("Developer Wand")
    self:SetIcon(ItemIcon.ICON_WAND_EBONY)
end

function Item:GetContextMenu(player)
    return {
        {Id=1000, Caption="Give me the board"}
    }
end

function Item:MenuItemClick(player, id)
    if id == 1000 then
        player:PlayAnimation("spell.tornado", false)
        player:AddItemToInventory("wuemu.dev.items.TheBoard")
    end
end
