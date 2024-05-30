using System;

namespace Sandbox
{
    // Demonstrates the fundamental semantic differences between structs and classes in C#:
    // - Structs are value types, meaning when assigned, a copy of the struct is created. 
    //   Consequently, modifications to one struct do not affect another, even if they were initially identical.
    // - Classes are reference types, implying that assignments involve copying the reference to the same memory location.
    //   Therefore, changes to one class instance will reflect in another, as they both point to the same underlying data.

    public struct MyStruct(int firstArg, string secondArg)
    {
        public int StructMemberOne = firstArg;
        public string StructMemberTwo = secondArg;
    }

    public class MyClass(int firstArg)
    {
        public int ClassMemberOne = firstArg;
    }

    static class Program
    {
        static void Main()
        {
            MyStruct TestStruct = new(1, "Hello");
            MyStruct AnotherStruct = TestStruct;

            System.Console.WriteLine("STRUCT DEMO, INITIAL VALUES:");

            System.Console.WriteLine($"var TestStruct: {TestStruct.StructMemberOne} - {TestStruct.StructMemberTwo}");
            System.Console.WriteLine($"var AnotherStruct: {AnotherStruct.StructMemberOne} - {AnotherStruct.StructMemberTwo}");

            AnotherStruct.StructMemberOne = 2;
            AnotherStruct.StructMemberTwo = "Changed";

            System.Console.WriteLine("AnotherStruct's values have been changed.");

            System.Console.WriteLine($"var TestStruct: {TestStruct.StructMemberOne} - {TestStruct.StructMemberTwo}");
            System.Console.WriteLine($"var AnotherStruct: {AnotherStruct.StructMemberOne} - {AnotherStruct.StructMemberTwo}\n");

            MyClass TestClass = new(1);
            MyClass AnotherClass = TestClass;

            System.Console.WriteLine("CLASS DEMO, INITIAL VALUES:");

            System.Console.WriteLine($"var TestClass: {TestClass.ClassMemberOne}");
            System.Console.WriteLine($"var AnotherClass: {AnotherClass.ClassMemberOne}");

            System.Console.WriteLine("AnotherClass' value has been changed.");

            AnotherClass.ClassMemberOne = 99;

            System.Console.WriteLine($"var TestClass: {TestClass.ClassMemberOne}");
            System.Console.WriteLine($"var AnotherClass: {AnotherClass.ClassMemberOne}");
        }
    }
}
