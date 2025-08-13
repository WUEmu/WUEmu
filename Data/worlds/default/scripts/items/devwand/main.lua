Namespace = "wuemu.dev.items"
Name = "DevWand"

function Item:Initialize()
    self:SetName("Developer Wand")
    self:SetIcon(ItemIcon.ICON_WAND_EBONY)
end

function Item:GetContextMenu(player)
    return {
        {Id=1000, Caption="Place a table"},
        {Id=1001, Caption="Talk to me"}
    }
end