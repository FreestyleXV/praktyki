using Microsoft.VisualStudio.TestTools.UnitTesting;
using NGramy.BL;
using System;
using System.Collections.Generic;

namespace NGramy.Tst
{
    [TestClass]
    public class NGramyTestyCzyszczenieZnakow
    {
        [TestMethod]
        public void PowinienUsunacWszystkieZnakiSpecjalneCzyliZnakiKtoreNieSaLiteramiAniCyframi()
        {
            Assert.IsTrue(NGram.CzystyTekst(@"`~!@#$%^&*()-_=+[{]}\|;:',<.>/?") == String.Empty);
        }
        [TestMethod]
        public void PowinienNieUsuwacZnakowKtoreNieSaZnakamiSpecjalnymiCzyliWTymPrzypadkuPowinienZostawicCyfry()
        {
            Assert.IsTrue(NGram.CzystyTekst("0123456789") == "0123456789");
        }
        [TestMethod]
        public void PowinienNieUsuwacZnakowKtoreNieSaZnakamiSpecjalnymiCzyliWTymPrzypadkuPowinienZostawicDuzeLitery()
        {
            Assert.IsTrue(NGram.CzystyTekst("QWERTYUIOPASD") == "QWERTYUIOPASD");
        }
        [TestMethod]
        public void PowinienNieUsuwacZnakowKtoreNieSaZnakamiSpecjalnymiCzyliWTymPrzypadkuPowinienZostawicMaleLitery()
        {
            Assert.IsTrue(NGram.CzystyTekst("qwertyuiopasd") == "qwertyuiopasd");
        }
        [TestMethod]
        public void PowinienNieUsuwacZnakowKtoreNieSaZnakamiSpecjalnymiCzyliWTymPrzypadkuPowinienZostawicSpacje()
        {
            Assert.IsTrue(NGram.CzystyTekst("    ") == "    ");
        }
        [TestMethod]
        public void PowinienNieUsuwacZnakowKtoreNieSaZnakamiSpecjalnymiCzyliWTymPrzypadkuPowinienZostawicWszystko()
        {
            Assert.IsTrue(NGram.CzystyTekst("0Q1w2E3r4T5y6U7i8O9p") == "0Q1w2E3r4T5y6U7i8O9p");
        }
        [TestMethod]
        public void PowinienNieUsuwacZnakowKtoreNieSaZnakamiSpecjalnymiCzyliWTymPrzypadkuPowinienZostawicPoprawnaCzescTekstu()
        {
            Assert.IsTrue(NGram.CzystyTekst("Qwe123+=-()") == "Qwe123");
        }
    }
    [TestClass]
    public class NGramyTestyZwracanieListyNGramow
    {
        [TestMethod]
        public void PowinienDzielicTekstNaNGramyODlugosciRownejDwaPoniewazPrzeciazenieMetodyGenerowaniaNGramowBezPodanejDlugosciNGramuPrzypisujeTejZmiennejWartoscDwa()
        {
            foreach (string a in NGram.GenerujNGramy("QWQWQWQWQWADADADAD"))
            {
                Assert.IsTrue(a.Length == 2);

            }
        }
        [TestMethod]
        public void PowinienDzielicTekstNGramyOPodanejDlugosciWPrzypadkachNaturalnychPoczawszyOdLiczbyJedenSkonczywszyNaLiczbieNaturalnejPiec()
        {
            for (int i = 1; i <= 5; i++)
            {
                foreach (string a in NGram.GenerujNGramy("QWQWQWQWQWADADADAD", i))
                {
                    Assert.IsTrue(a.Length == i);

                }
            }
        }
        [TestMethod]
        public void PowinienUsunacWszystkiePowtowrkiNGramowDlategoPierwszyIndexDanegoNGramuPowinienBycJegoOstatnim()
        {
            foreach (string a in NGram.UsunPowtorki(NGram.GenerujNGramy("QWQWQWQWQWADADADAD", 2)))
            {
                Assert.IsTrue(NGram.UsunPowtorki(NGram.GenerujNGramy("QWQWQWQWQWADADADAD", 2)).IndexOf(a) == NGram.UsunPowtorki(NGram.GenerujNGramy("QWQWQWQWQWADADADAD", 2)).LastIndexOf(a));
            }
        }
        [TestMethod]
        public void PowinienNieUsuwacPowtorekNGramowDlategoPierwszyIndexDanegoNGramuNiePowinienBycJegoOstatnim()
        {
            Assert.IsTrue(NGram.GenerujNGramy("QWQWQWQWQWADADADAD", 2).IndexOf("QW") != NGram.GenerujNGramy("QWQWQWQWQWADADADAD", 2).LastIndexOf("QW"));
        }
    }
    [TestClass]
    public class NGramyTestyMetodyNaPodanieLiczbyNgramow
    {
        [TestMethod]
        public void PowinienPodacPrawidlowaLiczbeNGramowWDanymTeksciePoprzezPodanieTekstuOrazDlugosciNGramuCzyliWDanymPrzypadku7NGramow()
        {
            Assert.IsTrue(NGram.LiczbaNGramow("QWERTYUIOP", 4) == 7);
        }
        [TestMethod]
        public void PowinienPodacPrawidlowaLiczbeNGramowWDanymTeksciePoprzezPodanieListyNGramowCzyliWDanymPrzypadku6NGramow()
        {
            List<string> lista = new List<string>();
            lista.Add("QW"); lista.Add("Wq"); lista.Add("qw"); lista.Add("wQ"); lista.Add("Q1"); lista.Add("1w");
            Assert.IsTrue(NGram.LiczbaNGramow(lista) == 6);
        }
        [TestMethod]
        public void PowinnopodacTaSamaLiczbeNGramowDlaObuPrzeciazen()
        {
            List<string> lista = new List<string>();
            lista.Add("Ab"); lista.Add("bb"); lista.Add("ba"); lista.Add("a "); lista.Add(" O"); lista.Add("Oj"); lista.Add("jc"); lista.Add("cz"); lista.Add("ze");
            Assert.AreEqual(NGram.LiczbaNGramow(lista), NGram.LiczbaNGramow("Abba Ojcze", 2));

        }
    }
}