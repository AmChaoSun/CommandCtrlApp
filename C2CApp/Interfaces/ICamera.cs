﻿using System;
namespace C2CApp.Interfaces
{
    //common methods for all cameras
    public interface ICamera
    {
        void Snapshot();
        void ZoomIn();
        void ZoomOut();
    }
}
