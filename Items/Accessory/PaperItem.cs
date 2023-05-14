using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace Anthem.Items.Accessory
{
    //[AutoloadEquip(EquipType.Shoes)]
    internal class PaperItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            DisplayName.SetDefault("Paper Item"); // The displayed name of the item
            Tooltip.SetDefault("Summons Pet Paper Airplane"); // The tooltip displayed when hovering over the item
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            Item.defense = 5;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(ModContent.BuffType<Buff.Paper_Buff>(), -1);
            player.moveSpeed *=.05f;
        }

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Gel, 1) // AddIngredient takes ItemID, then Quantity
				.AddTile(TileID.WorkBenches) // AddTile takes the TileID
				.Register(); // Register registers the item
		}
    }
}