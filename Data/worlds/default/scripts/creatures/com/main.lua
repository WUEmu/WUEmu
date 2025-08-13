Creature.namespace = "wuemu.dev.creature"
Creature.name = "Dragon"

function do_walk()
    World.SendMessage(":Local", "This is a scripted timer!")
end

function Creature:Initialize()
    local colors = {"red", "blue", "green", "black", "white"}
    local color_id = math.random(1, 5)
    local color_suffix = colors[color_id]

    self:SetModel("model.creature.dragon." .. color_suffix)
    self:SetName("A scary dragon")
	self:SetRarity(5)
	self:SetCreatureType(6)

    -- self:CreateTimer()
    TimerNew("Dragon Walk Timer", 5, do_walk)
end

