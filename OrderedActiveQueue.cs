using System.Collections.Generic;

namespace Systemf { 
	public sealed class OrderedActiveQueue<T> where T : class, IActiveCheckable {
		public readonly Queue<T> itemQueue = new Queue<T>();
		
		public void Push(T item) {
			itemQueue.Enqueue(item);
		}

		public void Free() {
			while (itemQueue.Count > 0 && !itemQueue.Peek().Active) {
				itemQueue.Dequeue();
			}
		}

		public void ForceFree(T item) {
			while (itemQueue.Count > 0 && itemQueue.Peek() != item) {
				itemQueue.Dequeue();
			}
		}
	}
}