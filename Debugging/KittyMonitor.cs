#pragma warning disable CS0109
using System;
using BepInEx;
using BepInEx.Logging;
using UnityEngine;

namespace Kitty.Debugging
{
    [BepInPlugin("kitty.monitor", "Kitty Monitor", "0.0.1")]
    internal class KittyMonitor : BaseUnityPlugin
    {
        static new ManualLogSource loggingSource;

        public enum LogLevel
        {
            Info,
            Warning,
            Error
        }

        public void Awake()
        {
            loggingSource = base.Logger;
            loggingSource.LogInfo("[Kitty Monitor] Initialized!");
        }

        public static void Monitor(string str, LogLevel lvl)
        {
            // If you're browsing through my code, and want this, go ahead. Only took like 5 minutes to make
            // Credit me or something, im not gonna get on your ass if you dont though as its just a debugger
            string final = $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] {lvl.ToString().ToUpper()} - {str}";
            switch (lvl)
            {
                case LogLevel.Info:
                    loggingSource.LogInfo($"{final}");
                    break;
                case LogLevel.Warning:
                    loggingSource.LogWarning($"{final}");
                    break;
                case LogLevel.Error:
                    loggingSource.LogError($"{final}");
                    break;
            }
        }
    }
}
