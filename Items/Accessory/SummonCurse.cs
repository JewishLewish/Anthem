using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace Anthem.Items.Accessory
{
    //[AutoloadEquip(EquipType.Shoes)]
    internal class SummonCurse : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            DisplayName.SetDefault("Summon Curse"); // The displayed name of the item
            Tooltip.SetDefault("10x More Summons, 1/10 Summon Damage Decrease"); // The tooltip displayed when hovering over the item
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            Item.defense = 5;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.maxMinions *= (int)10f; // Increase maximum number of minions by 10x
            player.GetModPlayer<Summonerplayer>().summonDamageMultiplier /= 10f; // Decrease summon damage by 1/10
        }

        private bool IsMinionProjectile(Projectile projectile)
        {
            return projectile.minion && !projectile.sentry;
        }

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Gel, 1) // AddIngredient takes ItemID, then Quantity
				.AddTile(TileID.WorkBenches) // AddTile takes the TileID
				.Register(); // Register registers the item
		}
    }

        public class Summonerplayer : ModPlayer
    {
        public float summonDamageMultiplier = 1f;

        public override void ResetEffects()
        {
            summonDamageMultiplier = 1f;
        }

        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            damage = (int)(damage * summonDamageMultiplier);
        }

        public override void ModifyHitPvp(Item item, Player target, ref int damage, ref bool crit)
        {
            damage = (int)(damage * summonDamageMultiplier);
        }

        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            damage = (int)(damage * summonDamageMultiplier);
        }

        public override void ModifyHitPvpWithProj(Projectile proj, Player target, ref int damage, ref bool crit)
        {
            damage = (int)(damage * summonDamageMultiplier);
        }
    }
}