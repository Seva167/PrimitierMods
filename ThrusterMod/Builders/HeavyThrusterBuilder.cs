using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimitierModdingFramework.SubstanceModding;
using static Seva167.ThrusterMod.Builders.ThrusterMaterialBuilder;

namespace Seva167.ThrusterMod.Builders
{
    public class HeavyThrusterBuilder : CustomSubstanceBuilder
    {
        public override void OnBuild()
        {
            var thrusterSubstance = CustomSubstanceSystem.CreateCustomSubstance(Substance.AncientEngine);
            thrusterSubstance.displayNameKey = "SUB_HEAVY_ANCIENT_THRUSTER";
            thrusterSubstance.material = ThrusterMat.name;
            thrusterSubstance.sectionMaterialV = ThrusterMat.name;
            thrusterSubstance.sectionMaterialH = ThrusterMat.name;
            thrusterSubstance.strength = float.PositiveInfinity;
            thrusterSubstance.density /= 2;
            thrusterSubstance.thermalConductivity *= 5;

            CustomSubstanceSystem.LoadCustomSubstance(thrusterSubstance, new CustomSubstanceSettings()
            { 
                EnName = "Heavy Ancient Thruster",
                JpName = "ヘビーエンシェントスラスター",
                /*OnSubstanceInitialize = (CubeBase target) => 
                {
                    ThrusterBehavior thrusterBeh = target.gameObject.AddComponent<ThrusterBehavior>();
                    thrusterBeh.Power = 30f;
                }*/
                AddCustomCubeBehaviour = (CubeBase target) =>
                {
                    ThrusterBehavior thrusterBeh = target.gameObject.AddComponent<ThrusterBehavior>();
                    thrusterBeh.Power = 30f;
                    return thrusterBeh;
                }

            });

        }
    }
}
