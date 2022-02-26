namespace Demo.Tests
{
    using System;
    using NUnit.Framework;
    using Domain;

    [TestFixture]
    public class ClassTests
    {
        [Test]
        public void ToString_ValidData_Success()
        {
            var teacher = new Teacher(1, "pasnumber 0000 00001", "contnumber 001");
            var class1 = new Class(1, "1-A", teacher);
            var expected = "1-A pasnumber 0000 00001 contnumber 001";

            var actual = class1.ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToString_EmptyTeacher_Success()
        {
            var class1 = new Class(1, "2-Á");
            var expected = "2-Á";

            var actual = class1.ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Ctor_ValidDataEmptyTeacher_Success()
        {
            Assert.DoesNotThrow(() => _ = new Class(1, "2-Á"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase("\0")]
        [TestCase("\n")]
        public void Ctor_WrongDataNullClassNameEmptyTeachers_Fail(string wrongClassName)
        {
            // act & assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Class(1, wrongClassName));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase("\0")]
        [TestCase("\n")]
        public void Ctor_WrongDataNullClassNameEmptyTeacher_Fail(string wrongClassName)
        {
            var teacher = new Teacher(1, "pasnumber 0000 00001", "contnumber 001");

            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Class(1, wrongClassName));
        }

        [Test]
        public void Ctor_ValidData_Success()
        {
            var teacher = new Teacher(1, "pasnumber 0000 00001", "contnumber 001");

            Assert.DoesNotThrow(() => _ = new Class(1, "1-A", teacher));
        }
    }
}

