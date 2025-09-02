namespace Basic_CSharp
{

	public class Out_ref_in
	{

		public void Normalcalling(int value)
		{
			value = 10;
		}

		public void Refcalling(ref int value)
		{
			value = value + 20;
		}
		public void Outcalling(out int value) // out just like ref, but must assign before use, because it is for output
		{
			value = 0; // must assign before use
					   //value = value + 30; //this is error, must assign; can't read previous value with 'out'
			value = 30;
		}

		public void Incalling(in int value) // in just like ref, but can't assign in the method, because it is for input only
		{
			//value = value + 40; // this is error, can't assign; can't change value with 'in'
			Console.WriteLine(value); // can read value
		}
		public void Test()
		{
			int a = 1;
			Normalcalling(a);
			// a is still 1
			Console.WriteLine(a); // Output: 1

			int b = 1;
			Refcalling(ref b);
			// b is now 21
			Console.WriteLine(b); // Output: 21

			int c;      // doesn't need init for 'out'
			Outcalling(out c);
			// c is now 30
			Console.WriteLine(c); // Output: 30
			
			int d = 1; // must init for 'in'
			Incalling(in d);
			// d is still 1

		}
	}
}