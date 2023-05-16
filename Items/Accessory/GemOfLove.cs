using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Anthem.Items.Accessory
{
    public class GemOfLove : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gem of Love");
            Tooltip.SetDefault("Increases max HP by 20%\n" +
                               "Gain Shine and Heartreach buff\n" +
                               "Increases life regen by 2\n" +
                               "Decrease Healing Potion Cooldown by 20%");
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
            player.AddBuff(BuffID.Shine, 2 * 60 * 60); // 2 hours

            // Apply Heartreach Potion buff
            player.AddBuff(BuffID.Heartreach, 2 * 60 * 60); // 2 hours

            // Increase maximum HP by 20%
            player.statLifeMax2 += (int)(player.statLifeMax2 * 0.2f);

            // Increase life regeneration by 2
            player.lifeRegen = 0;

            player.potionDelay -= (int)(player.potionDelay * 0.2f);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.LesserHealingPotion, 5)
                .AddIngredient(ItemID.ShinePotion, 5)
                .AddIngredient(ItemID.RegenerationPotion, 5)
                .AddIngredient(ItemID.LifeforcePotion, 5)
                .AddIngredient(ItemID.HeartreachPotion, 5)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}
