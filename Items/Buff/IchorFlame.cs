using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Anthem.Items.Buff
{
    public class IchorFlame : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ichor Infested");
            Description.SetDefault("Grants the Ichor buff to weapons /n This is going to hurt...");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.HasBuff(BuffID.WeaponImbueIchor); //Grants Ichor buff

            //TODO
        }
    }
}