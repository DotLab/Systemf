using System;
using System.Collections.Generic;

namespace Systemf {
	public sealed class ActiveSet<T> {
		public readonly List<T> itemList = new List<T>();
		public int firstFreeItemIndex;

		public void AddItem(T item) {
			if (firstFreeItemIndex < itemList.Count) {
				// Has free item
				itemList[firstFreeItemIndex] = item;
			} else {
				// Need to create new item
				itemList.Add(item);
			}
			firstFreeItemIndex += 1;
		}

		public void FreeItemAt(int itemIndex) {
			firstFreeItemIndex -= 1;
			var lastActiveItem = itemList[firstFreeItemIndex];
			// Swap item and lastActiveItem since item is now free
			itemList[itemIndex] = lastActiveItem;
			itemList[firstFreeItemIndex] = default;
		}
	}
}