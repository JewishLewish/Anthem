using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Anthem
{
    public class YourModPlayer : ModPlayer
    {
        public bool reflectDamage;
        public bool flamingAmulet;

        public override void ResetEffects()
        {
            reflectDamage = false;
            flamingAmulet = false;
        }

        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            if (reflectDamage)
            {
                npc.StrikeNPC(damage / 10, 0f, 0, false, false, false);
            }
        }

		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)	 {
            if (flamingAmulet)
            {
                target.AddBuff(BuffID.OnFire, 180);
                target.AddBuff(BuffID.Venom, 180);
                target.AddBuff(BuffID.Ichor, 180);
            }
		}
    }
}