Namespace = "wuemu"
Name = "bml"

BmlBuilder = {}
BmlBuilder.__index = BmlBuilder

function BmlBuilder:new()
    local builder = {}
    setmetatable(builder, BmlBuilder)
    return builder
end

function BmlBuilder:addText()
end

function MakeForm()
    return BMLForm()
end
