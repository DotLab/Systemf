namespace Systemf {
	public struct Tuple {
		public static Tuple<T1, T2> Create<T1, T2>(T1 item1, T2 item2) {
				return new Tuple<T1, T2>(item1, item2);
		}

		public static Tuple<T1, T2, T3> Create<T1, T2, T3>(T1 item1, T2 item2, T3 item3) {
				return new Tuple<T1, T2, T3>(item1, item2, item3);
		}

		internal static int CombineHashCodes(int h1, int h2) {
			return (((h1 << 5) + h1) ^ h2);
		}
		
		internal static int CombineHashCodes(int h1, int h2, int h3) { 
			return CombineHashCodes(CombineHashCodes(h1, h2), h3);
		}
		
		internal static int CombineHashCodes(int h1, int h2, int h3, int h4) {
			return CombineHashCodes(CombineHashCodes(h1, h2), CombineHashCodes(h3, h4));
		}
		
		internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5) {
			return CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), h5);
		}
		
		internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6) {
			return CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), CombineHashCodes(h5, h6));
		}
		
		internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6, int h7) {
			return CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), CombineHashCodes(h5, h6, h7));
		}
		
		internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6, int h7, int h8) {
			return CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), CombineHashCodes(h5, h6, h7, h8));
		}
	}
	
	public struct Tuple<T1, T2> : System.IEquatable<Tuple<T1, T2>> {
		public readonly T1 item1;
		public readonly T2 item2;
		
		public Tuple(T1 item1, T2 item2) {
			this.item1 = item1;
			this.item2 = item2;
		}
		
		public override int GetHashCode() {
			return Tuple.CombineHashCodes(item1.GetHashCode(), item2.GetHashCode());
		}
		
		public override bool Equals(object obj) {
			if (obj == null || GetType() != obj.GetType()) {
				return false;
			}
			return Equals((Tuple<T1, T2>)obj);
		}
		
		public bool Equals(Tuple<T1, T2> other) {
			return other.item1.Equals(item1) && other.item2.Equals(item2);
		}
	}
	
	public struct Tuple<T1, T2, T3> : System.IEquatable<Tuple<T1, T2, T3>> {
		public readonly T1 item1;
		public readonly T2 item2;
		public readonly T3 item3;
		
		public Tuple(T1 item1, T2 item2, T3 item3) {
			this.item1 = item1;
			this.item2 = item2;
			this.item3 = item3;
		}
		
		public override int GetHashCode() {
			return Tuple.CombineHashCodes(item1.GetHashCode(), item2.GetHashCode(), item3.GetHashCode());
		}
		
		public override bool Equals(object obj) {
			if (obj == null || GetType() != obj.GetType()) {
				return false;
			}
			return Equals((Tuple<T1, T2, T3>)obj);
		}
		
		public bool Equals(Tuple<T1, T2, T3> other) {
			return other.item1.Equals(item1) && other.item2.Equals(item2) && other.item3.Equals(item3);
		}
	}
}