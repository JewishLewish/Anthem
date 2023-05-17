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
            Tooltip.SetDefault("Any attack inflicts Ichor, Venom, On Fire!, Betsy's Curse and Frostburn\n"+
            "On death, all enemies are inflicted with debuffs");
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
            player.GetModPlayer<YourModPlayer>().Hellbent = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.InfernoPotion, 1)
                .AddIngredient(ItemID.RagePotion, 5)
                .AddIngredient(ItemID.HunterPotion, 5)
                .AddIngredient(ItemID.TitanPotion, 5)
                .AddIngredient(ItemID.BattlePotion, 5)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}
