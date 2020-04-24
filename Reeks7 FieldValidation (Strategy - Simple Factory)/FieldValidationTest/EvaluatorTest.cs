using FieldEvaluation.pattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TestEvaluation
{
    [TestClass]
    public class EvaluatorTest
    {
        //vul deze methode aan
        public void Controleer(string invoer, bool assert)
        {
       
        }


        [TestMethod]
        public void NumberTesten()
        {
            Controleer("123", true);
            Controleer("0.123", true);
            Controleer("0,123", true);
            Controleer("1.123E33", true);
            Controleer("0", true);
            Controleer("-0.0", true);
            Controleer("", false);
            Controleer("-", false);
            Controleer("0.123a", false);
        }
       
        [TestMethod]
        public void EmailTesten()
        {
            Controleer("user@host", true);
            Controleer("first.last@host", true);
            Controleer("first.last@host.domain", true);
            Controleer("user", false);
            Controleer(" ", false);
            Controleer("first.last", false);
            Controleer("user.", false);
            Controleer("user@", false);
            Controleer("user@.", false);
            Controleer("user.@", false);
            Controleer("first.last@.domain", false);
        }



        [TestMethod]
        public void BankTesten()
        {
            Controleer("123-4567890-02", true);
            Controleer("abc-defghij-kl", false);
            Controleer("12-34-70", false);
            Controleer("1234-567890-02", false);
            Controleer("123-4567890-12", false);
        }

    }
}
