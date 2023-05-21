using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;


namespace Anthem.Items.Consumable
{
    internal class GoldenFeather : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Golden Feather");
            Tooltip.SetDefault("A rare feather that grants an additional accessory slot\nCan only be used once");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.sellPrice(gold: 1);
        }

        public override bool CanUseItem(Player player)
        {
            // Allow using the item only if the player hasn't used it before
            return !player.GetModPlayer<YourModPlayer>().GoldenFeatherUsed;
        }

        public override bool? UseItem(Player player)
        {
            if ( player.GetModPlayer<YourModPlayer>().GoldenFeatherUsed == false) {
                            // Increment the player's accessory slot count
            player.extraAccessorySlots++;

            // Set the flag to indicate that the Golden Feather has been used
            player.GetModPlayer<YourModPlayer>().GoldenFeatherUsed = true;

            // Return true to consume the item
            return true;
            } else {
                return false;
            }

        }

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.BandofRegeneration, 1) // Band of regeneration
                .AddIngredient(ItemID.NaturesGift, 1) // NaturesGift
                .AddIngredient(ItemID.IronBar, 2) // 2 Iron Bars
				.AddTile(TileID.Chairs) // AddTile takes the TileID
				.Register(); // Register registers the item
		}
    }
}