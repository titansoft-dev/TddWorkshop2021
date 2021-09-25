using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TitansoftTddWorkshop.UnitTests
{
    [TestFixture]
    public class MyStackTest
    {
        [SetUp]
        public void Setup()
        {
            _target = new MyStack<int>(_StackSize);
        }

        [TearDown]
        public void CleanUp()
        {
        }

        private MyStack<int> _target;
        private static readonly int _StackSize = 5;

        [Test]
        public void NewStackShouldBeEmpty()
        {
            _target.Size.Should().Be(0);
        }

        [Test]
        public void SizeIncreaseWhenPushItem()
        {
            _target.Push(10);

            _target.Size.Should().Be(1);
        }

        [Test]
        public void SizeReduceAndGetLastestItemWhenPop()
        {
            _target.Push(10);
            _target.Push(20);

            _target.Pop().Should().Be(20);

            _target.Size.Should().Be(1);
        }

        [Test]
        public void GetLastestItemWithoutSizeChangedWhenPeep()
        {
            _target.Push(10);
            _target.Push(20);

            _target.Peep().Should().Be(20);

            _target.Size.Should().Be(2);
        }

        [Test]
        public void OverPushShouldThrowStackFullException()
        {
            OverPush().Should().Throw<StackFullException>();

        }

        private Action OverPush()
        {
            return () =>
            {
                for (int i = 0; i < _StackSize + 1; i++)
                {
                    _target.Push(10);
                }

            };
        }
    }

    public class StackFullException : Exception
    {
    }

    public class MyStack<T>
    {
        private readonly int _maxSize;
        private readonly List<T> _items;

        private int CurrentItemIndex => _items.Count - 1;

        public int Size => _items.Count;

        public MyStack(int maxSize)
        {
            _maxSize = maxSize;
            _items = new List<T>(maxSize);
        }


        public void Push(T item)
        {
            if (IsStackFull())
            {
                throw new StackFullException();
            }

            _items.Add(item);
        }

        private bool IsStackFull()
        {
            return _items.Count == _maxSize;
        }

        public T Pop()
        {
            var output = _items[CurrentItemIndex];

            _items.RemoveAt(CurrentItemIndex);

            return output;
        }

        public T Peep()
        {
            return _items[CurrentItemIndex];
        }
    }
}