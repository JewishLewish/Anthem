using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Anthem.Items.Accessory
{
    public class GemOfHeavenBound : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gem of HeavenBound");
            Tooltip.SetDefault("1/20th of Damage Dealt will heal you\n"+
            "On revive, players gain Heavenbound effect\n"+
            "Permanent Greater Luck Buff Effect and Spelunker\n"+
            "x1.2 boost on Mana Regeneration\n");
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
            player.GetModPlayer<YourModPlayer>().HeavenGem = true;
            player.manaRegenBonus += (int)0.2f;
            player.AddBuff(BuffID.Lucky, 0);
            player.AddBuff(BuffID.Spelunker, 0);

        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.LuckPotionGreater, 1)
                .AddIngredient(ItemID.SpelunkerPotion, 5)
                .AddIngredient(ItemID.LesserManaPotion, 8)
                .AddIngredient(ItemID.CrimsonCampfire, 4)
                .AddIngredient(ItemID.Diamond, 8)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}
