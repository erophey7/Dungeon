using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace Dungeon.Content.Items.Tools
{
	public class GayHamaxe : ModItem
	{
		public override void SetStaticDefaults() {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.damage = 43;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true; // Automatically re-swing/re-use this item after its swinging animation is over.

			Item.axe = 30; // How much axe power the weapon has, note that the axe power displayed in-game is this value multiplied by 5
			Item.hammer = 90; // How much hammer power the weapon has
		}

		/*public override void MeleeEffects(Player player, Rectangle hitbox) {
			if (Main.rand.NextBool(10)) { // This creates a 1/10 chance that a dust will spawn every frame that this item is in its 'Swinging' animation.
				// Creates a dust at the hitbox rectangle, following the rules of our 'if' conditional.
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Sparkle>());
			}
		}*/

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<Content.Items.Placeable.GayBar>(22)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}