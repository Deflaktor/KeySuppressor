using StardewModdingAPI;
using System.Collections.Generic;

namespace KeySuppressor
{
    class ModConfig
    {
        public enum SuppressMode
        {
            DoNotSuppress,
            Suppress,
            SuppressOnlyInMenu,
            SuppressOnlyWhenPlayerFree,
            SuppressOnlyWhenPlayerCanMove
        }

        public Dictionary<SButton, SuppressMode> SuppressedKeys { get; set; } = GetDefaultSuppressedKeys();

        private static Dictionary<SButton, SuppressMode> GetDefaultSuppressedKeys()
        {
            var defaultSuppressedKeys = new Dictionary<SButton, SuppressMode>
            {
                { SButton.DPadUp, SuppressMode.DoNotSuppress },
                { SButton.DPadDown, SuppressMode.DoNotSuppress },
                { SButton.DPadLeft, SuppressMode.DoNotSuppress },
                { SButton.DPadRight, SuppressMode.DoNotSuppress },
                { SButton.ControllerA, SuppressMode.DoNotSuppress },
                { SButton.ControllerB, SuppressMode.SuppressOnlyWhenPlayerFree },
                { SButton.ControllerX, SuppressMode.DoNotSuppress },
                { SButton.ControllerY, SuppressMode.DoNotSuppress },
                { SButton.LeftStick, SuppressMode.DoNotSuppress },
                { SButton.LeftThumbstickUp, SuppressMode.DoNotSuppress },
                { SButton.LeftThumbstickDown, SuppressMode.DoNotSuppress },
                { SButton.LeftThumbstickLeft, SuppressMode.DoNotSuppress },
                { SButton.LeftThumbstickRight, SuppressMode.DoNotSuppress },
                { SButton.RightStick, SuppressMode.Suppress },
                { SButton.RightThumbstickUp, SuppressMode.DoNotSuppress },
                { SButton.RightThumbstickDown, SuppressMode.DoNotSuppress },
                { SButton.RightThumbstickLeft, SuppressMode.DoNotSuppress },
                { SButton.RightThumbstickRight, SuppressMode.DoNotSuppress },
                { SButton.LeftShoulder, SuppressMode.DoNotSuppress },
                { SButton.LeftTrigger, SuppressMode.DoNotSuppress },
                { SButton.RightShoulder, SuppressMode.DoNotSuppress },
                { SButton.RightTrigger, SuppressMode.DoNotSuppress },
                { SButton.ControllerBack, SuppressMode.DoNotSuppress },
                { SButton.ControllerStart, SuppressMode.DoNotSuppress },
                { SButton.BigButton, SuppressMode.DoNotSuppress }
            };
            return defaultSuppressedKeys;
        }
    }
}
