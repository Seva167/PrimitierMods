using Il2CppSystem;
using PrimitierModdingFramework;
using PrimitierModdingFramework.Debugging;
using PrimitierModdingFramework.SubstanceModding;
using Il2CppSystem.IO;
using System.Text;
using UnityEngine;
using UnhollowerBaseLib;
using UnhollowerRuntimeLib;
using Valve.VR;
using UnityEngine.XR;

namespace Seva167.ThrusterMod
{

	public class Mod : PrimitierMod
    {

		public override void OnSceneWasLoaded(int buildIndex, string sceneName)
		{
			base.OnSceneWasLoaded(buildIndex, sceneName);

			var thrusterMenu = InGameDebugTool.CreateMenu("Thruster Mod", "MainMenu");

			var smallThrusterBtn = thrusterMenu.CreateButton("Spawn small thruster", new System.Action(() =>
			{
				CubeGenerator.GenerateCube(thrusterMenu.transform.position, new Vector3(0.2f, 0.4f, 0.2f), CustomSubstanceSystem.GetSubstanceByName("SUB_SMALL_ANCIENT_THRUSTER"));
			}));
			var mediumThrusterBtn = thrusterMenu.CreateButton("Spawn medium thruster", new System.Action(() =>
			{
				CubeGenerator.GenerateCube(thrusterMenu.transform.position, new Vector3(0.4f, 0.8f, 0.4f), CustomSubstanceSystem.GetSubstanceByName("SUB_MEDIUM_ANCIENT_THRUSTER"));
			}));
			var heavyThrusterBtn = thrusterMenu.CreateButton("Spawn heavy thruster", new System.Action(() =>
			{
				CubeGenerator.GenerateCube(thrusterMenu.transform.position, new Vector3(0.6f, 2.4f, 0.6f), CustomSubstanceSystem.GetSubstanceByName("SUB_HEAVY_ANCIENT_THRUSTER"));
			}));
		}

		public override void OnApplicationStart()
		{
			base.OnApplicationStart();

			PMFSystem.EnableSystem<CustomAssetSystem>();
			PMFSystem.EnableSystem<PMFHelper>();
			PMFSystem.EnableSystem<InGameDebuggingSystem>();
			PMFSystem.EnableSystem<CustomSubstanceSystem>();
			PMFSystem.EnableSystem<CustomAssetSystem>();

			Utils.AssetsManager.LoadAllAssets();

			Builders.ThrusterMaterialBuilder.BuildMaterial();

			PMFHelper.AutoInject(System.Reflection.Assembly.GetExecutingAssembly());
		}
	}
}
