using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;


namespace Anthem.Items.Accessory
{
    
    internal class AnthemCharm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Anthem Charm");
            Tooltip.SetDefault("Provides bonuses to all players on your team:\n+2 defense\n+2 life regeneration\n+2 mana regeneration\n5% increased maximum HP");
        }

        

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            Item.defense = 2;
            Item.value = Item.sellPrice(silver: 50);
            Item.rare = ItemRarityID.Green;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            foreach (Player worldPlayer in Main.player)
            {
                worldPlayer.statDefense += 2; // Increase defense by 2
                worldPlayer.lifeRegen += 2; // Increase life regeneration by 2
                worldPlayer.manaRegen += 2; // Increase mana regeneration by 2
                worldPlayer.statLifeMax2 += (int)(worldPlayer.statLifeMax2 * 0.05f); // Increase maximum HP by 5%
            }
        }

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Gel, 16) // 16 Gel
                .AddIngredient(ItemID.IronBar, 4) //4 Iron Bar
				.AddTile(TileID.WorkBenches) // AddTile takes the TileID
				.Register(); // Register registers the item
		}
    }
}