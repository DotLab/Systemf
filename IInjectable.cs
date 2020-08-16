namespace Systemf {
	public interface IInjectable {
		void Inject();
	}

	public interface IInjectable<T> {
		void Inject(T obj);
	}

	public interface IInjectable<T1, T2> {
		void Inject(T1 obj1, T2 obj2);
	}
}