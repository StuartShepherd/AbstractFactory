using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory
{
    // the abstract factory interface declares a set of methods that return different abstract products. 
    // these products are called a family and are related by a high-level theme or concept. 
    // products of one family are usually able to collaborate among themselves. 
    // a family of products may have several variants, but the products of one variant are incompatible with products of another.
    public interface IAbstractFactory
    {
        IAbstractProductA CreateProductA();

        IAbstractProductB CreateProductB();
    }

    // concrete factories produce a family of products that belong to a single variant. 
    // the factory guarantees that resulting products are compatible.
    // note that signatures of the concrete factory's methods return an abstract product, while inside the method a concrete product is instantiated.
    class ConcreteFactory1 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            return new ConcreteProductA1();
        }

        public IAbstractProductB CreateProductB()
        {
            return new ConcreteProductB1();
        }
    }

    // each concrete factory has a corresponding product variant.
    class ConcreteFactory2 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            return new ConcreteProductA2();
        }

        public IAbstractProductB CreateProductB()
        {
            return new ConcreteProductB2();
        }
    }

    // each distinct product of a product family should have a base interface.
    // all variants of the product must implement this interface.
    public interface IAbstractProductA
    {
        string UsefulFunctionA();
    }

    // concrete products are created by corresponding concrete factories.
    class ConcreteProductA1 : IAbstractProductA
    {
        public string UsefulFunctionA()
        {
            return "The result of the product A1.";
        }
    }

    class ConcreteProductA2 : IAbstractProductA
    {
        public string UsefulFunctionA()
        {
            return "The result of the product A2.";
        }
    }

    // here's the the base interface of another product. 
    // all products can interact with each other, but proper interaction is possible only between products of the same concrete variant.
    public interface IAbstractProductB
    {
        // product b is able to do its own thing.
        string UsefulFunctionB();

        // but it also can collaborate with the ProductA.
        
        // the abstract factory makes sure that all products it creates are of the same variant and thus, compatible.
        string AnotherUsefulFunctionB(IAbstractProductA collaborator);
    }

    // concrete products are created by corresponding concrete factories.
    class ConcreteProductB1 : IAbstractProductB
    {
        public string UsefulFunctionB()
        {
            return "The result of the product B1.";
        }

        // the variant, product b1, is only able to work correctly with the variant, product a1. 
        // nevertheless, it accepts any instance of AbstractProductA as an argument.
        public string AnotherUsefulFunctionB(IAbstractProductA collaborator)
        {
            var result = collaborator.UsefulFunctionA();

            return $"The result of the B1 collaborating with the ({result})";
        }
    }

    class ConcreteProductB2 : IAbstractProductB
    {
        public string UsefulFunctionB()
        {
            return "The result of the product B2.";
        }

        // the variant, product b2, is only able to work correctly with the variant, product a2. 
        // nevertheless, it accepts any instance of AbstractProductA as an argument.
        public string AnotherUsefulFunctionB(IAbstractProductA collaborator)
        {
            var result = collaborator.UsefulFunctionA();

            return $"The result of the B2 collaborating with the ({result})";
        }
    }
}
