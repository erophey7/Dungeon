using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Net;
using Terraria.GameContent.NetModules;
using Terraria.GameContent.Creative;

namespace Dungeon.Content.Items.Materials
{
	public class Latex : ModItem
	{
		public override void SetStaticDefaults() {
			
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100; // How many items are needed in order to research duplication of this item in Journey mode. See https://terraria.gamepedia.com/Journey_Mode/Research_list for a list of commonly used research amounts depending on item type.
		}

		public override void SetDefaults() {
			Item.width = 16; // The item texture's width
			Item.height = 16; // The item texture's height
			Item.maxStack = 9999; // The item's max stack value
			Item.sellPrice(silver: 25);
		}
    }
}