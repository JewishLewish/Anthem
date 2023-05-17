using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Anthem.Items.Accessory
{
    public class GemOfStrength : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gem of Strength");
            Tooltip.SetDefault("Increases summon slots by 1\n" +
                               "Increases defense by 8\n" +
                               "Increases melee damage by 10%\n" +
                               "Reflects 10% of damage taken onto enemies\n" +
                               "Increases movement speed by 25%");
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
            player.maxMinions++;
            player.statDefense += 8;
            player.GetDamage(DamageClass.Generic) += 0.1f; //%10 Increase in Damage
            player.GetModPlayer<YourModPlayer>().reflectDamage = true;
            player.moveSpeed += 0.25f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SwiftnessPotion, 5)
                .AddIngredient(ItemID.IronskinPotion, 5)
                .AddIngredient(ItemID.ThornsPotion, 5)
                .AddIngredient(ItemID.WrathPotion, 5)
                .AddIngredient(ItemID.SummoningPotion, 5)
                .AddTile(TileID.Bottles)
                .Register();
        }
    }
}
