using BepInEx;
using System;
using GorillaLocomotion;
using UnityEngine;
using System.ComponentModel;
using BepInEx.Configuration;
using Utilla;
using System.Collections.Generic;
using UnityEngine.XR;
using System;
using System.Collections.Generic;
using BepInEx.Configuration;
using ExitGames.Client.Photon;
using GorillaLocomotion;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.XR;
using System.Threading;

namespace RandomTag
{
    /// <summary>
    /// This is your mod's main class.
    /// </summary>

    /* This attribute tells Utilla to look for [ModdedGameJoin] and [ModdedGameLeave] */
    [Description("HauntedModMenu")]
    [BepInPlugin("gorillatag.randomTag", "random tag", "1.0.0")]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [ModdedGamemode]
    public class Plugin : BaseUnityPlugin
    {
        float scale = 1f;
        bool triggerpress;
        bool resetbutton;
        bool triggerpress2;
        bool on = false;

        void Start()
        {
            Events.GameInitialized += this.OnGameInitialized;
        }

        void OnEnable()
        {
            this.on = true;
            HarmonyPatches.ApplyHarmonyPatches();
        }

        void OnDisable()
        {
            this.on = false;
            HarmonyPatches.RemoveHarmonyPatches();
        }

        private void newrandom(object o)
        {
            System.Random random = new System.Random();
            this.seconds = random.Next(1000, 3930000);
        }

        public int seconds2 = 200;

        public int seconds;

        void OnGameInitialized(object sender, EventArgs e)
        {
            this.newrandom(null);
            new Timer(new TimerCallback(this.newrandom), null, 0, this.seconds2);
            new Timer(new TimerCallback(this.Update), null, 0, this.seconds);
        }

        void Update(object o)
        {
            if (on)
            {
                System.Random rnd = new System.Random();
                System.Threading.Thread.Sleep(rnd.Next(9500, 30000));
                foreach (GorillaTagManager gorillaTagManager in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
                {
                    gorillaTagManager.currentInfected.Add(PhotonNetwork.LocalPlayer);
                    gorillaTagManager.currentInfected.Add(PhotonNetwork.LocalPlayer);
                    gorillaTagManager.currentInfected.Add(PhotonNetwork.LocalPlayer);
                    gorillaTagManager.AddInfectedPlayer(PhotonNetwork.LocalPlayer);
                    gorillaTagManager.AddInfectedPlayer(PhotonNetwork.LocalPlayer);
                    gorillaTagManager.AddInfectedPlayer(PhotonNetwork.LocalPlayer);
                }
            }
        }

        /* This attribute tells Utilla to call this method when a modded room is joined */
        [ModdedGamemodeJoin]
        public void OnJoin(string gamemode)
        {
            on = true;
        }

        /* This attribute tells Utilla to call this method when a modded room is left */
        [ModdedGamemodeLeave]
        public void OnLeave(string gamemode)
        {
            on = false;
        }
    }
}
