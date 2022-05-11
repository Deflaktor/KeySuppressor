using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace KeySuppressor
{
    public class ModEntry : Mod
    {

        #region Properties
        public static IMonitor MonitorObject { get; private set; }
        private ModConfig config;

        #endregion


        #region Entry
        public override void Entry(IModHelper helper)
        {
            MonitorObject = Monitor;
            config = this.Helper.ReadConfig<ModConfig>();
            helper.Events.Input.ButtonsChanged += SuppressKeys;
            helper.Events.GameLoop.GameLaunched += OnLaunch;

        }

        private void OnLaunch(object sender, GameLaunchedEventArgs e)
        {
            //GMCM support
            var configMenu = this.Helper.ModRegistry.GetApi<GenericModConfigMenu.IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu");
            if (configMenu == null) return;

            configMenu.Register(
                mod: this.ModManifest,
                reset: () => this.config = new ModConfig(),
                save: () => this.Helper.WriteConfig(this.config)
            );

            string toString(ModConfig.SuppressMode mode)
            {
                return mode switch
                {
                    ModConfig.SuppressMode.DoNotSuppress => "DoNotSuppress",
                    ModConfig.SuppressMode.Suppress => "Suppress",
                    ModConfig.SuppressMode.SuppressOnlyInMenu => "SuppressOnlyInMenu",
                    ModConfig.SuppressMode.SuppressOnlyWhenPlayerFree => "SuppressWhenPlayerFree",
                    ModConfig.SuppressMode.SuppressOnlyWhenPlayerCanMove => "SuppressOnlyWhenPlayerCanMove",
                    _ => null,
                };
            }

            ModConfig.SuppressMode toMode(string mode)
            {
                return mode switch
                {
                    "DoNotSuppress" => ModConfig.SuppressMode.DoNotSuppress,
                    "Suppress" => ModConfig.SuppressMode.Suppress,
                    "SuppressOnlyInMenu" => ModConfig.SuppressMode.SuppressOnlyInMenu,
                    "SuppressWhenPlayerFree" => ModConfig.SuppressMode.SuppressOnlyWhenPlayerFree,
                    "SuppressOnlyWhenPlayerCanMove" => ModConfig.SuppressMode.SuppressOnlyWhenPlayerCanMove,
                    _ => throw new System.Exception("Invalid mode!")
                };
            }

            configMenu.AddSectionTitle(
                mod: this.ModManifest,
                text: () => "DPad Buttons"
            );

            configMenu.AddTextOption(
                mod: this.ModManifest,
                name: () => "DPad Up",
                getValue: () => toString(config.SuppressedKeys[SButton.DPadUp]),
                setValue: value => this.config.SuppressedKeys[SButton.DPadUp] = toMode(value),
                allowedValues: new string[] { "DoNotSuppress", "Suppress", "SuppressOnlyInMenu", "SuppressWhenPlayerFree", "SuppressOnlyWhenPlayerCanMove" }
            );

            configMenu.AddTextOption(
                mod: this.ModManifest,
                name: () => "DPad Down",
                getValue: () => toString(config.SuppressedKeys[SButton.DPadDown]),
                setValue: value => this.config.SuppressedKeys[SButton.DPadDown] = toMode(value),
                allowedValues: new string[] { "DoNotSuppress", "Suppress", "SuppressOnlyInMenu", "SuppressWhenPlayerFree", "SuppressOnlyWhenPlayerCanMove" }
            );

            configMenu.AddTextOption(
                mod: this.ModManifest,
                name: () => "DPad Left",
                getValue: () => toString(config.SuppressedKeys[SButton.DPadLeft]),
                setValue: value => this.config.SuppressedKeys[SButton.DPadLeft] = toMode(value),
                allowedValues: new string[] { "DoNotSuppress", "Suppress", "SuppressOnlyInMenu", "SuppressWhenPlayerFree", "SuppressOnlyWhenPlayerCanMove" }
            );

            configMenu.AddTextOption(
                mod: this.ModManifest,
                name: () => "DPad Right",
                getValue: () => toString(config.SuppressedKeys[SButton.DPadRight]),
                setValue: value => this.config.SuppressedKeys[SButton.DPadRight] = toMode(value),
                allowedValues: new string[] { "DoNotSuppress", "Suppress", "SuppressOnlyInMenu", "SuppressWhenPlayerFree", "SuppressOnlyWhenPlayerCanMove" }
            );

            configMenu.AddSectionTitle(
                mod: this.ModManifest,
                text: () => "Face Buttons"
            );

            configMenu.AddTextOption(
                mod: this.ModManifest,
                name: () => "A",
                getValue: () => toString(config.SuppressedKeys[SButton.ControllerA]),
                setValue: value => this.config.SuppressedKeys[SButton.ControllerA] = toMode(value),
                allowedValues: new string[] { "DoNotSuppress", "Suppress", "SuppressOnlyInMenu", "SuppressWhenPlayerFree", "SuppressOnlyWhenPlayerCanMove" }
            );

            configMenu.AddTextOption(
                mod: this.ModManifest,
                name: () => "B",
                getValue: () => toString(config.SuppressedKeys[SButton.ControllerB]),
                setValue: value => this.config.SuppressedKeys[SButton.ControllerB] = toMode(value),
                allowedValues: new string[] { "DoNotSuppress", "Suppress", "SuppressOnlyInMenu", "SuppressWhenPlayerFree", "SuppressOnlyWhenPlayerCanMove" }
            );

            configMenu.AddTextOption(
                mod: this.ModManifest,
                name: () => "X",
                getValue: () => toString(config.SuppressedKeys[SButton.ControllerX]),
                setValue: value => this.config.SuppressedKeys[SButton.ControllerX] = toMode(value),
                allowedValues: new string[] { "DoNotSuppress", "Suppress", "SuppressOnlyInMenu", "SuppressWhenPlayerFree", "SuppressOnlyWhenPlayerCanMove" }
            );

            configMenu.AddTextOption(
                mod: this.ModManifest,
                name: () => "Y",
                getValue: () => toString(config.SuppressedKeys[SButton.ControllerY]),
                setValue: value => this.config.SuppressedKeys[SButton.ControllerY] = toMode(value),
                allowedValues: new string[] { "DoNotSuppress", "Suppress", "SuppressOnlyInMenu", "SuppressWhenPlayerFree", "SuppressOnlyWhenPlayerCanMove" }
            );

            configMenu.AddSectionTitle(
                mod: this.ModManifest,
                text: () => "Analog Thumbsticks"
            );

            configMenu.AddTextOption(
                mod: this.ModManifest,
                name: () => "Left Thumbstick Button",
                getValue: () => toString(config.SuppressedKeys[SButton.LeftStick]),
                setValue: value => this.config.SuppressedKeys[SButton.LeftStick] = toMode(value),
                allowedValues: new string[] { "DoNotSuppress", "Suppress", "SuppressOnlyInMenu", "SuppressWhenPlayerFree", "SuppressOnlyWhenPlayerCanMove" }
            );

            configMenu.AddTextOption(
                mod: this.ModManifest,
                name: () => "Left Thumbstick Up",
                getValue: () => toString(config.SuppressedKeys[SButton.LeftThumbstickUp]),
                setValue: value => this.config.SuppressedKeys[SButton.LeftThumbstickUp] = toMode(value),
                allowedValues: new string[] { "DoNotSuppress", "Suppress", "SuppressOnlyInMenu", "SuppressWhenPlayerFree", "SuppressOnlyWhenPlayerCanMove" }
            );

            configMenu.AddTextOption(
                mod: this.ModManifest,
                name: () => "Left Thumbstick Down",
                getValue: () => toString(config.SuppressedKeys[SButton.LeftThumbstickDown]),
                setValue: value => this.config.SuppressedKeys[SButton.LeftThumbstickDown] = toMode(value),
                allowedValues: new string[] { "DoNotSuppress", "Suppress", "SuppressOnlyInMenu", "SuppressWhenPlayerFree", "SuppressOnlyWhenPlayerCanMove" }
            );

            configMenu.AddTextOption(
                mod: this.ModManifest,
                name: () => "Left Thumbstick Left",
                getValue: () => toString(config.SuppressedKeys[SButton.LeftThumbstickLeft]),
                setValue: value => this.config.SuppressedKeys[SButton.LeftThumbstickLeft] = toMode(value),
                allowedValues: new string[] { "DoNotSuppress", "Suppress", "SuppressOnlyInMenu", "SuppressWhenPlayerFree", "SuppressOnlyWhenPlayerCanMove" }
            );

            configMenu.AddTextOption(
                mod: this.ModManifest,
                name: () => "Left Thumbstick Right",
                getValue: () => toString(config.SuppressedKeys[SButton.LeftThumbstickRight]),
                setValue: value => this.config.SuppressedKeys[SButton.LeftThumbstickRight] = toMode(value),
                allowedValues: new string[] { "DoNotSuppress", "Suppress", "SuppressOnlyInMenu", "SuppressWhenPlayerFree", "SuppressOnlyWhenPlayerCanMove" }
            );

            configMenu.AddTextOption(
                mod: this.ModManifest,
                name: () => "Right Stick Button",
                getValue: () => toString(config.SuppressedKeys[SButton.RightStick]),
                setValue: value => this.config.SuppressedKeys[SButton.RightStick] = toMode(value),
                allowedValues: new string[] { "DoNotSuppress", "Suppress", "SuppressOnlyInMenu", "SuppressWhenPlayerFree", "SuppressOnlyWhenPlayerCanMove" }
            );

            configMenu.AddTextOption(
                mod: this.ModManifest,
                name: () => "Right Thumbstick Up",
                getValue: () => toString(config.SuppressedKeys[SButton.RightThumbstickUp]),
                setValue: value => this.config.SuppressedKeys[SButton.RightThumbstickUp] = toMode(value),
                allowedValues: new string[] { "DoNotSuppress", "Suppress", "SuppressOnlyInMenu", "SuppressWhenPlayerFree", "SuppressOnlyWhenPlayerCanMove" }
            );

            configMenu.AddTextOption(
                mod: this.ModManifest,
                name: () => "Right Thumbstick Down",
                getValue: () => toString(config.SuppressedKeys[SButton.RightThumbstickDown]),
                setValue: value => this.config.SuppressedKeys[SButton.RightThumbstickDown] = toMode(value),
                allowedValues: new string[] { "DoNotSuppress", "Suppress", "SuppressOnlyInMenu", "SuppressWhenPlayerFree", "SuppressOnlyWhenPlayerCanMove" }
            );

            configMenu.AddTextOption(
                mod: this.ModManifest,
                name: () => "Right Thumbstick Left",
                getValue: () => toString(config.SuppressedKeys[SButton.RightThumbstickLeft]),
                setValue: value => this.config.SuppressedKeys[SButton.RightThumbstickLeft] = toMode(value),
                allowedValues: new string[] { "DoNotSuppress", "Suppress", "SuppressOnlyInMenu", "SuppressWhenPlayerFree", "SuppressOnlyWhenPlayerCanMove" }
            );

            configMenu.AddTextOption(
                mod: this.ModManifest,
                name: () => "Right Thumbstick Right",
                getValue: () => toString(config.SuppressedKeys[SButton.RightThumbstickRight]),
                setValue: value => this.config.SuppressedKeys[SButton.RightThumbstickRight] = toMode(value),
                allowedValues: new string[] { "DoNotSuppress", "Suppress", "SuppressOnlyInMenu", "SuppressWhenPlayerFree", "SuppressOnlyWhenPlayerCanMove" }
            );

            configMenu.AddSectionTitle(
                mod: this.ModManifest,
                text: () => "Trigger/Shoulder Buttons"
            );

            configMenu.AddTextOption(
                mod: this.ModManifest,
                name: () => "Left Trigger",
                getValue: () => toString(config.SuppressedKeys[SButton.LeftTrigger]),
                setValue: value => this.config.SuppressedKeys[SButton.LeftTrigger] = toMode(value),
                allowedValues: new string[] { "DoNotSuppress", "Suppress", "SuppressOnlyInMenu", "SuppressWhenPlayerFree", "SuppressOnlyWhenPlayerCanMove" }
            );

            configMenu.AddTextOption(
                mod: this.ModManifest,
                name: () => "Left Shoulder",
                getValue: () => toString(config.SuppressedKeys[SButton.LeftShoulder]),
                setValue: value => this.config.SuppressedKeys[SButton.LeftShoulder] = toMode(value),
                allowedValues: new string[] { "DoNotSuppress", "Suppress", "SuppressOnlyInMenu", "SuppressWhenPlayerFree", "SuppressOnlyWhenPlayerCanMove" }
            );

            configMenu.AddTextOption(
                mod: this.ModManifest,
                name: () => "Right Trigger",
                getValue: () => toString(config.SuppressedKeys[SButton.RightTrigger]),
                setValue: value => this.config.SuppressedKeys[SButton.RightTrigger] = toMode(value),
                allowedValues: new string[] { "DoNotSuppress", "Suppress", "SuppressOnlyInMenu", "SuppressWhenPlayerFree", "SuppressOnlyWhenPlayerCanMove" }
            );

            configMenu.AddTextOption(
                mod: this.ModManifest,
                name: () => "Right Shoulder",
                getValue: () => toString(config.SuppressedKeys[SButton.RightShoulder]),
                setValue: value => this.config.SuppressedKeys[SButton.RightShoulder] = toMode(value),
                allowedValues: new string[] { "DoNotSuppress", "Suppress", "SuppressOnlyInMenu", "SuppressWhenPlayerFree", "SuppressOnlyWhenPlayerCanMove" }
            );

            configMenu.AddSectionTitle(
                mod: this.ModManifest,
                text: () => "Menu Buttons"
            );

            configMenu.AddTextOption(
                mod: this.ModManifest,
                name: () => "Start",
                getValue: () => toString(config.SuppressedKeys[SButton.ControllerStart]),
                setValue: value => this.config.SuppressedKeys[SButton.ControllerStart] = toMode(value),
                allowedValues: new string[] { "DoNotSuppress", "Suppress", "SuppressOnlyInMenu", "SuppressWhenPlayerFree", "SuppressOnlyWhenPlayerCanMove" }
            );

            configMenu.AddTextOption(
                mod: this.ModManifest,
                name: () => "Back",
                getValue: () => toString(config.SuppressedKeys[SButton.ControllerBack]),
                setValue: value => this.config.SuppressedKeys[SButton.ControllerBack] = toMode(value),
                allowedValues: new string[] { "DoNotSuppress", "Suppress", "SuppressOnlyInMenu", "SuppressWhenPlayerFree", "SuppressOnlyWhenPlayerCanMove" }
            );

            configMenu.AddTextOption(
                mod: this.ModManifest,
                name: () => "Big Button",
                getValue: () => toString(config.SuppressedKeys[SButton.BigButton]),
                setValue: value => this.config.SuppressedKeys[SButton.BigButton] = toMode(value),
                allowedValues: new string[] { "DoNotSuppress", "Suppress", "SuppressOnlyInMenu", "SuppressWhenPlayerFree", "SuppressOnlyWhenPlayerCanMove" }
            );
        }

        // Set very low (even lower than low) event priority so that this event is handled after all other mods have handled that event. That way the keys are only suppressed for the base game functionality.
        #endregion
        [EventPriority(EventPriority.Low - 10000)]
        private void SuppressKeys(object sender, ButtonsChangedEventArgs e)
        {
            if (config != null)
            {
                foreach (var keyValue in config.SuppressedKeys)
                {
                    switch (keyValue.Value)
                    {
                        case ModConfig.SuppressMode.SuppressOnlyInMenu when Context.IsWorldReady && Game1.activeClickableMenu != null:
                        case ModConfig.SuppressMode.SuppressOnlyWhenPlayerFree when Context.IsPlayerFree:
                        case ModConfig.SuppressMode.SuppressOnlyWhenPlayerCanMove when Context.CanPlayerMove:
                        case ModConfig.SuppressMode.Suppress:
                            this.Helper.Input.SuppressActiveKeybinds(KeybindList.ForSingle(keyValue.Key));
                            break;
                    }
                }
            }
        }
    }
}