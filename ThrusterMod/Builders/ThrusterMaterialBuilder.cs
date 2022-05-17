using PrimitierModdingFramework.SubstanceModding;
using Seva167.ThrusterMod.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Seva167.ThrusterMod.Builders
{
    static class ThrusterMaterialBuilder
    {
        public static Material ThrusterMat { get; private set; }

        public static void BuildMaterial()
        {
            Material thrusterMat = CustomSubstanceSystem.CreateCustomMaterial("AncientAlloy");

            thrusterMat.name = "ThrusterMaterial";
            thrusterMat.color = Color.white;
            thrusterMat.mainTexture = AssetsManager.ThrusterTex;

            CustomSubstanceSystem.LoadCustomMaterial(thrusterMat);
            ThrusterMat = thrusterMat;
        }
    }
}
