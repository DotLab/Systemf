using System;

namespace Systemf {
	public static class Assert {
		public static void Equal(int a, int b) {
			if (a == b) return;
			throw new Exception(string.Format("Assertion failed, expecting {0} but got {1}", a, b));
		}
	}
}

