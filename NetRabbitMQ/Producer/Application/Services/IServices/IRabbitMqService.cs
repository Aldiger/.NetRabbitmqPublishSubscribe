﻿namespace Producer
{
    public interface IRabbitMqService
    {
        void SendMessage<T>(T message);
    }
}
