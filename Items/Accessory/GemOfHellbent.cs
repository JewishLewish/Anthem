using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Anthem.Items.Accessory
{
    public class GemOfHellbent : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gem of Hellbent");
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
            player.GetModPlayer<YourModPlayer>().flamingAmulet = true;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit) {

        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Campfire, 1)
                .AddIngredient(ItemID.CatBast, 1)
                .AddIngredient(ItemID.StarinaBottle, 1)
                .AddIngredient(ItemID.BottledHoney, 8)
                .AddIngredient(ItemID.Sunflower, 16)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}
