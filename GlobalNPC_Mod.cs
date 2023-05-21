using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using System;

namespace Anthem
{
	public class GlobalNPC_Mod : GlobalNPC
	{
		//If the merchant has been hit by a player, they will double their sell price
		public override void SetupShop(int type, Chest shop, ref int nextSlot) {
            if (type == NPCID.Merchant) // Check if the NPC is the Merchant
            {
                if (HasItemInInventory(ModContent.ItemType<Items.Accessory.GemOfGrass>())) {
                    int item = nextSlot++;
                    shop.item[item].SetDefaults(ModContent.ItemType<Items.Accessory.GemOfGrass>(), false);
                    shop.item[item].shopCustomPrice = 100000;
                }

                if (HasItemInInventory(ModContent.ItemType<Items.Accessory.GemOfHeavenBound>())) {
                    int item = nextSlot++;
                    shop.item[item].SetDefaults(ModContent.ItemType<Items.Accessory.GemOfHeavenBound>(), false);
                    shop.item[item].shopCustomPrice = 100000;
                }

                if (HasItemInInventory(ModContent.ItemType<Items.Accessory.GemOfHellbent>())) {
                    int item = nextSlot++;
                    shop.item[item].SetDefaults(ModContent.ItemType<Items.Accessory.GemOfHellbent>(), false);
                    shop.item[item].shopCustomPrice = 100000;
                }

                if (HasItemInInventory(ModContent.ItemType<Items.Accessory.GemOfLove>())) {
                    int item = nextSlot++;
                    shop.item[item].SetDefaults(ModContent.ItemType<Items.Accessory.GemOfLove>(), false);
                    shop.item[item].shopCustomPrice = 100000;
                }

                if (HasItemInInventory(ModContent.ItemType<Items.Accessory.GemOfStrength>())) {
                    int item = nextSlot++;
                    shop.item[item].SetDefaults(ModContent.ItemType<Items.Accessory.GemOfStrength>(), false);
                    shop.item[item].shopCustomPrice = 100000;
                }

                if (HasItemInInventory(ModContent.ItemType<Items.Accessory.InfinityGauntlet>())) {
                    int item = nextSlot++;
                    shop.item[item].SetDefaults(ModContent.ItemType<Items.Accessory.InfinityGauntlet>(), false);
                    shop.item[item].shopCustomPrice = 600000;
                }


            }
		}

        public bool HasItemInInventory(int itemId)
        {
            Player player = Main.LocalPlayer;
            for (int i = 0; i < player.inventory.Length; i++)
            {
                if (player.inventory[i].type == itemId)
                {
                    return true;
                }
            }
            return false;
        }
        Random random = new Random();
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
            // First, we need to check the npc.type to see if the code is running for the vanilla NPC we want to change
            
            if (npc.type == NPCID.Harpy) {
                // This is where we add item drop rules for VampireBat, here is a simple example:
                if (random.Next(1, 101) == 1) {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Consumable.GoldenFeather>(), 1));
                }

            }
            // We can use other if statements here to adjust the drop rules of other vanilla NPC
        }
	}
}