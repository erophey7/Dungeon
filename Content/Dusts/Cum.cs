using Terraria;
using Terraria.ModLoader;

namespace Dungeon.Content.Dusts
{
	public class Cum : ModDust
	{
		public override void OnSpawn(Dust dust) {
			dust.velocity *= 0.4f; // Умножаем начальную скорость пыли на 0,4, замедляя ее
			dust.noGravity = true; // Пыль становиться невесомой
			dust.noLight = true; // Пыль не светиться
			dust.scale *= 1.5f; // Умножает начальный масштаб пыли на 1.5
		}

		public override bool Update(Dust dust) { // Вызывает каждый кадр, когда активна пыль
			dust.position += dust.velocity;
			dust.rotation += dust.velocity.X * 0.15f;
			dust.scale *= 0.99f;

			float light = 0.35f * dust.scale;

			Lighting.AddLight(dust.position, light, light, light);

			if (dust.scale < 0.5f) {
				dust.active = false;
			}

			return false; // Возвращаем false, чтобы предотвратить ванильное поведение.
		}
	}
}