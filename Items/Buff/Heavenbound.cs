using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Anthem.Items.Buff
{
    public class Heavenbound : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heavenbound");
            Description.SetDefault("Jessie blesses you. 20% more movement speed, melee and defense");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed += 0.2f; // 20% increased movement speed
            player.GetAttackSpeed(DamageClass.Generic) += 0.2f; // 20% increased melee speed
            player.statDefense += (int)(player.statDefense * 0.2f); // 20% increased defense
        }
    }
}