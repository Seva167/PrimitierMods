using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimitierModdingFramework.SubstanceModding;
using static Seva167.ThrusterMod.Builders.ThrusterMaterialBuilder;

namespace Seva167.ThrusterMod.Builders
{
    public class MediumThrusterBuilder : CustomSubstanceBuilder
    {
        public override void OnBuild()
        {
            var thrusterSubstance = CustomSubstanceSystem.CreateCustomSubstance(Substance.AncientEngine);
            thrusterSubstance.displayNameKey = "SUB_MEDIUM_ANCIENT_THRUSTER";
            thrusterSubstance.material = ThrusterMat.name;
            thrusterSubstance.sectionMaterialV = ThrusterMat.name;
            thrusterSubstance.sectionMaterialH = ThrusterMat.name;
            thrusterSubstance.strength = float.PositiveInfinity;
            thrusterSubstance.density /= 1.5f;
            thrusterSubstance.thermalConductivity *= 2;

            CustomSubstanceSystem.LoadCustomSubstance(thrusterSubstance, new CustomSubstanceSettings()
            { 
                EnName = "Medium Ancient Thruster",
                JpName = "ミディアムエンシェントスラスター",
                /*OnSubstanceInitialize = (CubeBase target) => 
                {
                    ThrusterBehavior thrusterBeh = target.gameObject.AddComponent<ThrusterBehavior>();
                    thrusterBeh.Power = 4f;
                }*/
                AddCustomCubeBehaviour = (CubeBase target) =>
                {
                    ThrusterBehavior thrusterBeh = target.gameObject.AddComponent<ThrusterBehavior>();
                    thrusterBeh.Power = 4f;
                    return thrusterBeh;
                }

            });

        }
    }
}
