using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Abstract Factory example");
            Console.WriteLine("Abstract Factory is a creational design pattern, which solves the problem of creating entire product families without specifying their concrete classes.");
            Console.WriteLine();

            new Client().Main();
        }

        // the client code works with factories and products only through abstract types: AbstractFactory and AbstractProduct. 
        // this lets you pass any factory or product subclass to the client code without breaking it.
        class Client
        {
            public void Main()
            {
                // The client code can work with any concrete factory class.
                Console.WriteLine("Client: Testing client code with the first factory type...");
                ClientMethod(new ConcreteFactory1());
                Console.WriteLine();

                Console.WriteLine("Client: Testing the same client code with the second factory type...");
                ClientMethod(new ConcreteFactory2());
            }

            public void ClientMethod(IAbstractFactory factory)
            {
                var productA = factory.CreateProductA();
                var productB = factory.CreateProductB();

                Console.WriteLine(productB.UsefulFunctionB());
                Console.WriteLine(productB.AnotherUsefulFunctionB(productA));
            }
        }
    }
}