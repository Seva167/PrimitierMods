using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace Seva167.CoalMod.Patches
{
    [HarmonyPatch(typeof(CubeGenerator.__c), nameof(CubeGenerator.__c._SetUpGenerateActions_b__26_0))]
    static class WorldGenPatch
    {
        static void Prefix(Vector3 tileCenter)
        {
            CoalGenerator.Generate(tileCenter);
        }
    }
}
