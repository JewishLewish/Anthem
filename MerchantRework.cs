using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Anthem
{
	public class MerchantRework : GlobalNPC
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
	}
}