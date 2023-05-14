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
            DisplayName.SetDefault("DiamondsAreForever"); // The displayed name of the item
            Tooltip.SetDefault("Halves damage output /n Diamonds are forever Throw your diamonds in the sky if you feel the vibe Diamonds are forever The Roc is still alive every time I rhyme Forever ever? Forever ever? Ever, ever? Ever, ever? Ever, ever? Ever, ever? Ever, ever? Ever, ever?"); // The tooltip displayed when hovering over the item
        }



        public override Vector2? HoldoutOffset()
        {
            return base.HoldoutOffset();
        }

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Diamond, 5) // AddIngredient takes ItemID, then Quantity
				.AddTile(TileID.Anvils) // AddTile takes the TileID
				.Register(); // Register registers the item
		}

        public override void SetDefaults() 
		{
		Item.width = 20;
		Item.height = 20;
		Item.value = Item.buyPrice(0, 10, 0, 0);
		Item.rare = ItemRarityID.Cyan;
		Item.accessory = true;
		Item.defense = 20; // give 20% damage reduction
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
        {
		player.GetDamage(DamageClass.Generic) *= 0.5f; //divide dmg by 50%

		}

		public override Color? GetAlpha(Color lightColor) {
			return Color.White;
		}


	// We need to do the same for the AnkhShield so our restriction is enforced both ways.

	}
}

