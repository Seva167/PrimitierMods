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

namespace Seva167.CoalMod
{

	public class Mod : PrimitierMod
    {

		public override void OnSceneWasLoaded(int buildIndex, string sceneName)
		{
			
			base.OnSceneWasLoaded(buildIndex, sceneName);
			PMFLog.Message($"Scene: {buildIndex}");

			var coalMenu = InGameDebugTool.CreateMenu("Coal Mod", "MainMenu");
			var coalBtn = coalMenu.CreateButton("Spawn coal", new System.Action(() =>
			{
				CubeGenerator.GenerateCube(coalMenu.transform.position, Vector3.one * 0.2f, CustomSubstanceSystem.GetSubstanceByName("SUB_COAL"));
			}));

			/*
			var testBtn = coalMenu.CreateButton("Test", new System.Action(() =>
			{
			Action<Vector3> coalGenerateAction = CubeGenerator.generateActions[CubeGenerator.Obj.Stone];
			coalGenerateAction = new System.Action<Vector3>((pos) =>
			{
				CoalGenerator.Generate(pos);
			});

			}));*/

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
		}

	}
}
