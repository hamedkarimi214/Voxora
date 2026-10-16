using System;
using System.Collections.Generic;
using System.Text;

namespace Voxora.Models
{
    public interface IWindowService
    {
        void WindowClose();
        void WindowState();
        void WindowMinimize();
    }
}
