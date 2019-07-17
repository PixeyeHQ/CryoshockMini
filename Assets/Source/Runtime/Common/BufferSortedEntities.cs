//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using System;
using System.Runtime.CompilerServices;
using Pixeye.Framework;
using Unity.IL2CPP.CompilerServices;

namespace Pixeye.Source
{
	[Il2CppSetOption(Option.NullChecks | Option.ArrayBoundsChecks | Option.DivideByZeroChecks, false)]
	public sealed class BufferSortedEntities
	{
		public int[] pointers = new int[1024];
		public ent[] entities = new ent[1024];

		public int length;

		public BufferSortedEntities(int size)
		{
			pointers = new int[size];
			entities = new ent[size];
		}

		//===============================//
		// Insert
		//===============================//
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Insert(in ent entity, int instanceID)
		{
			var left  = 0;
			var index = 0;
			var right = length++;

			if (length >= pointers.Length)
			{
				var l = left << 1;
				Array.Resize(ref entities, l);
				Array.Resize(ref pointers, l);
			}

			var consitionSort = right - 1;
			if (consitionSort > -1 && instanceID < pointers[consitionSort])
			{
				while (right > left)
				{
					var midIndex = (right + left) / 2;

					if (pointers[midIndex] == instanceID)
					{
						index = midIndex;
						break;
					}

					if (pointers[midIndex] < instanceID)
						left = midIndex + 1;
					else
						right = midIndex;

					index = left;
				}

				Array.Copy(pointers, index, pointers, index + 1, length - index);
				Array.Copy(entities, index, entities, index + 1, length - index);
				entities[index] = entity;
				pointers[index] = instanceID;
			}
			else
			{
				pointers[right] = instanceID;
				entities[right] = entity;
			}
		}

		//===============================//
		// GET
		//===============================//
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Get(int instanceID, out ent entity)
		{
			var index = HelperArray.BinarySearch(ref pointers, instanceID, 0, length);
			if (index == -1)
			{
				entity = new ent(-1);
				return false;
			}

			entity = entities[index];
			return true;
		}

		//===============================//
		// REMOVE
		//===============================//
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Remove(int instanceID)
		{
			if (length == 0) return;
			var i = HelperArray.BinarySearch(ref pointers, instanceID, 0, length);
			if (i == -1) return;
			Array.Copy(pointers, i + 1, pointers, i, length - i);
			Array.Copy(entities, i + 1, entities, i, length-- - i);
		}
	}
}