﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using PrimitierModdingFramework.SubstanceModding;
using PrimitierModdingFramework;
using Seva167.ThrusterMod.Utils;
using UnityEngine.Animations;

namespace Seva167.ThrusterMod
{
    public class ThrusterBehavior : MonoBehaviour, ICustomCubeBehaviour
    {
        public ThrusterBehavior(IntPtr ptr) : base(ptr) { }

        private CubeBase cubeBase;
        private AudioSource audioSource;

        private GameObject vectorPoint;

        private void Start()
        {
            cubeBase = GetComponent<CubeBase>();

            cubeBase.cubeAppearance.meshFilter.mesh = AssetsManager.ThrusterMesh;

            audioSource = gameObject.AddComponent<AudioSource>();

            audioSource.spatialBlend = 1;
            audioSource.clip = AssetsManager.ThrusterSnd;
            audioSource.loop = true;
            audioSource.pitch = 0;
            audioSource.Play();

            vectorPoint = new GameObject("ThrusterVector");
            vectorPoint.transform.position = cubeBase.transform.position;

            ParentConstraint vectorConstraint = vectorPoint.AddComponent<ParentConstraint>();
            ConstraintSource constrSource = new ConstraintSource()
            { 
                sourceTransform = cubeBase.transform,
                weight = 1
            };
            vectorConstraint.AddSource(constrSource);
            vectorConstraint.constraintActive = true;
        }

        public float Power { get; set; } = 1;

        private void FixedUpdate()
        {
            float tempC = cubeBase.heat.GetCelsiusTemperature();

            if (tempC >= 150)
            {
                Vector3 force = -vectorPoint.transform.up * tempC * Power;
                cubeBase.rb.AddForceAtPosition(force, vectorPoint.transform.position);
                audioSource.pitch = tempC / 600;
            }
            else
                audioSource.pitch = 0;
        }

        public void OnCollideWithCube(CubeBase colCubeBase) { }

        public void OnFragmentInitialized(CubeBase fragmentCubeBase) { }
    }
}
