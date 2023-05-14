using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;

namespace Anthem.Items.Accessory
{
    ///[AutoloadEquip(EquipType.Shield)]
    internal class balls : ModItem
    {
        public override void SetStaticDefaults()
        {
            
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            DisplayName.SetDefault("ball"); // The displayed name of the item
            Tooltip.SetDefault("Ur balls are strong!"); // The tooltip displayed when hovering over the item
        }



        public override Vector2? HoldoutOffset()
        {
            return base.HoldoutOffset();
        }

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Gel, 1) // AddIngredient takes ItemID, then Quantity
				.AddTile(TileID.WorkBenches) // AddTile takes the TileID
				.Register(); // Register registers the item
		}

        		public override void SetDefaults() {
			Item.width = 24;
			Item.height = 24;
			Item.value = Item.buyPrice(0, 10, 0, 0);
			Item.rare = ItemRarityID.Cyan;
			Item.expert = true;
			Item.accessory = true;
			Item.damage = 120;
			Item.knockBack = 2f;
			Item.defense = 6;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<ExamplePlayer>().elementShield = true;
		}

		public override Color? GetAlpha(Color lightColor) {
			return Color.White;
		}

		public override bool CanEquipAccessory(Player player, int slot) {
			if (slot < 10) // This allows the accessory to equip in Vanity slots with no reservations.
			{
				int maxAccessoryIndex = 5 + player.extraAccessorySlots;
				for (int i = 3; i < 3 + maxAccessoryIndex; i++) {
					// We need "slot != i" because we don't care what is currently in the slot we will be replacing.
					if (slot != i && player.armor[i].type == ItemID.AnkhShield) {
						return false;
					}
				}
			}
			return true;
		}
	}

	// We need to do the same for the AnkhShield so our restriction is enforced both ways.
	public class AnkhShield : GlobalItem
	{
		public override bool CanEquipAccessory(Item item, Player player, int slot) {
			if (item.type == ItemID.AnkhShield) {
				if (slot < 10) // This allows the accessory to equip in Vanity slots with no reservations.
				{
					int maxAccessoryIndex = 5 + player.extraAccessorySlots;
					for (int i = 3; i < 3 + maxAccessoryIndex; i++) {
						// We need "slot != i" because we don't care what is currently in the slot we will be replacing.
						if (slot != i && player.armor[i].type == ItemType<balls>()) {
							return false;
						}
					}
				}
			}
			return true;
		}
	}
}

    }
}