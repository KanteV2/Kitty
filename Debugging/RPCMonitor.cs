using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;

namespace Kitty.Debugging
{
    [HarmonyPatch(typeof(NetworkView), "SendRPC")]
    internal class RPCMonitor
    {
        [HarmonyPrefix] 
        static bool Prefix(string method, RpcTarget target, params object[] parameters)
        {
            KittyMonitor.Monitor($"An RPC has been called! \n METHOD: {method} \n TARGET {target.ToString()} \n PARAMS: {parameters.ToString()}", KittyMonitor.LogLevel.Info);
            return true;
        }
    }
}
