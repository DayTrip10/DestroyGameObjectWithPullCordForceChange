﻿using System;
using UnityEngine;
using SLZ.Props;
using MelonLoader;

namespace bonelab_template
{
    public class DestroyGameObjectWithPullCordForceChange : MelonMod
    {
        private float checkInterval = 5.0f; // Check every 5 seconds
        private float nextCheckTime = 0.0f;

        public override void OnApplicationStart()
        {
            MelonLogger.Msg("DestroyGameObjectWithPullCordForceChange mod loaded");
        }

        public override void OnUpdate()
        {
            if (Time.time >= nextCheckTime)
            {
                nextCheckTime = Time.time + checkInterval;
                PullCordForceChange[] pullCordForceChanges = GameObject.FindObjectsOfType<PullCordForceChange>();
                foreach (PullCordForceChange pullCordForceChange in pullCordForceChanges)
                {
                    string objectName = pullCordForceChange.gameObject.name;
                    GameObject.Destroy(pullCordForceChange.gameObject);
                    MelonLogger.Msg($"Found and destroyed GameObject: {objectName}");
                }
            }
        }
    }
}