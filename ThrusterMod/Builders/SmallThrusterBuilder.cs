using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimitierModdingFramework.SubstanceModding;
using static Seva167.ThrusterMod.Builders.ThrusterMaterialBuilder;

namespace Seva167.ThrusterMod.Builders
{
    public class SmallThrusterBuilder : CustomSubstanceBuilder
    {
        public override void OnBuild()
        {
            var thrusterSubstance = CustomSubstanceSystem.CreateCustomSubstance(Substance.AncientEngine);
            thrusterSubstance.displayNameKey = "SUB_SMALL_ANCIENT_THRUSTER";
            thrusterSubstance.material = ThrusterMat.name;
            thrusterSubstance.sectionMaterialV = ThrusterMat.name;
            thrusterSubstance.sectionMaterialH = ThrusterMat.name;
            thrusterSubstance.strength = float.PositiveInfinity;
            thrusterSubstance.density -= 1;

            CustomSubstanceSystem.LoadCustomSubstance(thrusterSubstance, new CustomSubstanceSettings()
            { 
                EnName = "Small Ancient Thruster",
                JpName = "小さな古代スラスター",
                OnSubstanceInitialize = (CubeBase target) => 
                {
                    ThrusterBehavior thrusterBeh = target.gameObject.AddComponent<ThrusterBehavior>();
                    thrusterBeh.Power = 0.7f;
                }

            });

        }
    }
}
