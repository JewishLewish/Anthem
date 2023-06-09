﻿using Terraria;
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
            player.AddBuff(BuffID.Campfire, 0);

            // Apply Heartreach Potion buff
            player.AddBuff(BuffID.DryadsWard, 0);

            player.AddBuff(BuffID.Honey, 0);

            player.AddBuff(BuffID.StarInBottle, 0);

            player.AddBuff(BuffID.CatBast, 0);

            player.AddBuff(BuffID.Sunflower, 0);

            player.AddBuff(BuffID.WellFed, 0);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Campfire, 1) //Campfire
                .AddIngredient(ItemID.CatBast, 1) //CatBast
                .AddIngredient(ItemID.StarinaBottle, 1) //StarinaBottle
                .AddIngredient(ItemID.BottledHoney, 2) // BottledHoney
                .AddIngredient(ItemID.Sunflower, 4) //4 Sunflowers
                .AddIngredient(ItemID.HeartLantern,1) //Heart Lantern
                .AddTile(TileID.Campfire)
                .Register();
        }
    }
}
