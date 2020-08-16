namespace Systemf {
	public interface IInitable {
		void Init();
	}

	public interface IInitable<T> {
		void Init(T obj);
	}

	public interface IInitable<T1, T2> {
		void Init(T1 obj1, T2 obj2);
	}
}