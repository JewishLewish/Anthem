using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Anthem
{
    public class YourModPlayer : ModPlayer
    {
        public bool reflectDamage;
        public bool flamingAmulet;

        public bool HeavenGem;

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
                target.AddBuff(BuffID.BetsysCurse, 180);
                target.AddBuff(BuffID.Frostburn, 180);
            }

            if (HeavenGem) {
                Player player = Main.player[proj.owner];
                int healAmount = damage / 10; // 1/10th of damage dealt as healing
                player.statLife += healAmount;
                player.HealEffect(healAmount);
            }
		}

        public override void OnRespawn(Player player)
        {
            if (HeavenGem)
            {
            for (int i = 0; i < Main.player.Length; i++)
            {
                Player playe = Main.player[i];
                if (playe.active && !playe.dead)
                {
                    playe.AddBuff(ModContent.BuffType<Items.Buff.Heavenbound>(), 2);
                }
            }
            }
        }

        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource) {
            if (flamingAmulet) {
                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    if (Main.npc[i].active && !Main.npc[i].townNPC && !Main.npc[i].friendly)
                    {
                        Main.npc[i].AddBuff(BuffID.OnFire, 180); // Apply 'On Fire!' debuff for 3 seconds (60 frames per second)
                        Main.npc[i].AddBuff(BuffID.Venom, 180); // Apply 'On Fire!' debuff for 3 seconds (60 frames per second)
                        Main.npc[i].AddBuff(BuffID.Ichor, 180); // Apply 'On Fire!' debuff for 3 seconds (60 frames per second)
                        Main.npc[i].AddBuff(BuffID.BetsysCurse, 180); // Apply 'On Fire!' debuff for 3 seconds (60 frames per second)
                        Main.npc[i].AddBuff(BuffID.Frostburn, 180); // Apply 'On Fire!' debuff for 3 seconds (60 frames per second)
                        
                    }
                }
            }
            return true;
        }
    }
}