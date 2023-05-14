using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Anthem.Items.Buff
{
    public class Paper_Buff : ModBuff
    {
		public override void SetStaticDefaults() {
			// DisplayName and Description are automatically set from the .lang files, but below is how it is done normally.
			// DisplayName.SetDefault("Paper Airplane");
			// Description.SetDefault("\"Let this pet be an example to you!\"");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<ExamplePlayer>().examplePet = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Paper_Airplane>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer) {
                int proj = Projectile.NewProjectile(Projectile.GetSource_TownSpawn(), player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Paper_Airplane>(), 0, (int)0f, player.whoAmI, (int)0f, 0f);
			}
		}
    }
}