--[[

This is the board. It is the main object in the game for now.

]]
Namespace = "wuemu.dev.items"
Name = "TheBoard"

function Item:Initialize()
    self:SetName("The Board")
    self:SetModel("model.sign.messageboard")
end

