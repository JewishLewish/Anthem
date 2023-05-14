using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;

namespace Anthem.Items.Accessory
{
    //[AutoloadEquip(EquipType.Neck)]
    internal class Ichor_Bracelet : ModItem
    {
        public override void SetStaticDefaults()
        {
            
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            DisplayName.SetDefault("Ichor Bracelet"); // The displayed name of the item
            Tooltip.SetDefault("Gives Ichor damage to any weapon /n Inflicts the Cursed debuff on you periodically"); // The tooltip displayed when hovering over the item
        }



        public override Vector2? HoldoutOffset()
        {
            return base.HoldoutOffset();
        }

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.ClayBlock, 20) // AddIngredient takes ItemID, then Quantity
				.AddIngredient(ItemID.Topaz, 5)
				.AddTile(TileID.Chairs) // AddTile takes the TileID
				.Register(); // Register registers the item
		}

        public override void SetDefaults() 
		{
		Item.width = 20;
		Item.height = 20;
		Item.value = Item.buyPrice(0, 10, 0, 0);
		Item.rare = ItemRarityID.Orange;
		Item.accessory = true;
		}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            base.OnHitNPC(player, target, damage, knockBack, crit);
            // Inflict the OnFire debuff for 1 second onto any NPC/Monster that this hits.
            // 60 frames = 1 second
            target.AddBuff(BuffID.OnFire, 60);
        }


		public override void UpdateAccessory(Player player, bool hideVisual)
        {

		

		}




		public override Color? GetAlpha(Color lightColor) {
			return Color.White;
		}


	

	}
}

