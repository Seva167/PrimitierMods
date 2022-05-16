using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using PrimitierModdingFramework;
using UnityEngine;

namespace Seva167.CoalMod.Patches
{
    [HarmonyPatch(typeof(CubeGenerator), "GenerateSlime", new Type[] { typeof(Vector3), typeof(float) })]
    public static class TestPatch
    {
        static void Prefix()
        {
            PMFLog.Message("Slime Generated");
        }
    }
}
