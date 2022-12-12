using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Dungeon.Content.Projectiles
{

    public class Dick : ModProjectile
    {
		public const int FadeInDuration = 7;
		public const int FadeOutDuration = 4;

		public const int TotalDuration = 256;

		// The "width" of the blade
		public float CollisionWidth => 10f * Projectile.scale;

		public int Timer {
			get => (int)Projectile.ai[0];
			set => Projectile.ai[0] = value;
		}

		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Example Shortsword");
		}

		public override void SetDefaults() {
			Projectile.Size = new Vector2(18); // This sets width and height to the same value (important when projectiles can rotate)
			Projectile.aiStyle = -1; // Use our own AI to customize how it behaves, if you don't want that, keep this at ProjAIStyleID.ShortSword. You would still need to use the code in SetVisualOffsets() though
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.tileCollide = true;
			Projectile.scale = 1f;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.ownerHitCheck = true; // Prevents hits through tiles. Most melee weapons that use projectiles have this
			Projectile.extraUpdates = 1; // Update 1+extraUpdates times per tick
			Projectile.timeLeft = 360; // This value does not matter since we manually kill it earlier, it just has to be higher than the duration we use in AI
			Projectile.hide = false; // Important when used alongside player.heldProj. "Hidden" projectiles have special draw conditions
		}

		public override void AI() {
			Player player = Main.player[Projectile.owner];
            player.heldProj = Projectile.whoAmI;
			Timer += 1;
			if (Timer >= TotalDuration) {
				// Kill the projectile if it reaches it's intented lifetime
				Projectile.Kill();
				return;
			}


			// Point towards where it is moving, applied offset for top right of the sprite respecting spriteDirection
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;

			// The code in this method is important to align the sprite with the hitbox how we want it to
		}

    }
}