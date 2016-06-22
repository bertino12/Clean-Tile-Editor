using Microsoft.Xna.Framework.Graphics;
using System;

public class ServiceProvider : IServiceProvider
{
    private readonly IGraphicsDeviceService deviceService;

    public ServiceProvider(IGraphicsDeviceService deviceService)
    {
        this.deviceService = deviceService;
    }

    public object GetService(Type serviceType)
    {
        return deviceService;
    }

}

