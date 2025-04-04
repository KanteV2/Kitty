using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using BepInEx;
using BepInEx.Harmony;
using HarmonyLib;
using Kitty.Debugging;

namespace Kitty.Patching
{
    [BepInPlugin("kitty.panel", "Kitty Cheat Panel", "0.0.1")]
    internal class Plugin : BaseUnityPlugin
    {
        void Start()
        {
            new Harmony("kitty").PatchAll(Assembly.GetExecutingAssembly());
            KittyMonitor.Monitor("Kitty has been loaded.", KittyMonitor.LogLevel.Info);
        }
    }
}
