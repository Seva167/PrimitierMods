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

	public class ThrusterMod : PrimitierMod
    {

		public override void OnSceneWasLoaded(int buildIndex, string sceneName)
		{
			base.OnSceneWasLoaded(buildIndex, sceneName);

			var thrusterMenu = InGameDebugTool.CreateMenu("Thruster Mod", "MainMenu");
			var thrusterBtn = thrusterMenu.CreateButton("Spawn thruster", new System.Action(() =>
			{
				CubeGenerator.GenerateCube(thrusterMenu.transform.position, new Vector3(0.2f, 0.4f, 0.2f), CustomSubstanceSystem.GetSubstanceByName("SUB_ANCIENT_THRUSTER"));
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

			PMFHelper.AutoInject(System.Reflection.Assembly.GetExecutingAssembly());

			Utils.AssetsManager.LoadAllAssets();
		}
	}
}
