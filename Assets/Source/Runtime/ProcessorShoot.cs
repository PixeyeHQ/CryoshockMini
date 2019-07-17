//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using Pixeye.Framework;
using UnityEngine;

namespace Pixeye.Source
{
	sealed class ProcessorShoot : Processor, ITick
	{
		const float BlinkTime = 0.06f;


		static Sprite SpriteAmmo01 = Box.Load<Sprite>("Content/fx/tex_ammo_gun_01");
		static Sprite SpriteAmmo02 = Box.Load<Sprite>("Content/fx/tex_ammo_gun_02");


		Group<ComponentWeapon, ComponentFace, ComponentObject, ComponentInput> groupShoot;
		BufferStruct<SegmentAmmo> bufferAmmos;

		public ProcessorShoot()
		{
			bufferAmmos = new BufferStruct<SegmentAmmo>(1000);
		}

		public void Tick(float delta)
		{
			for (int i = 0; i < groupShoot.length; i++)
			{
				ref var entity  = ref groupShoot[i];
				ref var cWeapon = ref entity.ComponentWeapon();
				ref var cInput  = ref entity.ComponentInput();
				ref var cFace   = ref entity.ComponentFace();
				ref var cObject = ref entity.ComponentObject();

				ref var t = ref cWeapon.t;

				if (t.MinusCheck(delta))
				{
					if (Input.GetKeyDown(cInput.inputShoot))
					{
						t = cWeapon.timeRate;


						// Make Bullet
						var position = cObject.position;
						position.x += cFace.direction * 0.15f;
						position.y += 0.02f;

						ref var segment = ref bufferAmmos.Add();
						segment.source   = Obj.Spawn(Pool.Entities, DataBase.Prefabs.Sprite, position);
						segment.position = position;
						segment.renderer = segment.source.GetComponent<SpriteRenderer>();
						segment.speed    = 3 * cFace.direction;
						segment.lifeTime = 1.0f;
					}
				}
			}

			for (int i = 0; i < bufferAmmos.length; i++)
			{
				ref var segment   = ref bufferAmmos[i];
				ref var blinkTime = ref segment.blinkTime;
				ref var lifeTime  = ref segment.lifeTime;
				ref var position  = ref segment.position;

				if ((blinkTime += delta) > BlinkTime)
				{
					blinkTime = 0.0f;
					if (segment.blinkStage == 1)
					{
						segment.blinkStage      = 0;
						segment.renderer.sprite = SpriteAmmo01;
					}
					else
					{
						segment.blinkStage      = 1;
						segment.renderer.sprite = SpriteAmmo02;
					}
				}

				var nextMoveStep = segment.speed * delta;
				segment.source.position =  position;
				position.x              += nextMoveStep;

				if (Phys.GetMonster(out ent nextMonster, position, new Vector2(segment.speed, 0), nextMoveStep, 1 << 0))
				{
					nextMonster.Release();
					lifeTime = -1;
				}

				if ((lifeTime -= delta) <= delta)
				{
					segment.source.gameObject.Release(Pool.Entities);
					bufferAmmos.RemoveAt(i);
				}
			}
		}
	}
}