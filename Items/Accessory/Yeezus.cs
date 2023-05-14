using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace Anthem.Items.Accessory
{
    //[AutoloadEquip(EquipType.Shoes)]
    internal class Yeezus : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            DisplayName.SetDefault("Yeezus"); // The displayed name of the item
            Tooltip.SetDefault("150% Faster Movespeed\n500% Damage Increase"); // The tooltip displayed when hovering over the item
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
            player.moveSpeed *= 1.5f; // %150 Increase in Speed
            player.GetDamage(DamageClass.Generic) *= 5f; // %500 Increase in Damage
        }

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Gel, 1) // AddIngredient takes ItemID, then Quantity
				.AddTile(TileID.WorkBenches) // AddTile takes the TileID
				.Register(); // Register registers the item
		}
    }
}