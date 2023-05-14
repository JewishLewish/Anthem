using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;

namespace Anthem.Items.Accessory
{
    [AutoloadEquip(EquipType.Shield)]
    internal class balls : ModItem
    {
        public override void SetStaticDefaults()
        {
            
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            DisplayName.SetDefault("ball"); // The displayed name of the item
            Tooltip.SetDefault("Ur balls are strong!"); // The tooltip displayed when hovering over the item
        }



        public override Vector2? HoldoutOffset()
        {
            return base.HoldoutOffset();
        }

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Gel, 1) // AddIngredient takes ItemID, then Quantity
				.AddTile(TileID.WorkBenches) // AddTile takes the TileID
				.Register(); // Register registers the item
		}

        		public override void SetDefaults() {
			Item.width = 20;
			Item.height = 20;
			Item.value = Item.buyPrice(0, 10, 0, 0);
			Item.rare = ItemRarityID.Cyan;
			Item.expert = true;
			Item.accessory = true;
			Item.damage = 120;
			Item.knockBack = 2f;
			Item.defense = 6;
		}


		public override Color? GetAlpha(Color lightColor) {
			return Color.White;
		}


	// We need to do the same for the AnkhShield so our restriction is enforced both ways.

	}
}

