using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Dungeon.Content.Projectiles
{
	public class CumArrow : ModProjectile
	{

		public override void SetStaticDefaults() {
            ProjectileID.Sets.TrailingMode[Projectile.type] = 5;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 0;
        }
		
		public override void SetDefaults() {
            Projectile.width = 14;                   
            Projectile.height = 32;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;          // Дальний бой true - yes false - no
			Projectile.penetrate = 5;
			Projectile.timeLeft = 600;             
            Projectile.light = 1f;       //Освщение при выстреле (наверное)
            Projectile.extraUpdates = 1;
            AIType = ProjectileID.VenomArrow;                
	    }
        public override void AI() {
			Player player = Main.player[Projectile.owner];
            player.heldProj = Projectile.whoAmI;


			// Point towards where it is moving, applied offset for top right of the sprite respecting spriteDirection
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;

			// The code in this method is important to align the sprite with the hitbox how we want it to
		}
        
	}
}