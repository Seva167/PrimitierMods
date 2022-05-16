using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimitierModdingFramework.SubstanceModding;
using UnityEngine;
using Seva167.ThrusterMod.Utils;

namespace Seva167.ThrusterMod
{
    public class ThrusterBuilder : CustomSubstanceBuilder
    {
        public override void OnBuild()
        {
            Material thrusterMat = CustomSubstanceSystem.CreateCustomMaterial("AncientAlloy");

            thrusterMat.name = "ThrusterMaterial";
            thrusterMat.color = Color.white;
            thrusterMat.mainTexture = AssetsManager.ThrusterTex;

            CustomSubstanceSystem.LoadCustomMaterial(thrusterMat);

            var thrusterSubstance = CustomSubstanceSystem.CreateCustomSubstance(Substance.AncientEngine);
            thrusterSubstance.displayNameKey = "SUB_ANCIENT_THRUSTER";
            thrusterSubstance.material = thrusterMat.name;
            thrusterSubstance.sectionMaterialV = thrusterMat.name;
            thrusterSubstance.sectionMaterialH = thrusterMat.name;
            thrusterSubstance.strength = float.PositiveInfinity;

            CustomSubstanceSystem.LoadCustomSubstance(thrusterSubstance, new CustomSubstanceSettings()
            { 
                EnName = "Ancient Thruster",
                JpName = "古代のスラスター",
                OnSubstanceInitialize = (CubeBase target) => 
                {
                    target.gameObject.AddComponent<ThrusterBehavior>();
                }

            });

        }
    }
}
