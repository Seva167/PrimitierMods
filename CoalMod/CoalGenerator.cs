using PrimitierModdingFramework.SubstanceModding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Seva167.CoalMod
{
    public static class CoalGenerator
    {
        public static void Generate(Vector3 pos)
        {
            PrimitierModdingFramework.PMFLog.Message($"Coal: {pos}");
            CubeGenerator.GenerateCube(pos, Vector3.one * 0.2f, CustomSubstanceSystem.GetSubstanceByName("SUB_COAL"));
        }
    }
}
