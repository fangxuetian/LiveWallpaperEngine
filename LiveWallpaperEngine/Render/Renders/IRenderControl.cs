﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LiveWallpaperEngineRender.Renders
{
    public interface IRenderControl
    {
        void InitRender();
        void Load(string path);
        void Stop();
        void Pause();
        void Resum();
        void DisposeRender();
        void SetVolume(int volume);
    }
}
