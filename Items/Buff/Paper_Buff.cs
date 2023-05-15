using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Anthem.Items.Buff
{
    public class Paper_Buff : ModBuff
    {
		public override void SetStaticDefaults() {
			// DisplayName and Description are automatically set from the .lang files, but below is how it is done normally.
			DisplayName.SetDefault("Paper Airplane");
			Description.SetDefault("\"Let this pet be an example to you!\"");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<ExamplePlayer>().examplePet = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Paper_Airplane>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer) {
                Dust.NewDust(player.Center, (int)0f, (int)0f, ModContent.ProjectileType<Projectiles.Paper_Airplane>(), 0, (int)0f, player.whoAmI, default(Color), 1f);
			}
		}
    }
}