using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;
using PrimitierModdingFramework;
using System.Reflection;
using UnhollowerRuntimeLib;

namespace Seva167.ThrusterMod.Utils
{
    static class AssetsManager
    {
        public static AudioClip ThrusterSnd { get; private set; }
        public static Texture2D ThrusterTex { get; private set; }
        public static Mesh ThrusterMesh { get; private set; }

        const string resourcesPath = "Seva167.ThrusterMod.Assets.resources.bundle";

        const string thrusterSndName = "rocket_engine.wav";
        const string thrusterTexName = "thruster.png";
        const string thrusterMeshName = "UVMappedCube.mesh";

        public static void LoadAllAssets()
        {
            byte[] resourcesBytes = CustomAssetSystem.LoadEmbeddedResource(Assembly.GetExecutingAssembly(), resourcesPath);
            AssetBundle resourcesBundle = AssetBundle.LoadFromMemory(resourcesBytes);

            ThrusterSnd = resourcesBundle.LoadAsset(thrusterSndName, Il2CppType.Of<AudioClip>()).Cast<AudioClip>();
            ThrusterTex = resourcesBundle.LoadAsset(thrusterTexName, Il2CppType.Of<Texture2D>()).Cast<Texture2D>();
            ThrusterMesh = resourcesBundle.LoadAsset(thrusterMeshName, Il2CppType.Of<Mesh>()).Cast<Mesh>();

            resourcesBundle.Unload(false);
        }
    }
}
