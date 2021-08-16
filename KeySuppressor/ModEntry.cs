using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Menus;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace KeySuppressor
{
    public class ModEntry : Mod
    {

        #region Properties
        public static IMonitor MonitorObject { get; private set; }
        private ModConfig Config;

        #endregion


        #region Entry
        public override void Entry(IModHelper helper)
        {
            MonitorObject = Monitor;
            Config = this.Helper.ReadConfig<ModConfig>();
            helper.Events.Input.ButtonsChanged += SuppressKeys;

        }

        // Set very low (even lower than low) event priority so that this event is handled after all other mods have handled that event. That way the keys are only suppressed for the base game functionality.
        #endregion
        [EventPriority(EventPriority.Low - 10000)]
        private void SuppressKeys(object sender, ButtonsChangedEventArgs e)
        {
            if (Config != null)
            {
                foreach (var keyValue in Config.SuppressedKeys)
                {
                    if (keyValue.Value)
                    {
                        this.Helper.Input.SuppressActiveKeybinds(KeybindList.ForSingle(keyValue.Key));
                    }
                }
            }
        }
    }
}
