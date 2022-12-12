using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Dungeon.Content.Projectiles;

namespace Dungeon.Content.Items.Weapons.Melee
{
	public class DickShooter : ModItem
	{
		public override void SetStaticDefaults()
		{

			DisplayName.SetDefault("Членострел");
			Tooltip.SetDefault("Меч великого дрочлы");
		}

		public override void SetDefaults()
		{
			Item.damage = 5000;
			Item.DamageType = DamageClass.Melee;
			Item.width = 60;
			Item.height = 120;
			Item.useTime = 10;
			Item.useAnimation = 15;
			Item.noMelee = false;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 500000;
			Item.rare = 11;
			Item.shoot = ModContent.ProjectileType<Dick>();
			Item.shootSpeed = 6;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.crit = 48;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.RedPotion, 1);
			recipe.AddTile(TileID.PlatinumCoinPile);
			recipe.Register();
		}
	}
}