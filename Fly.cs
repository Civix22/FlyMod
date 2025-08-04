using System;
using BepInEx;
using HarmonyLib;
using System.Collections.Generic;
using Utilla;
using UnityEngine;
using UnityEngine.Assertions.Must;
using GorillaLocomotion;
using GorillaExtensions;




namespace Fly
{
    [BepInPlugin("com.gorillatag.Flymod.civix", "Flymod", "1.0.0")]
    class Flymod : BaseUnityPlugin
    {
        bool inRoom => NetworkSystem.Instance.InRoom && NetworkSystem.Instance.GameModeString.Contains("MODDED");
        void Update()
        {
            if (inRoom)
            {
                if (ControllerInputPoller.instance.rightControllerPrimaryButton)
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.position += (GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward) * Time.deltaTime * 15;
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }

                else
                {
                    if (ControllerInputPoller.instance.leftControllerPrimaryButton)
                    {
                        GorillaLocomotion.GTPlayer.Instance.transform.position -= (GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward) * Time.deltaTime * 15;
                        GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    }

                    else
                    {
                        Rigidbody rb = GTPlayer.Instance.GetComponent<Rigidbody>();
                        rb.velocity = Vector3.zero;
                        rb.AddForce(-Physics.gravity * rb.mass * GTPlayer.Instance.scale);
                    }

                }

            }
        }
    }
}
