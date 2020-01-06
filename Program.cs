using System;

namespace Delegates_BasicExample
{
    class Program
    {
        // DELEGATE IS A PLACEHOLDER FOR A METHOD
        // Delegates are used at the runtime to swap out running code modules
        // Example : Main framework with plugins
        //Also used in async code to run a method (callback)
        // Also delegates can be used to call anonimous methods (using lambda)
        // Final reason is ONE EVENT: attach multiple methods but can swap methods in/out Live at Runtime
        public delegate void Delegate01();

        //non-trivial delegate:
        delegate int Delegate02(int x);
        static void Main(string[] args)
        {
            var delegateInstance = new Delegate01(Method01); //same as above
            delegateInstance(); //call the method

            //trivial cases can simplyfy (same result)
            //1. omit 'new'
            Delegate01 delegateInstance2 = Method01; //same as above
            delegateInstance2(); //call

            //final trivial case
            // ACTION delegate is void and takes no parameters
            Action delegateInstance3 = Method01; //same as above
            delegateInstance3();

            //LAMBDA INPUT PARAMS {//Code body  }
            Delegate02 delegateInstance4 = (x) => { return (x * x * x); };
            Console.WriteLine(delegateInstance4(5));

            Delegate02 delegateInstance5 = x => (x*x*x);
            //Console.WriteLine(delegateInstance5(4));

            // Pass the delegate into a method
            Console.WriteLine(Method02(delegateInstance5(10)));

            // Pass the delegate into a delegate then into a method
            Console.WriteLine(Method02(delegateInstance5(delegateInstance5(3))));
        }
        static void Method01()
        {
            Console.WriteLine("Running Method01");
        }
        static int Method02(int x)
        {
            return x * x;
        }
    }
}
