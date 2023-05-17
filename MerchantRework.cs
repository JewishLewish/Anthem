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
                int gemOfGrass = nextSlot++;
                shop.item[gemOfGrass].SetDefaults(ModContent.ItemType<Items.Accessory.GemOfGrass>(), false);
                shop.item[gemOfGrass].shopCustomPrice = 100000;

            }
		}
	}
}