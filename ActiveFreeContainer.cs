using System;
using System.Collections.Generic;

namespace Systemf {
	public sealed class ActiveFreeContainer<T> where T : IIndexable {
		public readonly List<T> itemList = new List<T>();
		public int firstFreeItemIndex;

		public Func<T> createItemHandler;

		public ActiveFreeContainer(Func<T> createItemHandler) {
			this.createItemHandler = createItemHandler;
		}

		public T CreateOrReuseItem() {
			T item;
			if (firstFreeItemIndex < itemList.Count) {
				// Has free item
				item = itemList[firstFreeItemIndex];
			} else {
				// Need to create new item
				item = createItemHandler();
				item.Index = firstFreeItemIndex;
				itemList.Add(item);
			}
			firstFreeItemIndex += 1;
			return item;
		}

		public void FreeItem(T item) {
			if (item.Index >= firstFreeItemIndex) {
				// Already free
				UnityEngine.Debug.LogErrorFormat("Duplicated free at {0} with free start at {1}", item.Index, firstFreeItemIndex);
				return;
			}

			int itemIndex = item.Index;
			firstFreeItemIndex -= 1;
			var lastActiveItem = itemList[firstFreeItemIndex];
			// Swap item and lastActiveItem since item is now free
			itemList[itemIndex] = lastActiveItem;
			lastActiveItem.Index = itemIndex;
			itemList[firstFreeItemIndex] = item;
			item.Index = firstFreeItemIndex;
		}
	}
}