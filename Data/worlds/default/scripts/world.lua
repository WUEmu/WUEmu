print("What is going on?")

function World:OnPlayerJoined(player)
    player:JoinChannel(":Script")
end

function World:OnPlayerChat(message)
    if message.Channel == ":Script" then
        local s, compileError = load(message.Text)
        if s == nil then
            self:SendMessage(":Script", compileError, 1.0, 0.0, 0.0)
        end
        
        local res, err = pcall(s)
        if not res then
            self:SendMessage(":Script", err, 1.0, 0.0, 0.0)
        end        
    else
        self:SendMessage(message.Channel, message.Sender.Name .. ": " .. message.Text)
    end
end
