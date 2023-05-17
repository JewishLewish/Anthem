using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Anthem.Items.Accessory
{
    public class InfinityGauntlet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infinity Gauntlet");
            Tooltip.SetDefault("Combines all Gems Powers\n"+"Any attack inflicts Ichor, Venom, On Fire!, Betsy's Curse and Frostburn\n"+
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
            //Gem of Strength
            player.maxMinions++;
            player.statDefense += 8;
            player.GetDamage(DamageClass.Generic) += 0.1f; //%10 Increase in Damage
            player.GetModPlayer<YourModPlayer>().reflectDamage = true;
            player.moveSpeed += 0.25f;

            //Gem of Hellbent
            player.GetModPlayer<YourModPlayer>().Hellbent = true;

            //Gem of Love
            player.AddBuff(BuffID.Shine, 0);
            player.AddBuff(BuffID.Heartreach, 0);
            player.statLifeMax2 += (int)(player.statLifeMax2 * 0.2f);
            player.lifeRegen = 0;
            player.potionDelay -= (int)(player.potionDelay * 0.2f);

            //Gem of HeavenBound
            player.GetModPlayer<YourModPlayer>().HeavenGem = true;
            player.manaRegenBonus += (int)0.2f;
            player.AddBuff(BuffID.Lucky, 0);
            player.AddBuff(BuffID.Spelunker, 0);

            //Gem of Grass
            player.AddBuff(BuffID.Campfire, 0);
            player.AddBuff(BuffID.DryadsWard, 0);
            player.AddBuff(BuffID.Honey, 0);
            player.AddBuff(BuffID.StarInBottle, 0);
            player.AddBuff(BuffID.CatBast, 0);
            player.AddBuff(BuffID.Sunflower, 0);

            player.AddBuff(BuffID.WellFed3, 0);

            
            //Gauntlet
            player.AddBuff(BuffID.Lifeforce , 0);

        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<Items.Accessory.GemOfGrass>(), 1)
                .AddIngredient(ModContent.ItemType<Items.Accessory.GemOfLove>(), 1)
                .AddIngredient(ModContent.ItemType<Items.Accessory.GemOfHellbent>(), 1)
                .AddIngredient(ModContent.ItemType<Items.Accessory.GemOfHeavenBound>(), 1)
                .AddIngredient(ModContent.ItemType<Items.Accessory.GemOfStrength>(), 1)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}
