using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Dungeon.Content.Items.Weapons.Range
{
	public class GayRepeater : ModItem
	{
		
		public override void SetStaticDefaults() {

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.damage = 87;
            Item.noMelee = true;    
            Item.DamageType = DamageClass.Ranged;               //Становится луком
            Item.width = 22;                   
            Item.height = 44;
            Item.useTime = 14;
            Item.useAnimation = 30;
            Item.useStyle = 5;
			Item.shoot = 13;
			Item.shootSpeed = 10;             //скорость полета стрелы 
			Item.useAmmo = AmmoID.Arrow;           //то чем будет стрелять в нашем случае стрелой
            Item.knockBack = 7;
            Item.value = 90000;
            Item.rare = 7;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            Item.useTurn = true;
	    }		

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<Content.Items.Placeable.GayBar>(10)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}

		// This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
		
		/*
		* Feel free to uncomment any of the examples below to see what they do
		*/

		// What if I wanted it to work like Uzi, replacing regular bullets with High Velocity Bullets?
		// Uzi/Molten Fury style: Replace normal Bullets with High Velocity
		/*public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
			if (type == ProjectileID.WoodenArrowFriendly) { // or ProjectileID.WoodenArrowFriendly
				type = ModContent.ProjectileType<Content.Projectiles.CumArrow>(); // or ProjectileID.FireArrow;
			}*/
		

		// What if I wanted multiple projectiles in a even spread? (Vampire Knives)
		// Even Arc style: Multiple Projectile, Even Spread
		/*public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			float numberProjectiles = 3 + Main.rand.Next(3); // 3, 4, or 5 shots
			float rotation = MathHelper.ToRadians(45);
			position += Vector2.Normalize(velocity) * 45f;
			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
				Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
			}
			return false; // return false to stop vanilla from calling Projectile.NewProjectile.
		}*/

		// How can I make the shots appear out of the muzzle exactly?
		// Also, when I do this, how do I prevent shooting through tiles?
		/*public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0)) {
				position += muzzleOffset;
			}
		}*/

		// How can I get a "Clockwork Assault Rifle" effect?
		// 3 round burst, only consume 1 ammo for burst. Delay between bursts, use reuseDelay
		// Make the following changes to SetDefaults():
		/*
			Item.useAnimation = 12;
			Item.useTime = 4; // one third of useAnimation
			Item.reuseDelay = 14;
			Item.consumeAmmoOnLastShotOnly = true;
		*/

		// How can I shoot 2 different projectiles at the same time?
		/*public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			// Here we manually spawn the 2nd projectile, manually specifying the projectile type that we wish to shoot.
			Projectile.NewProjectile(source, position, velocity, ProjectileID.GrenadeI, damage, knockback, player.whoAmI);
			// By returning true, the vanilla behavior will take place, which will shoot the 1st projectile, the one determined by the ammo.
			return true;
		}*/

		// How can I choose between several projectiles randomly?
		/*public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
			// Here we randomly set type to either the original (as defined by the ammo), a vanilla projectile, or a mod projectile.
			type = Main.rand.Next(new int[] { type, ProjectileID.GoldenBullet, ModContent.ProjectileType<Projectiles.ExampleBullet>() });
		}*/
	}
}