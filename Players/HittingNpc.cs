using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;

namespace Anthem.Players
{
	public class HittingNpc : ModPlayer
	{
        public override void SetStaticDefaults() 
		{
			public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
			{
			base.OnHitNPC(player, target, damage, knockBack, crit);
            // Inflict the OnFire debuff for 1 second onto any NPC/Monster that this hits.
            // 60 frames = 1 second
            target.AddBuff(BuffID.OnFire, 60);
				
			}


		}

	}
}
