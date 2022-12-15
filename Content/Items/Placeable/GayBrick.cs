using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace Dungeon.Content.Items.Placeable
{
	public class GayBrick : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("This is a modded tile.");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
			ItemID.Sets.ExtractinatorMode[Item.type] = Item.type;

		}

		public override void SetDefaults() {
			Item.width = 12;
			Item.height = 12;
			Item.maxStack = 9999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<Tiles.GayBrickTile>();
		}

		public override void AddRecipes() {
			CreateRecipe(10)
				.AddIngredient<Content.Items.Placeable.GayOre>()
                .AddIngredient(ItemID.StoneBlock, 10)
				.AddTile(TileID.Furnaces)
				.Register();

			/*CreateRecipe() // Add multiple recipes set to one Item.
				.AddIngredient<ExampleWall>(4)
				.AddTile<Tiles.Furniture.ExampleWorkbench>()
				.Register();

			CreateRecipe()
				.AddIngredient<ExamplePlatform>(2)
				.AddTile<Tiles.Furniture.ExampleWorkbench>()
				.Register();*/
		}
	}
}