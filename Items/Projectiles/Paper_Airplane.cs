using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace Anthem.Items.Projectiles
{

	public class Paper_Airplane : ModProjectile
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Paper Airplane"); // Automatic from .lang files
			Main.projFrames[Projectile.type] = 4;
			Main.projPet[Projectile.type] = true;
		}

		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.ZephyrFish);
			AIType = ProjectileID.ZephyrFish;
		}

		public override bool PreAI() {
			Player player = Main.player[Projectile.owner];
			player.zephyrfish = false; // Relic from aiType
			return true;
		}

		public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            ExamplePlayer modPlayer = GetModPlayer(player);
            if (player.dead)
            {
                modPlayer.examplePet = false;
            }
            if (modPlayer.examplePet)
            {
                Projectile.timeLeft = 2;
            }
        }

        private static ExamplePlayer GetModPlayer(Player player)
        {
            return player.GetModPlayer<ExamplePlayer>();
        }
    }
}