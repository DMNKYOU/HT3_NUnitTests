using HT3_EditFile.Parsers;
using NUnit;
using NUnit.Framework;

namespace HT3_EditFileNUnitTest
{
    public class StringNumberTest
    {
        
        [TestCase("k,l,j,q,w,e,r,t,y,z,y 3")]
        [TestCase("k,l,j,q,w,e,r 101")]
        [TestCase("k,l,j 3")]
        public void SetValuesTest1(string s)
        {
            StringNumber sn = new StringNumber();
            Assert.True(sn.SetValues(s));
        }

        
        [TestCase("k,l,j,q,w,e,r,t,y,z,y 3 ")]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(" 3")]
        [TestCase("k,f,g  3  ")]
        public void SetValuesTest2(string s)
        {
            StringNumber sn = new StringNumber();
            Assert.False(sn.SetValues(s));
        }

        
        [TestCase("k,f,g 3")]
        public void SetValuesTest3(string s)
        {
            StringNumber sn = new StringNumber();
            sn.SetValues(s);
            Assert.AreEqual(new string[]{"k", "f", "g"}, sn.Str);
            Assert.AreEqual(3, sn.N);
        }
    }
}
