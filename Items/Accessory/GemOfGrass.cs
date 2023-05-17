using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Anthem.Items.Accessory
{
    public class GemOfGrass : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gem of Grass");
            Tooltip.SetDefault("POWER OF GRASS HAS BEEN TOUCHED!\n" +
            "Gives all Environmental Buffs Including:\n-> Campfire\n-> Dryad's Blessing\n-> Happy!\n-> Heart Latern\n-> Honey\n-> Star in a Bottle\n-> The Bast Defense");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.value = Item.buyPrice(0, 10, 0, 0);
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
        }

                public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // Apply Shining Potion buff
            player.AddBuff(BuffID.Campfire, 0); // 2 hours

            // Apply Heartreach Potion buff
            player.AddBuff(BuffID.DryadsWard, 0); // 2 hours

            player.AddBuff(BuffID.Honey, 0);

            player.AddBuff(BuffID.StarInBottle, 0);

            player.AddBuff(BuffID.CatBast, 0);

            player.AddBuff(BuffID.Sunflower, 0);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Campfire, 1)
                .AddIngredient(ItemID.CatBast, 1)
                .AddIngredient(ItemID.StarinaBottle, 1)
                .AddIngredient(ItemID.BottledHoney, 8)
                .AddIngredient(ItemID.Sunflower, 16)
                .AddIngredient(ItemID.HeartLantern,1)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}
