using System;
using Bouduin.Util.Common.Primitives;
using NUnit.Framework;

namespace Bouduin.Util.Test.Common
{
    [TestFixture]
    public class APropertyChangedNotifierTest
    {
        #region fields --------------------------------------------------------
        private TestClass _testClass;
        private string _changedPropertyName;
        #endregion

        #region setup/teardown ------------------------------------------------

        [SetUp]
        public void SetUp()
        {
            _testClass = new TestClass();
            _changedPropertyName = null;
            _testClass.PropertyChanged += TestClassPropertyChanged;
            _testClass.Child = new TestClass();
        }

        [TearDown]
        public void TearDown()
        {
            _testClass.PropertyChanged -= TestClassPropertyChanged;
        }
        #endregion

        #region testclass property changed event ------------------------------
        void TestClassPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            _changedPropertyName = e.PropertyName;
        }
        #endregion

        #region Unit Tests ----------------------------------------------------

        [Test]
        public void ChangeIntValueTest()
        {
            _testClass.IntValue = 1;
            Assert.AreEqual("IntValue", _changedPropertyName);
        }

        [Test]
        public void ChangeThisIntValueTest()
        {
            _testClass.ThisIntValue = 1;
            Assert.AreEqual("ThisIntValue", _changedPropertyName);
        }
        
        [Test]
        public void ChangeChildIntValueTest()
        {
            _testClass.ChildIntValue = 1;
            Assert.AreEqual("IntValue", _changedPropertyName);
        }

        [Test]
        public void ChangeStringValueTest()
        {
            _testClass.StringValue = null;
            Assert.AreEqual("StringValue", _changedPropertyName);
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void ChangeAPrivateBackingFieldTest()
        {
            _testClass.PrivateBackingField = 0;
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void ChangePublicBackingFieldTest()
        {
            _testClass.PublicBackingField = 0;
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void ChangeMethodTest()
        {
            _testClass.Method = 0;
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void ChangeChildMethodTest()
        {
            _testClass.ChildMethod = 0;
        }
        #endregion
    }

    public class TestClass : APropertyChangedNotifier
    {

        private string _stringValue;
        private int _intValue;
        private int _field;
        private int _method;
        private int _thisIntValue;

        public int AField;

        public TestClass Child;
        
        public int DummyMethod()
        {
            return -99;
        }

        public string StringValue
        {
            get { return _stringValue; }
            set
            {
                _stringValue = value;
                OnPropertyChanged(() => StringValue);
            }
        }

        public int IntValue
        {
            get { return _intValue; }
            set
            {
                _intValue = value;
                OnPropertyChanged(() => IntValue);
            }
        }

        public int PrivateBackingField
        {
            get { return _field; }
            set
            {
                _field = value; 
                OnPropertyChanged(() => _field);
            }
        }

        public int PublicBackingField
        {
            get { return AField; }
            set
            {
                AField = value;
                OnPropertyChanged(() => AField);
            }
        }

        public int Method
        {
            get { return _method; }
            set
            {
                _method = value; 
                OnPropertyChanged(() => DummyMethod());
            }
        }

        public int ChildIntValue
        {
            get { return Child.IntValue; }
            set
            {
                Child.IntValue = value;
                OnPropertyChanged(Child, child => child.IntValue);
            }
        }

        public int ChildMethod
        {
            get { return Child.Method; }
            set
            {
                Child.Method = value;
                OnPropertyChanged(Child, child => child.DummyMethod());
            }
        }

        public int ThisIntValue
        {
            get { return _thisIntValue; }
            set
            {
                _thisIntValue = value; 
                OnPropertyChanged(this, t => t.ThisIntValue);
            }
        }

        
        



    }
}