Namespace = "wuemu.dev.creature"
Name = "Dragon"

-- require "wuemu.bml"

function Creature:Initialize()
    local colors = {"red", "blue", "green", "black", "white"}
    local color_id = math.random(1, 5)
    local color_suffix = colors[color_id]

    self:SetModel("model.creature.dragon." .. color_suffix)
    self:SetName("A scary dragon")
	self:SetRarity(5)
	self:SetCreatureType(6)

    print(self.CurrentZone.Width)
end

function Creature:GetContextMenu(session)
    return {
        {Id=2000, Caption="Who are you?"},
        {Id=2005, Caption="Talk to me"},
    }
end

function Creature:MenuItemClick(player, id)
    if id == 2000 then
        World:SendMessage(":Local", "I am the big mighty dragon!")
        self:Move(self.Position.X + 12, self.Position.Y + 12, self.Rotation)
    elseif id == 2005 then
        local content = "varray{rescale=\"true\";"
        content = content .. "header{text=\"Dragon\"};"
        content = content .. "text{text=\"Little one... you dare to stand in my shadow? Speak, before I decide whether you are guest... or supper.\"};"
        content = content .. "button{id=\"option1\";text=\"I mean no harm, mighty dragon. I seek only knowledge.\"};"
        content = content .. "button{id=\"option2\";text=\"Back off, lizard, or I'll turn you into boots.\"};"
        content = content .. "button{id=\"option3\";text=\"Uh... sorry, I think I'm lost.\"};"
        content = content .. "}"

        local form = BmlForm.__new(100, "Conversation with dragon", content)
        player:SendForm(form)
    end
end
