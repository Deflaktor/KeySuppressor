using StardewModdingAPI;
using StardewModdingAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeySuppressor
{
    class ModConfig
    {
        public enum SuppressMode
        {
            DoNotSuppress,
            Suppress,
            SuppressOnlyWhenInMenu,
            SuppressOnlyWhenNotInMenu
        }

        public Dictionary<SButton, SuppressMode> SuppressedKeys { get; set; } = GetDefaultSuppressedKeys();

        private static Dictionary<SButton, SuppressMode> GetDefaultSuppressedKeys()
        {
            var defaultSuppressedKeys = new Dictionary<SButton, SuppressMode>();
            defaultSuppressedKeys.Add(SButton.DPadDown, true);
            defaultSuppressedKeys.Add(SButton.DPadLeft, true);
            defaultSuppressedKeys.Add(SButton.DPadRight, true);
            defaultSuppressedKeys.Add(SButton.DPadUp, true);
            defaultSuppressedKeys.Add(SButton.LeftShift, true);
            defaultSuppressedKeys.Add(SButton.RightStick, true);
            defaultSuppressedKeys.Add(SButton.ControllerA, false);
            defaultSuppressedKeys.Add(SButton.ControllerB, false);
            defaultSuppressedKeys.Add(SButton.ControllerX, false);
            defaultSuppressedKeys.Add(SButton.ControllerY, false);
            defaultSuppressedKeys.Add(SButton.ControllerBack, false);
            defaultSuppressedKeys.Add(SButton.ControllerStart, false);
            defaultSuppressedKeys.Add(SButton.BigButton, false);
            defaultSuppressedKeys.Add(SButton.LeftShoulder, false);
            defaultSuppressedKeys.Add(SButton.RightShoulder, false);
            defaultSuppressedKeys.Add(SButton.LeftTrigger, false);
            defaultSuppressedKeys.Add(SButton.RightTrigger, false);
            defaultSuppressedKeys.Add(SButton.LeftThumbstickDown, false);
            defaultSuppressedKeys.Add(SButton.LeftThumbstickLeft, false);
            defaultSuppressedKeys.Add(SButton.LeftThumbstickRight, false);
            defaultSuppressedKeys.Add(SButton.LeftThumbstickUp, false);
            defaultSuppressedKeys.Add(SButton.RightThumbstickDown, false);
            defaultSuppressedKeys.Add(SButton.RightThumbstickLeft, false);
            defaultSuppressedKeys.Add(SButton.RightThumbstickRight, false);
            defaultSuppressedKeys.Add(SButton.RightThumbstickUp, false);
            return defaultSuppressedKeys;
        }
    }
}
