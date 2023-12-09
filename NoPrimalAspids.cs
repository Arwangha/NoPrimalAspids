using Modding;
using UnityEngine;

namespace NoPrimalAspids
{
    public class NoPrimalAspids : Mod, ITogglableMod
    {
        public new string GetName() => "No Primal Aspids";
        public override string GetVersion() => "1.0.0";

        public override void Initialize()
        {
            ModHooks.OnEnableEnemyHook += Instance_OnEnableEnemyHook;
        }

        private bool Instance_OnEnableEnemyHook(GameObject enemy, bool isAlreadyDead)
        {
            if (enemy.name.Contains("Super Spitter"))
            {
                UnityEngine.Object.Destroy(enemy);
                Log("Removing hell spawn");
            }

            return isAlreadyDead;
        }

        public void Unload()
        {
            ModHooks.OnEnableEnemyHook -= Instance_OnEnableEnemyHook;
        }
    }
}