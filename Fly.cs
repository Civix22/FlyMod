using BepInEx;
using UnityEngine;

namespace Fly
{
    [BepInPlugin("com.gorillatag.Fly.civix", "Fly", "1.0.1")]
    class FlyMod : BaseUnityPlugin
    {
        void Update()
        {
            if (NetworkSystem.Instance.InRoom && NetworkSystem.Instance.GameModeString.Contains("MODDED"))
            {
                if (ControllerInputPoller.instance.rightControllerPrimaryButton) // a
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * Time.deltaTime * 15;
                    GorillaTagger.Instance.rigidbody.velocity = Vector3.zero;
                }

                if (ControllerInputPoller.instance.leftControllerPrimaryButton) // x
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.position -= GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * Time.deltaTime * 15;
                    GorillaTagger.Instance.rigidbody.velocity = Vector3.zero;
                }

                if (ControllerInputPoller.instance.leftControllerSecondaryButton) // y
                    GorillaTagger.Instance.rigidbody.velocity = Vector3.zero;
            }
        }
    }
}
