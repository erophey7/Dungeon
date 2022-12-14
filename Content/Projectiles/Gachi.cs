using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace Dungeon.Content.Projectiles
{

    public class Gachi : ModProjectile
    {
		public const int FadeInDuration = 7;
		public const int FadeOutDuration = 4;

		public const int TotalDuration = 128;

		// The "width" of the blade
		public float CollisionWidth => 10f * Projectile.scale;

		public bool isStart = true;

		public int Timer {
			get => (int)Projectile.ai[0];
			set => Projectile.ai[0] = value;
		}
		private const int BufferSize = 10; // This is the amount of positions we'll store. 10 is one sixth of a second's worth, if you want more than that, just increase this value.
		private Vector2[] positionBuffer = new Vector2[BufferSize]; // Initialises a Vector2 array of size BufferSize (so 10).



		public override void SetDefaults() {
			Projectile.Size = new Vector2(18); // This sets width and height to the same value (important when Projectiles can rotate)
			Projectile.aiStyle = ProjectileID.BookOfSkullsSkull; // Use our own AI to customize how it behaves, if you don't want that, keep this at ProjAIStyleID.ShortSword. You would still need to use the code in SetVisualOffsets() though
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.tileCollide = true;
			Projectile.scale = 1f;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.ownerHitCheck = true; // Prevents hits through tiles. Most melee weapons that use Projectiles have this
			Projectile.extraUpdates = 1; // Update 1+extraUpdates times per tick
			Projectile.timeLeft = 360; // This value does not matter since we manually kill it earlier, it just has to be higher than the duration we use in AI
			Projectile.hide = false; // Important when used alongside player.heldProj. "Hidden" Projectiles have special draw conditions
		}

		public override void AI() {
			Dust.NewDustPerfect(new Vector2(Projectile.Center.X - (Projectile.width * Projectile.direction), Projectile.Center.Y), ModContent.DustType<Content.Dusts.Cum>(), null, 0, default, 0.5f); //Here we spawn the dust at the back of the Projectile with half scale.
			
			Player player = Main.player[Projectile.owner];
            player.heldProj = Projectile.whoAmI;
			Timer += 1;
			if (Timer >= TotalDuration) {
				// Kill the Projectile if it reaches it's intented lifetime
				Projectile.Kill();
				return;
			}

			                float num132 = (float)Math.Sqrt((double)(Projectile.velocity.X * Projectile.velocity.X + Projectile.velocity.Y * Projectile.velocity.Y));
                float num133 = Projectile.localAI[0];
                if (num133 == 0f)
                {
                    Projectile.localAI[0] = num132;
                    num133 = num132;
                }
                float num134 = Projectile.position.X;
                float num135 = Projectile.position.Y;
                float num136 = 300f;
                bool flag3 = false;
                int num137 = 0;
                if (Projectile.ai[1] == 0f)
                {
                    for (int num138 = 0; num138 < 200; num138++)
                    {
                        if (Main.npc[num138].CanBeChasedBy(this, false) && (Projectile.ai[1] == 0f || Projectile.ai[1] == (float)(num138 + 1)))
                        {
                            float num139 = Main.npc[num138].position.X + (float)(Main.npc[num138].width / 2);
                            float num140 = Main.npc[num138].position.Y + (float)(Main.npc[num138].height / 2);
                            float num141 = Math.Abs(Projectile.position.X + (float)(Projectile.width / 2) - num139) + Math.Abs(Projectile.position.Y + (float)(Projectile.height / 2) - num140);
                            if (num141 < num136 && Collision.CanHit(new Vector2(Projectile.position.X + (float)(Projectile.width / 2), Projectile.position.Y + (float)(Projectile.height / 2)), 1, 1, Main.npc[num138].position, Main.npc[num138].width, Main.npc[num138].height))
                            {
                                num136 = num141;
                                num134 = num139;
                                num135 = num140;
                                flag3 = true;
                                num137 = num138;
                            }
                        }
                    }
                    if (flag3)
                    {
                        Projectile.ai[1] = (float)(num137 + 1);
                    }
                    flag3 = false;
                }
                if (Projectile.ai[1] > 0f)
                {
                    int num142 = (int)(Projectile.ai[1] - 1f);
                    if (Main.npc[num142].active && Main.npc[num142].CanBeChasedBy(this, true) && !Main.npc[num142].dontTakeDamage)
                    {
                        float num143 = Main.npc[num142].position.X + (float)(Main.npc[num142].width / 2);
                        float num144 = Main.npc[num142].position.Y + (float)(Main.npc[num142].height / 2);
                        if (Math.Abs(Projectile.position.X + (float)(Projectile.width / 2) - num143) + Math.Abs(Projectile.position.Y + (float)(Projectile.height / 2) - num144) < 1000f)
                        {
                            flag3 = true;
                            num134 = Main.npc[num142].position.X + (float)(Main.npc[num142].width / 2);
                            num135 = Main.npc[num142].position.Y + (float)(Main.npc[num142].height / 2);
                        }
                    }
                    else
                    {
                        Projectile.ai[1] = 0f;
                    }
                }
                if (!Projectile.friendly)
                {
                    flag3 = false;
                }
                if (flag3)
                {
                    float num145 = num133;
                    Vector2 vector10 = new Vector2(Projectile.position.X + (float)Projectile.width * 0.5f, Projectile.position.Y + (float)Projectile.height * 0.5f);
                    float num146 = num134 - vector10.X;
                    float num147 = num135 - vector10.Y;
                    float num148 = (float)Math.Sqrt((double)(num146 * num146 + num147 * num147));
                    num148 = num145 / num148;
                    num146 *= num148;
                    num147 *= num148;
                    int num149 = 8;
                    Projectile.velocity.X = (Projectile.velocity.X * (float)(num149 - 1) + num146) / (float)num149;
                    Projectile.velocity.Y = (Projectile.velocity.Y * (float)(num149 - 1) + num147) / (float)num149;
                }
                
			
			/*if (isStart == true) {
				isStart = false;
				Projectile.rotation =- Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;
				
			}*/


			// Point towards where it is moving, applied offset for top right of the sprite respecting spriteDirection
			

			// The code in this method is important to align the sprite with the hitbox how we want it to
		}

    }
}