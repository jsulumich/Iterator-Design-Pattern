# Iterator-Design-Pattern
A small program built using the iterator design pattern

**Goal**: Traverse a collection of elements consisting of the integers 1-10 both forwards and backwards by a user-specified step value. This should be done without exposing the collection's underlying representation.

**Class Diagram**

![Class diagram](https://github.com/jsulumich/Iterator-Design-Pattern/blob/master/IteratorDemo/Images/class%20diagram.jpg)


**IAbstractIterator**: Iterator interface which defines the methods for iteration.
<br>**reverseIterator and forwardIterator**: concrete interators that implement different traversal methods.
<br>**IAbstractCollection**: Aggregate that defines the interface for creating an iterator object.
<br>**Collection**: Concrete aggregate which implements the iterator interface.
<br>**Item**: Defines the properties and constructor of the collection item object.
<br>**IteratorDemo**: Hosts the main driver for the applicaiton.

**Program Demo**

The program prompts the user to enter a step value. It then iterates through a pre-defined collection of 10 elements by the step value, first forwards, then backwards. The user can elect to run the program again.

![Demo](https://github.com/jsulumich/Iterator-Design-Pattern/blob/master/IteratorDemo/Images/Demo.jpg)
