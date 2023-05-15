using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace Anthem.Items.Accessory
{
    //[AutoloadEquip(EquipType.Shoes)]
    internal class HeartBurner : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            DisplayName.SetDefault("HeartBurner"); // The displayed name of the item
            Tooltip.SetDefault("Takes 50% of your Max HP\nReturns 25% of your current HP in Defense"); // The tooltip displayed when hovering over the item
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statDefense += player.statDefense + (player.statLife/4);
            player.statLifeMax2 = player.statLifeMax2 /= 2;
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