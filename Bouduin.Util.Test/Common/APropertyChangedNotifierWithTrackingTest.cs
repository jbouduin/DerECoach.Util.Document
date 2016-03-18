using System;
using System.Linq;
using Bouduin.Util.Common.Primitives;
using NUnit.Framework;

namespace Bouduin.Util.Test.Common
{
    [TestFixture]
    public class APropertyChangedNotifierWithTrackingTest
    {
        #region fields --------------------------------------------------------
        private PropertyChangedNotifierWithTrackingClass _testClass;
        #endregion

        #region setup/teardown ------------------------------------------------

        [SetUp]
        public void SetUp()
        {
            _testClass = new PropertyChangedNotifierWithTrackingClass
            {
                Child = new PropertyChangedNotifierWithTrackingClass()
            };

        }

        [TearDown]
        public void TearDown()
        {
        
        }
        #endregion
        
        #region Unit Tests ----------------------------------------------------

        [Test]
        public void ChangeIntValueTest()
        {
            _testClass.IntValue = 1;
            Assert.AreEqual(true, _testClass.ChangedPropertyNames.Contains("IntValue"));
            Assert.AreEqual(true, _testClass.HasChanges);
        }

        [Test]
        public void ChangeUntrackedIntValueTest()
        {
            _testClass.UntrackedInt = 1;
            Assert.AreEqual(false, _testClass.HasChanges);
        }
        [Test]
        public void ChangeIntToDefaultValueTest()
        {
            _testClass.IntValue = 0;
            Assert.AreEqual(false, _testClass.ChangedPropertyNames.Contains("IntValue"));
            Assert.AreEqual(false, _testClass.HasChanges);
        }

        [Test]
        public void ClearChangeFlagTest()
        {
            _testClass.IntValue = 1;
            _testClass.ClearChangeFlag();
            Assert.AreEqual(false, _testClass.HasChanges);
        }

        [Test]
        public void ChangeIntValueAndBackTest()
        {
            _testClass.IntValue = 1;
            _testClass.IntValue = 0;
            Assert.AreEqual(false, _testClass.ChangedPropertyNames.Contains("IntValue"));
            Assert.AreEqual(false, _testClass.HasChanges);
        }

        [Test]
        public void ChangeThisIntValueTest()
        {
            _testClass.ThisIntValue = 1;
            Assert.AreEqual(true, _testClass.ChangedPropertyNames.Contains("ThisIntValue"));
            Assert.AreEqual(true, _testClass.HasChanges);
        }

        [Test]
        public void ChangeThisIntValueAndBackTest()
        {
            _testClass.ThisIntValue = 1;
            _testClass.ThisIntValue = 0;
            Assert.AreEqual(false, _testClass.ChangedPropertyNames.Contains("ThisIntValue"));
            Assert.AreEqual(false, _testClass.HasChanges);
        }

        [Test]
        public void ChangeChildIntValueTest()
        {
            _testClass.ChildIntValue = 1;
            Assert.AreEqual(true, _testClass.ChangedPropertyNames.Contains("IntValue"));
            Assert.AreEqual(true, _testClass.HasChanges);
        }

        [Test]
        public void ChangeChildIntValueAndBackTest()
        {
            _testClass.ChildIntValue = 1;
            _testClass.ChildIntValue = 0;
            Assert.AreEqual(false, _testClass.HasChanges);
        }

        [Test]
        public void ChangeStringValueTest()
        {
            _testClass.StringValueNotStringPropertyChanged = "V";
            Assert.AreEqual(true, _testClass.ChangedPropertyNames.Contains("StringValueNotStringPropertyChanged"));
            Assert.AreEqual(true, _testClass.HasChanges);
        }

        [Test]
        public void ChangeStringValueToNullNotUsingStringPropertyChangedTest()
        {
            _testClass.StringValueNotStringPropertyChanged = null;
            Assert.AreEqual(false, _testClass.ChangedPropertyNames.Contains("StringValueNotStringPropertyChanged"));
            Assert.AreEqual(false, _testClass.HasChanges);
        }

        [Test]

        public void ChangeStringValueToEmptyNotUsingStringPropertyChangedTest()
        {
            _testClass.StringValueNotStringPropertyChanged = string.Empty;
            Assert.AreEqual(true, _testClass.ChangedPropertyNames.Contains("StringValueNotStringPropertyChanged"));
            Assert.AreEqual(true, _testClass.HasChanges);
        }

        [Test]
        public void ChangeStringValueToNullUsingStringPropertyChangedTest()
        {
            _testClass.StringValueStringPropertyChanged = null;
            Assert.AreEqual(false, _testClass.ChangedPropertyNames.Contains("StringValueStringPropertyChanged"));
            Assert.AreEqual(false, _testClass.HasChanges);
        }

        [Test]

        public void ChangeStringValueToEmptyUsingStringPropertyChangedTest()
        {
            _testClass.StringValueStringPropertyChanged = string.Empty;
            Assert.AreEqual(false, _testClass.ChangedPropertyNames.Contains("StringValueStringPropertyChanged"));
            Assert.AreEqual(false, _testClass.HasChanges);
        }

        [Test]
        public void ChangeStringValueBackNotUsingStringPropertyChangedTest()
        {
            _testClass.StringValueNotStringPropertyChanged = "V";
            _testClass.StringValueNotStringPropertyChanged = null;
            Assert.AreEqual(false, _testClass.ChangedPropertyNames.Contains("StringValueNotStringPropertyChanged"));
            Assert.AreEqual(false, _testClass.HasChanges);
        }

        [Test]
        public void ChangeStringValueBackUsingStringPropertyChangedTest()
        {
            _testClass.StringValueStringPropertyChanged = "V";
            _testClass.StringValueStringPropertyChanged = null;
            Assert.AreEqual(false, _testClass.ChangedPropertyNames.Contains("StringValueStringPropertyChanged"));
            Assert.AreEqual(false, _testClass.HasChanges);
        }

        [Test]
        public void ChangeStringValueBackToEmtpyNotUsingStringPropertyChangedTest()
        {
            _testClass.StringValueNotStringPropertyChanged = "V";
            _testClass.StringValueNotStringPropertyChanged = string.Empty;
            Assert.AreEqual(true, _testClass.ChangedPropertyNames.Contains("StringValueNotStringPropertyChanged"));
            Assert.AreEqual(true, _testClass.HasChanges);
        }

        [Test]
        public void ChangeStringValueBackToEmptyUsingStringPropertyChangedTest()
        {
            _testClass.StringValueStringPropertyChanged = "V";
            _testClass.StringValueStringPropertyChanged = string.Empty;
            Assert.AreEqual(false, _testClass.ChangedPropertyNames.Contains("StringValueStringPropertyChanged"));
            Assert.AreEqual(false, _testClass.HasChanges);
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void ChangePrivateBackingFieldTest()
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

    #region test class --------------------------------------------------------
    public class PropertyChangedNotifierWithTrackingClass : APropertyChangedNotifierWithTracking
    {

        private string _stringValueNotStringPropertyChanged;
        private string _stringValueStringPropertyChanged;
        private int _intValue;
        private int _field;
        private int _method;
        private int _thisIntValue;
        private int _untrackedInt;

        public int AField;

        public PropertyChangedNotifierWithTrackingClass Child;
        
        public int DummyMethod()
        {
            return -99;
        }

        public string StringValueNotStringPropertyChanged
        {
            get { return _stringValueNotStringPropertyChanged; }
            set
            {
                var oldValue = _stringValueNotStringPropertyChanged;
                _stringValueNotStringPropertyChanged = value;
                OnPropertyChanged(() => StringValueNotStringPropertyChanged, oldValue, value);
            }
        }

        public string StringValueStringPropertyChanged
        {
            get { return _stringValueStringPropertyChanged; }
            set
            {
                var oldValue = _stringValueStringPropertyChanged;
                _stringValueStringPropertyChanged = value;
                OnStringPropertyChanged(() => StringValueStringPropertyChanged, oldValue, value);
            }
        }
        public int IntValue
        {
            get { return _intValue; }
            set
            {
                var oldValue = IntValue;
                _intValue = value;
                OnPropertyChanged(() => IntValue, oldValue, value);
            }
        }

        public int PrivateBackingField
        {
            get { return _field; }
            set
            {
                var oldValue = _field;
                _field = value; 
                OnPropertyChanged(() => _field, oldValue, value);
            }
        }

        public int PublicBackingField
        {
            get { return AField; }
            set
            {
                var oldValue = AField;
                AField = value;
                OnPropertyChanged(() => AField, oldValue, value);
            }
        }

        public int Method
        {
            get { return _method; }
            set
            {
                var oldValue = _method;
                _method = value; 
                OnPropertyChanged(() => DummyMethod(), oldValue, value);
            }
        }

        public int ChildIntValue
        {
            get { return Child.IntValue; }
            set
            {
                var oldValue = Child.IntValue;
                Child.IntValue = value;
                OnPropertyChanged(Child, child => child.IntValue, oldValue, value);
            }
        }

        public int ChildMethod
        {
            get { return Child.Method; }
            set
            {
                var oldValue = Child.Method;
                Child.Method = value;
                OnPropertyChanged(Child, child => child.DummyMethod(), oldValue, value);
            }
        }

        public int ThisIntValue
        {
            get { return _thisIntValue; }
            set
            {
                var oldValue = _thisIntValue;
                _thisIntValue = value; 
                OnPropertyChanged(this, t => t.ThisIntValue, oldValue, value);
            }
        }
        
        public int UntrackedInt
        {
            get { return _untrackedInt; }
            set
            {
                _untrackedInt = value; 
                OnPropertyChanged(() => UntrackedInt);
            }
        }
    }
    #endregion
}