using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimitierModdingFramework.SubstanceModding;
using PrimitierModdingFramework;
using UnityEngine;
using System.Reflection;

namespace Seva167.CoalMod
{
    public class CoalBuilder : CustomSubstanceBuilder
    {

        public override void OnBuild()
        {
            Material coalMat = CustomSubstanceSystem.CreateCustomMaterial("Wood");
            coalMat.name = "CoalMaterial";
            coalMat.color = Color.white;
            coalMat.mainTexture = LoadTexture();
            coalMat.mainTextureScale = Vector2.one * 10;
            CustomSubstanceSystem.LoadCustomMaterial(coalMat);

            var coalSubstance = CustomSubstanceSystem.CreateCustomSubstance(Substance.Wood);

            coalSubstance.displayNameKey = "SUB_COAL";
            coalSubstance.collisionSound = "stone1";
            coalSubstance.material = coalMat.name;
            coalSubstance.sectionMaterialH = coalMat.name;
            coalSubstance.sectionMaterialV = coalMat.name;
            coalSubstance.density += 0.05f;
            coalSubstance.combustionHeat *= 5;
            coalSubstance.combustionSpeed *= 0.45f;

            CustomSubstanceSystem.LoadCustomSubstance(coalSubstance, new CustomSubstanceSettings 
            { 
                EnName = "Coal",
                JpName = "石炭"
            });
        }

        Texture2D LoadTexture()
        {
            Texture2D coalTexture = new Texture2D(1, 1);
            coalTexture.filterMode = FilterMode.Point;
            CustomAssetSystem.LoadImageFromEmbeddedResource(Assembly.GetExecutingAssembly(), "CoalMod.Assets.Textures.CoalTexture.png", ref coalTexture);
            return coalTexture;
        }
    }
}
